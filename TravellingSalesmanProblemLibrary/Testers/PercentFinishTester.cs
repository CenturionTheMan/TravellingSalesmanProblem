using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Testers;

public class PercentFinishTester : Tester
{
    private TimeSpan timePerTest = new TimeSpan(0,2,0);

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

    public Tester SetTimePerTest(TimeSpan timePerTest)
    {
        this.timePerTest = timePerTest;
        return this;
    }


    public override void RunTest(string fileDir)
    {
        int testsAmountPerSize = repPerSize * repPerMatrix;

        fileDir = fileDir.ChangeFileExtension("");

        string filePath = fileDir + algorithm.AlgorithmName + "PercentFinishedTest.csv";


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
                    var taskRes = Task.Run(() => RunAlghorithmForGivenTime(matrix, timePerTest));
                    var hasFinished = taskRes.Result;
                    if (hasFinished) amountFinished++;
                }

                if (repSize % 10 == 1 || repSize == repPerSize)
                    Console.WriteLine($"{algorithm.AlgorithmName} | Size: {matrixSize} | RepPerSize: {repSize} | FinishedAmount: {amountFinished} | TestsAmount: {testsAmountPerSize}");
            }

            double percent = (double)amountFinished * 100 / (double)testsAmountPerSize;
            percent = Math.Round(percent, 2);

            List<object[]> data = new();
            data.Add(new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, percent });
            FilesHandler.CreateCsvFile(data, filePath, false, ',');
        }
    }


    private async Task<bool> RunAlghorithmForGivenTime(AdjMatrix matrix, TimeSpan time)
    {
        bool hasFinished = false;

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        _ = Task.Factory.StartNew(() => { 
            algorithm.CancellationToken = cancellationTokenSource.Token;
            var result = algorithm.CalculateBestPath(matrix);
            hasFinished = true;
        }, cancellationTokenSource.Token);

        TimeSpan offest = new TimeSpan(0, 0, 0, 0, 1);

        for (TimeSpan counter = new(0,0,0); counter.CompareTo(time) < 0; counter = counter.Add(offest))
        {
            await Task.Delay(offest);
            if(hasFinished)
            {
                break;
            }
        }

        cancellationTokenSource.Cancel();

        return hasFinished;
    }
}
