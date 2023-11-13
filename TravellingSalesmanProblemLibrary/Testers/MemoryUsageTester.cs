using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravellingSalesmanProblemLibrary.Utilites;

namespace TravellingSalesmanProblemLibrary.Testers;

public class MemoryUsageTester : Tester
{

    public MemoryUsageTester(TSPAlgorithm algorithm) : base(algorithm)
    {
        minMatrixSize = 2;
        maxMatrixSize = 20;
        stepMatrixSize = 1;

        matrixMinDistance = 1;
        matrixMaxDistance = 1000;

        repPerMatrix = 1;
        repPerSize = 20;
    }

    public override void RunTest(string fileDir)
    {
        fileDir = fileDir.ChangeFileExtension("");
        string pathMean = fileDir + algorithm.AlgorithmName + "MemoryTestMean" + ".csv";
        string pathMax = fileDir + algorithm.AlgorithmName + "MemoryTestMan" + ".csv";
        string pathMedian = fileDir + algorithm.AlgorithmName + "MemoryTestMedian" + ".csv";

        List<object[]> tmp = new();
        tmp.Add(new object[] { "Algorithm", "RepsPerSize", "MatrixSize", "Memory [MB]" });
        FilesHandler.CreateCsvFile(tmp, pathMean, true);
        FilesHandler.CreateCsvFile(tmp, pathMax, true);
        FilesHandler.CreateCsvFile(tmp, pathMedian, true);

        for (int matrixSize = minMatrixSize; matrixSize <= maxMatrixSize; matrixSize += stepMatrixSize)
        {
            List<double> meanRep = new();
            List<double> maxRep = new();
            List<double> medianRep = new();

            for (int repSize = 1; repSize <= repPerSize; repSize++)
            {
                AdjMatrix matrix = new AdjMatrix(matrixSize, matrixMinDistance, matrixMaxDistance);
                CancellationTokenSource memoryRegisterCTS = new CancellationTokenSource();

                List<double> perMatrixMeanRep = new();
                List<double> perMatrixMaxRep = new();
                List<double> perMatrixMedianRep = new();

                for (int j = 0; j < repPerMatrix; j++)
                {
                    var memoryRegisterTaskResult = MeasureMemoryUsageInIntervals(memoryRegisterCTS, 10);
                    algorithm.CalculateBestPath(matrix);
                    memoryRegisterCTS.Cancel();

                    var memoryTable = memoryRegisterTaskResult.Result;
                    if (memoryTable == null)
                    {
                        memoryTable = new();
                        memoryTable.Add(GC.GetTotalMemory(true));
                    }

                    perMatrixMeanRep.Add(memoryTable.Average());
                    perMatrixMaxRep.Add(memoryTable.Max());
                    perMatrixMedianRep.Add(memoryTable.Median());


                    if (repSize % 5 == 1 || repSize == repPerSize)
                        Console.WriteLine($"{algorithm.AlgorithmName} | Size: {matrixSize} | RepPerSize: {repSize} | MedianMemory: {memoryTable.Median()} [MB]");
                }
                

                meanRep.Add(perMatrixMeanRep.Average());
                maxRep.Add(perMatrixMaxRep.Max());
                medianRep.Add(perMatrixMedianRep.Median());
            }

            double meanVal = meanRep.Average();
            double maxVal = maxRep.Max();
            double medianVal = medianRep.Median();

            List<object[]> meanRow = new List<object[]>() { new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, meanVal} };
            List<object[]> maxRow = new List<object[]>() { new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, maxVal} };
            List<object[]> medianRow = new List<object[]>() { new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, medianVal} };
            FilesHandler.CreateCsvFile(meanRow, pathMean, false);
            FilesHandler.CreateCsvFile(maxRow, pathMax, false);
            FilesHandler.CreateCsvFile(medianRow, pathMedian, false);
        }
    }

    private async Task<List<double>> MeasureMemoryUsageInIntervals(CancellationTokenSource ctSource, int intervalInMiliseconds)
    {
        List<double> result = new List<double>();

        while (ctSource.Token.IsCancellationRequested == false)
        {
            long memory = GC.GetTotalMemory(true);
            result.Add(memory/(double)1000000); //to MB
            await Task.Delay(intervalInMiliseconds);
        }

        return result;
    }
}
