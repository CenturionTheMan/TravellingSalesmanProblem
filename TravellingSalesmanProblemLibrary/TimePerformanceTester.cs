using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public class TimePerformanceTester
{
    const string DETAILED_PATH_SUFFIX = "Detailed";
    const string MEAN_PATH_SUFFIX = "Mean";


    private TSPAlgorithm algorithm;

    private int minMatrixSize = 2;
    private int maxMatrixSize = 10;
    private int stepMatrixSize = 1;

    private int matrixMinDistance = 1;
    private int matrixMaxDistance = 1000;

    private int repPerMatrix = 1;
    private int repPerSize = 100;

    /// <summary>
    /// Initializes a new instance of the TimePerformanceTester class.
    /// </summary>
    /// <param name="algorithm">The TSP algorithm to test.</param>
    public TimePerformanceTester(TSPAlgorithm algorithm)
    {
        this.algorithm = algorithm;
    }

    /// <summary>
    /// Sets the matrix size range for testing.
    /// </summary>
    /// <param name="minMatrixSize">The minimum matrix size.</param>
    /// <param name="maxMatrixSize">The maximum matrix size.</param>
    /// <param name="stepMatrixSize">The step size for increasing the matrix size.</param>
    /// <returns>The current TimePerformanceTester instance.</returns>
    public TimePerformanceTester SetMatrixSizeForTest(int minMatrixSize, int maxMatrixSize, int stepMatrixSize)
    {
        this.minMatrixSize = minMatrixSize;
        this.maxMatrixSize = maxMatrixSize;
        this.stepMatrixSize = stepMatrixSize;
        return this;
    }

    /// <summary>
    /// Sets the distance range for matrix generation.
    /// </summary>
    /// <param name="matrixMinDistance">The minimum distance value.</param>
    /// <param name="matrixMaxDistance">The maximum distance value.</param>
    /// <returns>The current TimePerformanceTester instance.</returns>
    public TimePerformanceTester SetMatrixDistances(int matrixMinDistance, int matrixMaxDistance)
    {
        this.matrixMinDistance = matrixMinDistance;
        this.matrixMaxDistance = matrixMaxDistance;
        return this;
    }

    /// <summary>
    /// Sets the repetition amount for testing.
    /// </summary>
    /// <param name="repPerMatrix">The number of repetitions per matrix.</param>
    /// <param name="repPerSize">The number of repetitions per matrix size.</param>
    /// <returns>The current TimePerformanceTester instance.</returns>
    public TimePerformanceTester SetRepeatAmount(int repPerMatrix, int repPerSize)
    {
        this.repPerMatrix = repPerMatrix;
        this.repPerSize = repPerSize;
        return this;
    }

    /// <summary>
    /// Performs time performance testing and saves results to CSV files.
    /// </summary>
    /// <param name="fileDir">The directory to save CSV files in.</param>
    public void PerformTimeTest(string fileDir)
    {
        fileDir = fileDir.ChangeFileExtension("");

        Stopwatch stopWatch = new Stopwatch();

        string detailedPath = fileDir + algorithm.AlgorithmName + DETAILED_PATH_SUFFIX + ".csv";
        string meanPath = fileDir + algorithm.AlgorithmName + MEAN_PATH_SUFFIX + ".csv";


        List<object[]> tmp = new();
        tmp.Add(new object[] { "Algorithm", "RepsPerSize", "MatrixSize", "TimeInMs"});
        FilesHandler.CreateCsvFile(tmp, detailedPath, true);
        FilesHandler.CreateCsvFile(tmp, meanPath, true);

        for (int matrixSize = minMatrixSize; matrixSize <= maxMatrixSize; matrixSize += stepMatrixSize)
        {
            List<object[]> dataForDetailed = new();
            List<object[]> dataForMean = new();

            double timePerSize = 0;
            for (int repSize = 1; repSize <= repPerSize; repSize++)
            {
                AdjMatrix matrix = new AdjMatrix(matrixSize, matrixMinDistance, matrixMaxDistance);

                long timePerMatrix = 0;
                for (int j = 0; j < repPerMatrix; j++)
                {
                    stopWatch.Restart();
                    _ = algorithm.CalculateBestPath(matrix);
                    stopWatch.Stop();
                    timePerMatrix += stopWatch.ElapsedMilliseconds;
                }
                timePerSize += timePerMatrix / repPerMatrix;

                dataForDetailed.Add(new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, timePerMatrix / repPerMatrix });

                if (repSize % 10 == 1 || repSize % 10 == 0)
                    Console.WriteLine($"{algorithm.AlgorithmName} | Size: {matrixSize} | RepPerSize: {repSize} | Time: {timePerMatrix / repPerMatrix}");
            }
            double meanTime = timePerSize / repPerSize;
            dataForMean.Add(new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, meanTime });


            FilesHandler.CreateCsvFile(dataForDetailed, detailedPath, false);
            FilesHandler.CreateCsvFile(dataForMean, meanPath, false);
        }
    }

}
