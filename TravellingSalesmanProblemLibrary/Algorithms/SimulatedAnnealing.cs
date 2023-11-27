using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Algorithms;

public class SimulatedAnnealing : TSPAlgorithm
{
    public Action<string>? OnAlgorithmShowInfo;
    public Action<(int[] path, int cost)>? OnAlgorithmTempReduction;

    public override string AlgorithmName => "SimulatedAnnealing";

    public double InitialTemperature { get => initialTemperature; private set => initialTemperature = value; }
    public double Alpha { get => alpha; private set => alpha = value; }
    public int MaxRepPerNeighbourSearch { get => maxRepPerNeighbourSearch; private set => maxRepPerNeighbourSearch = value; }
    public int RepAmountPerTemperature { get => repAmountPerTemperature; private set => repAmountPerTemperature = value; }
    public int InitCostAmountRepUntilBreak { get => initCostAmountRepUntilBreak; private set => initCostAmountRepUntilBreak = value; }

    private double initialTemperature;
    private double alpha;
    private int maxRepPerNeighbourSearch;
    private int repAmountPerTemperature;
    private int initCostAmountRepUntilBreak;

    private Random random = new();

    private Stopwatch stopwatch = new();

    public SimulatedAnnealing(double initialTemperature, double alpha, int repAmountPerTemperature, int maxRepPerNeighbourSearch, int costAmountRepUntilBreak) : base() 
    {
        this.InitialTemperature = initialTemperature;
        this.Alpha = Math.Clamp(alpha, 0, 1);
        this.MaxRepPerNeighbourSearch = Math.Clamp(maxRepPerNeighbourSearch, 1, maxRepPerNeighbourSearch);
        this.InitCostAmountRepUntilBreak = costAmountRepUntilBreak;
        this.RepAmountPerTemperature = repAmountPerTemperature;
    }


    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        return RunAlgorithm(matrix, cancellationToken);
    }


    private (int[]? path, int cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken) 
    {
        stopwatch.Restart();

        double temperature = this.InitialTemperature;
        int repSameCostAmount = 0;

        int tempChangedCounter = 1;

        (int[] path, int cost)? initSolution = GetInitPath(matrix);
        if (initSolution == null) return null;
        (int[] path, int cost) currentSolution = initSolution.Value;
        (int[] path, int cost) bestSolution = currentSolution;


        while (repSameCostAmount < InitCostAmountRepUntilBreak)
        {
            int repsPerTemperature = this.RepAmountPerTemperature;
            //int repsPerTemperature = (int)(this.repAmountPerTemperature / Math.Log(temperature));
            for (int i = 0; i < repsPerTemperature; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    CloseCycleInPath(ref bestSolution.path);
                    stopwatch.Stop();
                    return bestSolution;
                }

                var newSolution = CreateSolutionNeighbour(currentSolution, matrix, cancellationToken);
                
                if (newSolution == null)
                {
                    CloseCycleInPath(ref bestSolution.path);
                    stopwatch.Stop();
                    return bestSolution;
                }

                if (newSolution.Value.cost < currentSolution.cost)
                {
                    currentSolution = newSolution.Value;
                    repSameCostAmount = 0;

                    if(bestSolution.cost > currentSolution.cost)
                    {
                        bestSolution = currentSolution;
                    }
                }
                else if (newSolution.Value.cost == currentSolution.cost)
                {
                    currentSolution = newSolution.Value;
                    repSameCostAmount++;
                }
                else
                {
                    double treshold = random.NextDouble();
                    double probability = CalculateProbability(newSolution.Value.cost, currentSolution.cost, temperature);

                    if (probability > treshold)
                    {
                        currentSolution = newSolution.Value;
                        repSameCostAmount = 0;
                    }
                    else
                    {
                        repSameCostAmount++;
                    }

                    Console.WriteLine($"Best={bestSolution.cost} | Current={currentSolution.cost} | Prob={probability.ToString("0.000")} | Temp={temperature.ToString("0.00")} | RepCostFator={(repSameCostAmount / (double)InitCostAmountRepUntilBreak).ToString("0.00")}");
                }

                InvokeOnIteration(bestSolution);
            }

            temperature = CalculateNewTemperature(temperature, tempChangedCounter);

            ShowInfo($"Best={bestSolution.cost} | Current={currentSolution.cost} | Temp={temperature.ToString("0.00")} | RepCostFator={(repSameCostAmount / (double)InitCostAmountRepUntilBreak).ToString("0.00")}\n");

            if(repSameCostAmount >= InitCostAmountRepUntilBreak && bestSolution.cost < currentSolution.cost)
            {
                currentSolution = bestSolution;
                repSameCostAmount = initCostAmountRepUntilBreak/2;
            }

            tempChangedCounter++;
        }

        CloseCycleInPath(ref bestSolution.path);
        stopwatch.Stop();
        return bestSolution;
    }

    private void InvokeOnIteration((int[] path, int cost) current)
    {
        if(OnAlgorithmTempReduction != null)
        {
            int[] newPath = new int[current.path.Length + 1];
            Array.Copy(current.path, newPath, current.path.Length);
            newPath[current.path.Length - 1] = current.path[0];

            OnAlgorithmTempReduction.Invoke((newPath, current.cost));
        }
    }

    private double CalculateNewTemperature(double temperature, int tempChangedCounter)
    {
        //temperature = initialTemperature/Math.Log(tempChangedCounter+1);
        //if(int.MaxValue == tempChangedCounter)
        //{
        //    temperature = 0;
        //    tempChangedCounter = 0;
        //}

        return temperature * Alpha;
    }

    private void ShowInfo(string message)
    {
        OnAlgorithmShowInfo?.Invoke(message);
    }

    private void CloseCycleInPath(ref int[] path)
    {
        Array.Resize(ref path, path.Length);
        path[path.Length - 1] = path[0];
    }

    private double CalculateProbability(double newCost, double oldCost, double temperature)
    {
        double diff = newCost - oldCost;
        double prob = Math.Exp(-diff/temperature);
        return prob;
    }

    
    private (int[] path, int cost)? CreateSolutionNeighbour((int[] path, int cost) solution, AdjMatrix matrix, CancellationToken cancellationToken)
    {
        int[] currentPath = (int[])solution.path.Clone();

        int[] bestPath = new int[0];
        int bestCost = int.MaxValue;

        for (int i = 0; i < this.MaxRepPerNeighbourSearch; i++)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            int? cost;
            do
            {
                if (cancellationToken.IsCancellationRequested) return null;

                int firstIndex = random.Next(0, matrix.GetMatrixSize);
                int secondIndex = random.Next(0, matrix.GetMatrixSize);

                SwapElementsAtIndexes(currentPath, firstIndex, secondIndex);

                cost = CalculatePathCost(currentPath, matrix);

                if(cost.HasValue && cost.Value < bestCost)
                {
                    bestCost = cost.Value;
                    bestPath = (int[])currentPath.Clone();
                }
                SwapElementsAtIndexes(currentPath, firstIndex, secondIndex);


            } while (cost == null);
        }

        return (bestPath, bestCost);
    }

    private void SwapElementsAtIndexes(int[] array, int firstIndex, int secondIndex)
    {
        int tmp = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = tmp;
    }

    private int? CalculatePathCost(int[] path, AdjMatrix matrix)
    {
        int sum = 0;
        for (int i = 0; i < path.Length - 1; i++)
        {
            int from = path[i];
            int to = path[i + 1];
            if (matrix.TryGetDistance(from, to, out int dis) == false) return null;
            sum += dis;
        }
        if (matrix.TryGetDistance(path[path.Length - 1], path[0], out int lastDis) == false) return null;
        sum += lastDis;
        return sum;
    }

    /// <summary>
    /// Method will return initial value for upper bound as well as path asociated with it.
    /// Path is being created using closest-neighbour selection.
    /// </summary>
    /// <param name="adjMatrix">The adjacency matrix representing the problem.</param>
    /// <returns>Initial upper bound value with path or null if could not created valid path</returns>
    private (int[] path, int cost)? GetInitPath(AdjMatrix adjMatrix)
    {
        const int BEGIN_VERTEX = 0;

        List<int> path = new();
        int sumCost = 0;
        int fromVertex = BEGIN_VERTEX;
        path.Add(BEGIN_VERTEX);

        for (int i = 0; i < adjMatrix.GetMatrixSize - 1; i++)
        {
            var next = FindClosestNeigh();
            if (next == null) return null;

            path.Add(next.Value.vertex);
            sumCost += next.Value.cost;
            fromVertex = next.Value.vertex;
        }
        if (adjMatrix.TryGetDistance(path[path.Count - 1], BEGIN_VERTEX, out int last) == false) return null;
        sumCost += last;
        return (path.ToArray(), sumCost);


        (int cost, int vertex)? FindClosestNeigh()
        {
            int? minCost = null;
            int vertex = -1;
            for (int j = 0; j < adjMatrix.GetMatrixSize; j++)
            {
                if (path.Contains(j)) continue;

                if (adjMatrix.TryGetDistance(fromVertex, j, out int dis) == false) continue;

                if (minCost == null || dis < minCost)
                {
                    minCost = dis;
                    vertex = j;
                }
            }

            return minCost.HasValue ? (minCost.Value, vertex) : null;
        }
    }
}
