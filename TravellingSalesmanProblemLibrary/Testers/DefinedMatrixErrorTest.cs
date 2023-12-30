using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemLibrary.Testers;

public class DefinedMatrixErrorTest : ITester
{
    private ITSPAlgorithm algorithm;
    private AdjMatrix matrix;

    //private Stopwatch stopWatch = new Stopwatch();

    private TimeSpan runTime = new TimeSpan(0,2,0);
    private int repPerMatrix = 10;
    private int expectedCost;
    private string matrixName;

    private string pathError = "";
    private string pathBest = "";

    private (int cost, long timeInMs)? bestCost;

    public DefinedMatrixErrorTest(ITSPAlgorithm algorithm, string matrixName, AdjMatrix matrix, int expectedCost)
    {
        this.algorithm = algorithm;
        this.matrix = matrix;
        this.expectedCost = expectedCost;
        this.matrixName = matrixName;
    }

    public DefinedMatrixErrorTest(ITSPAlgorithm algorithm, string matrixName, string filePath, int expectedCost)
    {
        AdjMatrix? matrix = FilesHandler.LoadAdjMatrixFromFile(filePath);
        if(matrix == null) { throw new ArgumentException(); }

        this.matrix = matrix;
        this.algorithm = algorithm;
        this.expectedCost = expectedCost;
        this.matrixName = matrixName;
    }

    public DefinedMatrixErrorTest SetRunTime(TimeSpan runTime)
    {
        this.runTime = runTime;
        return this;
    }
    public DefinedMatrixErrorTest SetRepPerMatrix(int repPerMatrix)
    {
        this.repPerMatrix = repPerMatrix;
        return this;
    }

    public void RunTest(string outputFileDir, string algorithmDesForOutput)
    {
        outputFileDir = outputFileDir.ChangeFileExtension("");
        pathBest = outputFileDir + $"BestPathTest_{algorithm.AlgorithmDetailedName}_{algorithmDesForOutput}_{matrixName}.csv";

        algorithm.OnShowCurrentSolutionInIntervals(new TimeSpan(0, 0, 0, 0, 100), OnDataReceived);

        List<object[]> tmp2 = new()
        {
            new object[] { "Algorithm", "Iteration", "MatrixName", "TimeInMiliSeconds", "Cost", "Error"}
        };
        FilesHandler.CreateCsvFile(tmp2, pathBest, true, ',');

        (int[]? path, int cost)? result = null; //save it to file!!

        for (int currentRep = 0; currentRep < repPerMatrix; currentRep++)
        {
            pathError = outputFileDir + $"ErrorTest_{algorithm.AlgorithmDetailedName}_{algorithmDesForOutput}_{matrixName}_{currentRep}.csv";
            List<object[]> tmp = new()
            {
                new object[] { "Algorithm", "MatrixName", "TimeInMiliSeconds", "Error" }
            };
            FilesHandler.CreateCsvFile(tmp, pathError, true, ',');

            CancellationTokenSource cancellationTokenSource = new();
            cancellationTokenSource.CancelAfter(runTime);
            
            var res = algorithm.CalculateBestPath(matrix,cancellationTokenSource.Token);

            if(res.HasValue && (result == null || res.Value.cost < result.Value.cost))
            {
                result = res;
            }

            if (bestCost != null)
            {
                var ratio = Math.Abs((expectedCost - bestCost.Value.cost) * 100 / (double)expectedCost);
                List<object[]> line = new()
                {
                    new object[] { algorithm.AlgorithmDetailedName, currentRep, matrixName, bestCost.Value.timeInMs, bestCost.Value.cost, ratio}
                };
                FilesHandler.CreateCsvFile(line, pathBest, false, ',');
            }
            bestCost = null;
        }

        string createText = $"{result!.Value.path.ArrayToPathString()}";
        File.WriteAllText(outputFileDir + $"BestPathFound_{algorithm.AlgorithmDetailedName}_{algorithmDesForOutput}_{matrixName}.txt", createText);
    }


    private void OnDataReceived(int? currentCost, long time)
    {
        if (currentCost == null) return;

        if(bestCost == null || bestCost.Value.cost > currentCost)
        {
            bestCost = (currentCost.Value, time);
        }

        List<object[]> tmp = new()
        {
            new object[] { algorithm.AlgorithmDetailedName, matrixName, time, Math.Abs((expectedCost - currentCost.Value)) * 100/ (double)expectedCost }
        };
        FilesHandler.CreateCsvFile(tmp, pathError, false, ',');
    }
}
