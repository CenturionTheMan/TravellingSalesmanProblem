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


    private ITSPAlgorithm algorithm;

    private int minMatrixSize = 2;
    private int maxMatrixSize = 10;
    private int stepMatrixSize = 1;

    private int matrixMinDistance = 1;
    private int matrixMaxDistance = 1000;

    private int repPerMatrix = 1;
    private int repPerSize = 100;

    public TimePerformanceTester(ITSPAlgorithm algorithm)
    {
        this.algorithm = algorithm;
    }

    public TimePerformanceTester SetMatrixSizeForTest(int minMatrixSize, int maxMatrixSize, int stepMatrixSize)
    {
        this.minMatrixSize = minMatrixSize;
        this.maxMatrixSize = maxMatrixSize;
        this.stepMatrixSize = stepMatrixSize;
        return this;
    }

    public TimePerformanceTester SetMatrixDistances(int matrixMinDistance, int matrixMaxDistance)
    {
        this.matrixMinDistance = matrixMinDistance;
        this.matrixMaxDistance = matrixMaxDistance;
        return this;
    }

    public TimePerformanceTester SetRepeatAmount(int repPerMatrix, int repPerSize)
    {
        this.repPerMatrix = repPerMatrix;
        this.repPerSize = repPerSize;
        return this;
    }


    public void PerformTimeTest(string fileDir)
    {
        fileDir = fileDir.ChangeFileExtension("");

        Stopwatch stopWatch = new Stopwatch();

        string detailedPath = fileDir + algorithm.AlgorithName + DETAILED_PATH_SUFFIX + ".csv";
        string meanPath = fileDir + algorithm.AlgorithName + MEAN_PATH_SUFFIX + ".csv";


        List<object[]> tmp = new();
        tmp.Add(new object[] { "MatrixSize", "TimeInMs"});
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
                    stopWatch.Start();
                    _ = algorithm.CalculateBestPathCost(matrix);
                    stopWatch.Stop();
                    timePerMatrix += stopWatch.ElapsedMilliseconds;
                }
                timePerSize += timePerMatrix / repPerMatrix;

                dataForDetailed.Add(new object[] { matrixSize, timePerMatrix / repPerMatrix });

                if(repSize % 10 == 0)
                    Console.WriteLine($"{algorithm.AlgorithName} | Size: {matrixSize} | RepPerSize: {repSize} | Time: {timePerMatrix / repPerMatrix}");
            }
            double meanTime = timePerSize / repPerSize;
            dataForMean.Add(new object[] { matrixSize, meanTime });


            FilesHandler.CreateCsvFile(dataForDetailed, detailedPath, false);
            FilesHandler.CreateCsvFile(dataForMean, meanPath, false);
        }
    }

}
