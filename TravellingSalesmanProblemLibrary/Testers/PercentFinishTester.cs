using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Testers;

public class PercentFinishTester : Tester
{
    private int timePerTestInMs = 1000;

    public PercentFinishTester(TSPAlgorithm algorithm) : base(algorithm)
    {
        minMatrixSize = 2;
        maxMatrixSize = 10;
        stepMatrixSize = 1;

        matrixMinDistance = 1;
        matrixMaxDistance = 1000;

        repPerMatrix = 1;
        repPerSize = 100;
    }

    public Tester SetTimePerTest(int timePerTestInMs)
    {
        this.timePerTestInMs = timePerTestInMs;
        return this;
    }


    public override void RunTest(string fileDir)
    {
        int testsAmountPerSize = repPerSize * repPerMatrix;

        fileDir = fileDir.ChangeFileExtension("");

        string filePath = fileDir + $"PercentFinishedTest_{algorithm.AlgorithmName}.csv";

        List<object[]> tmp = new();
        tmp.Add(new object[] { "Algorithm", "RepsPerSize", "MatrixSize", "PercentFinished" });
        FilesHandler.CreateCsvFile(tmp, filePath, true, ',');

        for (int matrixSize = minMatrixSize; matrixSize <= maxMatrixSize; matrixSize += stepMatrixSize)
        {
            int amountFinished = 0;

            for (int repSize = 1; repSize <= repPerSize; repSize++)
            {
                AdjMatrix matrix = new AdjMatrix(matrixSize, matrixMinDistance, matrixMaxDistance);

                for (int j = 0; j < repPerMatrix; j++)
                {
                    var taskRes = Task.Run(() => RunAlghorithmForGivenTime(matrix, timePerTestInMs));
                    var hasFinished = taskRes.Result;
                    if (hasFinished == true)
                        amountFinished++;
                }

                if (repSize % 10 == 0 || repSize == 1)
                    Console.WriteLine($"{algorithm.AlgorithmName} | Size: {matrixSize} | RepPerSize: {repSize} | FinishedAmount: {amountFinished}/{testsAmountPerSize}");
            }

            double percent = (double)amountFinished / (double)testsAmountPerSize;
            percent = Math.Round(percent * 100, 2);

            List<object[]> data = new();
            data.Add(new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, percent.ToString("0.##")});
            FilesHandler.CreateCsvFile(data, filePath, false, ',');
        }
    }


    private async Task<bool> RunAlghorithmForGivenTime(AdjMatrix matrix, int timeInMs)
    {
        bool hasFinished = false;
        bool wait = true;

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        _ = Task.Factory.StartNew(() => { 
            algorithm.CancellationToken = cancellationTokenSource.Token;
            var result = algorithm.CalculateBestPath(matrix);
            if (wait)
            {
                hasFinished = true;
                wait = false;
            }
        }, cancellationTokenSource.Token);

        _ = Task.Factory.StartNew(async () => {
            await Task.Delay(timeInMs);
            wait = false;
        });

        while (wait)
        {
            await Task.Delay(1);
        }

        cancellationTokenSource.Cancel();

        return hasFinished;
    }
}
