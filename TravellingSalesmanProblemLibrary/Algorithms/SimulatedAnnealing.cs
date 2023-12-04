﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Algorithms;

public class SimulatedAnnealing : TSPAlgorithm, ISolutionImprover
{
    public Action<string>? OnAlgorithmShowInfo;

    public override string AlgorithmName => "SimulatedAnnealing_"+ChoosenCoolingFunction;

    public double InitialTemperature { get => initialTemperature; private set => initialTemperature = value; }
    public double Alpha { get => alpha; private set => alpha = value; }
    public int MaxRepPerNeighbourSearch { get => maxRepPerNeighbourSearch; private set => maxRepPerNeighbourSearch = value; }
    public int RepAmountPerTemperature { get => repAmountPerTemperature; private set => repAmountPerTemperature = value; }
    public int InitCostAmountRepUntilBreak { get => initCostAmountRepUntilBreak; private set => initCostAmountRepUntilBreak = value; }
    public CoolingFunction ChoosenCoolingFunction { get => coolingFunction; private set => coolingFunction = value; }


    private double initialTemperature;
    private double alpha;
    private int maxRepPerNeighbourSearch;
    private int repAmountPerTemperature;
    private int initCostAmountRepUntilBreak;
    private CoolingFunction coolingFunction;

    private TimeSpan intervalLength;

    private int? currentBestCost;

    private Random random = new();
    private Action<int?, long>? onIntervalShowCurrentSolution;

    public SimulatedAnnealing(double initialTemperature, double alpha, int repAmountPerTemperature, int maxRepPerNeighbourSearch, int costAmountRepUntilBreak, CoolingFunction coolingFunction = CoolingFunction.GEOMETRIC) : base() 
    {
        this.InitialTemperature = initialTemperature;
        this.Alpha = alpha;
        this.MaxRepPerNeighbourSearch = Math.Clamp(maxRepPerNeighbourSearch, 1, maxRepPerNeighbourSearch);
        this.InitCostAmountRepUntilBreak = costAmountRepUntilBreak;
        this.RepAmountPerTemperature = repAmountPerTemperature;

        this.coolingFunction = coolingFunction;
    }

    public SimulatedAnnealing(double alpha, int maxRepPerNeighbourSearch, int costAmountRepUntilBreak, CoolingFunction coolingFunction) : base()
    {
        this.Alpha = alpha;
        this.MaxRepPerNeighbourSearch = Math.Clamp(maxRepPerNeighbourSearch, 1, maxRepPerNeighbourSearch);
        this.InitCostAmountRepUntilBreak = costAmountRepUntilBreak;
        this.coolingFunction = coolingFunction;

        throw new NotImplementedException();
        //this.InitialTemperature = initialTemperature;
        //this.RepAmountPerTemperature = repAmountPerTemperature;
    }

    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        return RunAlgorithm(matrix, cancellationToken);
    }

    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<int?, long> toInvoke)
    {
        this.intervalLength = intervalLength;
        onIntervalShowCurrentSolution += toInvoke;
    }

    public int? GetCurrentSolutionCost()
    {
        return currentBestCost;
    }

    private void CallShowSolutionInIntervals(CancellationToken cancellationToken)
    {
        _ = Task.Factory.StartNew(async () => {
            Stopwatch stopwatch = new();
            stopwatch.Restart();
            while (true)
            {
                onIntervalShowCurrentSolution?.Invoke(currentBestCost, stopwatch.ElapsedMilliseconds);
                if (cancellationToken.IsCancellationRequested)
                {
                    stopwatch.Stop();
                    return;
                }
                await Task.Delay(intervalLength);
            }
        }, cancellationToken);
    }


    private (int[]? path, int cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken) 
    {
        double temperature = this.InitialTemperature;
        int repSameCostAmount = 0;

        int tempChangedCounter = 1;

        (int[] path, int cost)? initSolution = GetInitPath(matrix);
        if (initSolution == null) return null;
        (int[] path, int cost) currentSolution = initSolution.Value;
        (int[] path, int cost) bestSolution = currentSolution;
        
        currentBestCost = bestSolution.cost;

        CancellationTokenSource cancellationTokenSource = new();
        if(onIntervalShowCurrentSolution != null) { CallShowSolutionInIntervals(cancellationTokenSource.Token); }

        while (repSameCostAmount < InitCostAmountRepUntilBreak)
        {
            int repsPerTemperature = this.RepAmountPerTemperature;

            for (int i = 0; i < repsPerTemperature; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    CloseCycleInPath(ref bestSolution.path);
                    cancellationTokenSource.Cancel();
                    return bestSolution;
                }

                var newSolution = CreateSolutionNeighbour(currentSolution, matrix, cancellationToken);
                
                if (newSolution == null)
                {
                    CloseCycleInPath(ref bestSolution.path);
                    cancellationTokenSource.Cancel();
                    return bestSolution;
                }

                if (newSolution.Value.cost < currentSolution.cost)
                {
                    currentSolution = newSolution.Value;
                    repSameCostAmount = 0;

                    if(bestSolution.cost > currentSolution.cost)
                    {
                        bestSolution = currentSolution;
                        currentBestCost = bestSolution.cost;
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

                    //Console.WriteLine($"Best={bestSolution.cost} | Current={currentSolution.cost} | Prob={probability.ToString("0.000")} | Temp={temperature.ToString("0.00")} | RepCostFator={(repSameCostAmount / (double)InitCostAmountRepUntilBreak).ToString("0.00")}");
                }

            }

            temperature = CalculateNewTemperature(temperature, tempChangedCounter);

            ShowInfo($"Best={bestSolution.cost} | Current={currentSolution.cost} | Temp={temperature.ToString("0.00")} | RepCostFator={(repSameCostAmount / (double)InitCostAmountRepUntilBreak).ToString("0.00")}\n");


            if (repSameCostAmount*2 >= InitCostAmountRepUntilBreak && bestSolution.cost < currentSolution.cost)
            {
                currentSolution = bestSolution;
                repSameCostAmount = initCostAmountRepUntilBreak/2;
            }

            tempChangedCounter++;
        }

        CloseCycleInPath(ref bestSolution.path);
        cancellationTokenSource.Cancel();
        return bestSolution;
    }

    private double CalculateNewTemperature(double temperature, int tempChangedCounter)
    {
        double result = coolingFunction switch
        {
            CoolingFunction.GEOMETRIC => temperature * Alpha,
            CoolingFunction.LINEAR => temperature - Alpha,
            CoolingFunction.LOGARITHMIC => Alpha/Math.Log(tempChangedCounter + 1),
            _ => throw new Exception()
        };

        if (result < 0) result = 0;

        return result;
    }

    private void ShowInfo(string message)
    {
        Console.WriteLine(message);
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


    public enum CoolingFunction
    {
        LINEAR,
        LOGARITHMIC,
        GEOMETRIC,
    }

}
