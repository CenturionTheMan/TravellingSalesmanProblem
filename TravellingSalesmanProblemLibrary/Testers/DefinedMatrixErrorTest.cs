using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesmanProblemLibrary.Algorithms;

namespace TravellingSalesmanProblemLibrary.Testers;

public class DefinedMatrixErrorTest : ITester
{
    private SimulatedAnnealing algorithm;
    private AdjMatrix matrix;

    private Stopwatch stopWatch = new Stopwatch();

    private TimeSpan runTime = new TimeSpan(0,2,0);
    private int repPerMatrix = 10;
    private int expectedCost;
    private string matrixName;

    private string pathError = "";
    private string pathBest = "";
    private int currentRep;

    private (int[] path, int cost, long timeInMs)? best;

    public DefinedMatrixErrorTest(SimulatedAnnealing algorithm, string matrixName, AdjMatrix matrix, int expectedCost)
    {
        this.algorithm = algorithm;
        this.matrix = matrix;
        this.expectedCost = expectedCost;
        this.matrixName = matrixName;
    }

    public DefinedMatrixErrorTest(SimulatedAnnealing algorithm, string matrixName, string filePath, int expectedCost)
    {
        AdjMatrix? matrix = FilesHandler.LoadAdjMatrixFromFile(filePath);
        if(matrix == null) { throw new ArgumentException(); }

        this.matrix = matrix;
        this.algorithm = algorithm;
        this.expectedCost = expectedCost;
        this.matrixName = matrixName;
    }

    public void RunTest(string outputFileDir)
    {
        outputFileDir = outputFileDir.ChangeFileExtension("");

        pathError = outputFileDir + $"ErrorTest_{algorithm.AlgorithmName}_{matrixName}.csv";
        pathBest = outputFileDir + $"BestPathTest_{algorithm.AlgorithmName}_{matrixName}.csv";
        algorithm.OnAlgorithmTempReduction += OnTemperatureDecrease;

        List<object[]> tmp = new()
        {
            new object[] { "Algorithm", "currentRep", "MatrixName", "TimeInMiliSeconds", "Error" }
        };
        FilesHandler.CreateCsvFile(tmp, pathError, true, ',');

        List<object[]> tmp2 = new()
        {
            new object[] { "Algorithm", "currentRep", "MatrixName", "TimeInMiliSeconds", "Cost"}
        };
        FilesHandler.CreateCsvFile(tmp2, pathBest, true, ',');

        for (currentRep = 0; currentRep < repPerMatrix; currentRep++)
        {
            CancellationTokenSource cancellationTokenSource = new();
            cancellationTokenSource.CancelAfter(runTime);
            
            stopWatch.Restart();
            _ = algorithm.CalculateBestPath(matrix,cancellationTokenSource.Token);
            stopWatch.Stop();

            if (best != null)
            {
                List<object[]> line = new()
                {
                    new object[] { algorithm.AlgorithmName, currentRep, matrixName, best.Value.timeInMs, best.Value.cost}
                };
                FilesHandler.CreateCsvFile(line, pathBest, false, ',');
            }
            best = null;
        }
    }


    private void OnTemperatureDecrease((int[] path, int cost) current)
    {
        if(best == null || best.Value.cost > current.cost)
        {
            best = (current.path, current.cost, stopWatch.ElapsedMilliseconds);
        }

        List<object[]> tmp = new()
        {
            new object[] { algorithm.AlgorithmName, currentRep, matrixName, stopWatch.ElapsedMilliseconds, Math.Abs((expectedCost - current.cost)) / (double)expectedCost }
        };
        FilesHandler.CreateCsvFile(tmp, pathError, false, ',');
    }
}
