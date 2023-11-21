using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Testers;

public class TimePerformanceTester: Tester
{
    const string DETAILED_PATH_SUFFIX = "Detailed";
    const string MEAN_PATH_SUFFIX = "Avg";

    private int seed;

    /// <summary>
    /// Initializes a new instance of the TimePerformanceTester class.
    /// </summary>
    /// <param name="algorithm">The TSP algorithm to test.</param>
    public TimePerformanceTester(TSPAlgorithm algorithm, int seed) : base(algorithm)
    {
        minMatrixSize = 2;
        maxMatrixSize = 10;
        stepMatrixSize = 1;

        matrixMinDistance = 1;
        matrixMaxDistance = 1000;

        repPerMatrix = 1;
        repPerSize = 100;
        this.seed = seed;
    }

    /// <summary>
    /// Performs time performance testing and saves results to CSV files.
    /// </summary>
    /// <param name="fileDir">The directory to save CSV files in.</param>
    public override void RunTest(string fileDir)
    {
        fileDir = fileDir.ChangeFileExtension("");

        Stopwatch stopWatch = new Stopwatch();

        string detailedPath = fileDir + $"TimeTest_{algorithm.AlgorithmName}_{DETAILED_PATH_SUFFIX}.csv";
        string meanPath = fileDir + $"TimeTest_{algorithm.AlgorithmName}_{MEAN_PATH_SUFFIX}.csv";


        List<object[]> tmp = new();
        tmp.Add(new object[] { "Algorithm", "RepsPerSize", "MatrixSize", "TimeInMiliSeconds"});
        FilesHandler.CreateCsvFile(tmp, detailedPath, true, ',');
        FilesHandler.CreateCsvFile(tmp, meanPath, true, ',');

        for (int matrixSize = minMatrixSize; matrixSize <= maxMatrixSize; matrixSize += stepMatrixSize)
        {
            List<object[]> dataForDetailed = new();
            List<object[]> dataForMean = new();

            double timePerSize = 0;
            for (int repSize = 1; repSize <= repPerSize; repSize++)
            {
                AdjMatrix matrix = new AdjMatrix(matrixSize, matrixMinDistance, matrixMaxDistance, seed);

                long timePerMatrix = 0;
                for (int j = 0; j < repPerMatrix; j++)
                {
                    stopWatch.Restart();
                    _ = algorithm.CalculateBestPath(matrix);
                    stopWatch.Stop();
                    timePerMatrix += stopWatch.ElapsedMilliseconds;
                }
                double singleTestTime = timePerMatrix / repPerMatrix;
                timePerSize += singleTestTime;

                dataForDetailed.Add(new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, singleTestTime });

                if (repSize % 10 == 0 || repSize == 1)
                    Console.WriteLine($"{algorithm.AlgorithmName} | Size: {matrixSize} | RepPerSize: {repSize} | Time: {singleTestTime} [ms]");
            }
            double meanTime = timePerSize / repPerSize;
            dataForMean.Add(new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, meanTime });


            FilesHandler.CreateCsvFile(dataForDetailed, detailedPath, false, ',');
            FilesHandler.CreateCsvFile(dataForMean, meanPath, false, ',');
        }
    }
}
