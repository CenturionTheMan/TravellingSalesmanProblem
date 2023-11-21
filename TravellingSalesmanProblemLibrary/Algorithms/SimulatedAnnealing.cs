using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Algorithms;

public class SimulatedAnnealing : TSPAlgorithm
{
    public Action<string> OnTemperatureMileston;
    
    public override string AlgorithmName => "SimulatedAnnealing";




    private double initialTemperature;
    private double alpha;
    private int neighborhoodRange;
    private int initPathRepeatAmountBreak = 10000;
    private int initCostRepeatAmountBreak = 1000000;

    private Random random = new Random();

    public SimulatedAnnealing(double initialTemperature, double alpha, int neighborhoodRange) : base() 
    {
        this.initialTemperature = initialTemperature;
        this.alpha = Math.Clamp(alpha, 0, 1);
        this.neighborhoodRange = Math.Clamp(neighborhoodRange, 1, neighborhoodRange);
    }


    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        return RunAlgorithm(matrix, cancellationToken);
    }


    private (int[]? path, int cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken) 
    {
        bool[] hasReachedMileston = new bool[]{ false, false, false, false };

        double temperature = this.initialTemperature;
        int repSamePathAmount = 0;
        int repSameCostAmount = 0;

        (int[] path, int cost)? initSolution = GetInitPath(matrix);
        if (initSolution == null) return null;
        (int[] path, int cost) bestSolution = initSolution.Value;


        while (repSamePathAmount < initPathRepeatAmountBreak && repSameCostAmount < initCostRepeatAmountBreak)
        {
            if(cancellationToken.IsCancellationRequested)
            {
                CloseCycleInPath(ref bestSolution.path);
                return bestSolution;
            }

            var newSolution = CreateNeighbourSolution(bestSolution, SwapElementsAtIndexes, matrix, cancellationToken);
            if (newSolution == null)
            {
                CloseCycleInPath(ref bestSolution.path);
                return bestSolution;
            }

            if (newSolution.Value.cost < bestSolution.cost)
            {
                bestSolution = newSolution.Value;
                repSamePathAmount = 0;
                repSameCostAmount = 0;

            }
            else if(newSolution.Value.cost == bestSolution.cost)
            {
                bestSolution = newSolution.Value;
                repSamePathAmount = 0;
                repSameCostAmount ++;
            }
            else
            {
                double treshold = random.NextDouble();
                double probability = CalculateProbability(newSolution.Value.cost, bestSolution.cost, temperature);
                //Console.WriteLine(probability);
                if(probability > treshold) 
                {
                    bestSolution = newSolution.Value;
                    repSamePathAmount = 0;
                    repSameCostAmount = 0;
                }
                else
                {
                    repSamePathAmount++;
                    repSameCostAmount++;
                }
            }

            Console.WriteLine($"RepPathFactor={(repSamePathAmount/(double)initPathRepeatAmountBreak).ToString("0.00")} | RepCostFator={(repSameCostAmount/ (double)initCostRepeatAmountBreak).ToString("0.00")} | {bestSolution.cost}");

            temperature = temperature * alpha;

            //if (OnTemperatureMileston != null)
            //    CheckIfMileston(temperature, initialTemperature, hasReachedMileston);
        }

        CloseCycleInPath(ref bestSolution.path);
        return bestSolution;
    }

    //private void CheckIfMileston(double temperature, double initialTemperature, bool[] hasReachedMileston) 
    //{
    //    double percent = temperature / initialTemperature;
    //    if (!hasReachedMileston[0] && percent < 0.80)
    //    {
    //        OnTemperatureMileston($"Temperature cooled itself by {((1 - percent)*100).ToString("0.00")}%\n");
    //        hasReachedMileston[0] = true;
    //    }
    //    else if (!hasReachedMileston[1] && percent < 0.60)
    //    {
    //        OnTemperatureMileston($"Temperature cooled itself by {((1 - percent) * 100).ToString("0.00")}%\n");
    //        hasReachedMileston[1] = true;
    //    }
    //    else if (!hasReachedMileston[2] && percent < 0.40)
    //    {
    //        OnTemperatureMileston($"Temperature cooled itself by {((1 - percent) * 100).ToString("0.00")}%\n");
    //        hasReachedMileston[2] = true;
    //    }
    //    else if (!hasReachedMileston[3] && percent < 0.20)
    //    {
    //        OnTemperatureMileston($"Temperature cooled itself by {((1 - percent) * 100).ToString("0.00")}%\n");
    //        hasReachedMileston[3] = true;
    //    }
    //}

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


    private (int[] path, int cost)? CreateNeighbourSolution((int[] path, int cost) solution, Action<int[], int, int> changePositionsFunction, AdjMatrix matrix, CancellationToken cancellationToken)
    {
        int[] currentPath = (int[])solution.path.Clone();
        int? cost = null;

        for (int i = 0; i < this.neighborhoodRange; i++)
        {
            if (cancellationToken.IsCancellationRequested) return null;
         
            do
            {
                if (cancellationToken.IsCancellationRequested) return null;

                int firstIndex = random.Next(0, matrix.GetMatrixSize);
                int secondIndex = random.Next(0, matrix.GetMatrixSize);

                changePositionsFunction(currentPath, firstIndex, secondIndex);

                cost = CalculatePathCost(currentPath, matrix);

                if(cost == null)
                {
                    changePositionsFunction(currentPath, firstIndex, secondIndex);
                }


            } while (cost == null);
        }

        return (currentPath, cost.Value);
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
