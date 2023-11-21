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
    private int maxRepPerNeighbourSearch;
    private int repAmountPerTemperature;
    private int initCostAmountRepUntilBreak;

    private Random random = new Random();

    public SimulatedAnnealing(double initialTemperature, double alpha, int repAmountPerTemperature, int maxRepPerNeighbourSearch, int costAmountRepUntilBreak) : base() 
    {
        this.initialTemperature = initialTemperature;
        this.alpha = Math.Clamp(alpha, 0, 1);
        this.maxRepPerNeighbourSearch = Math.Clamp(maxRepPerNeighbourSearch, 1, maxRepPerNeighbourSearch);
        this.initCostAmountRepUntilBreak = costAmountRepUntilBreak;
        this.repAmountPerTemperature = repAmountPerTemperature;
    }


    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        return RunAlgorithm(matrix, cancellationToken);
    }


    private (int[]? path, int cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken) 
    {
        double temperature = this.initialTemperature;
        int repSameCostAmount = 0;



        (int[] path, int cost)? initSolution = GetInitPath(matrix);
        if (initSolution == null) return null;
        (int[] path, int cost) bestSolution = initSolution.Value;
        (int[] path, int cost) globalBestSolution = bestSolution;


        while (repSameCostAmount < initCostAmountRepUntilBreak)
        {
            for (int i = 0; i < repAmountPerTemperature; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    CloseCycleInPath(ref globalBestSolution.path);
                    return globalBestSolution;
                }

                var newSolution = CreateSolutionNeighbour(bestSolution, SwapElementsAtIndexes, matrix, cancellationToken);
                
                if (newSolution == null)
                {
                    CloseCycleInPath(ref globalBestSolution.path);
                    return globalBestSolution;
                }

                if (newSolution.Value.cost < bestSolution.cost)
                {
                    bestSolution = newSolution.Value;
                    repSameCostAmount = 0;

                    if(globalBestSolution.cost > bestSolution.cost)
                        globalBestSolution = bestSolution;
                }
                else if (newSolution.Value.cost == bestSolution.cost)
                {
                    bestSolution = newSolution.Value;
                    repSameCostAmount++;
                }
                else
                {
                    double treshold = random.NextDouble();
                    double probability = CalculateProbability(newSolution.Value.cost, bestSolution.cost, temperature);

                    if (probability > treshold)
                    {
                        bestSolution = newSolution.Value;
                        repSameCostAmount = 0;
                    }
                    else
                    {
                        repSameCostAmount++;
                    }

                    Console.WriteLine($"Best={bestSolution.cost} | Prob={probability.ToString("0.00")} | Temp={temperature.ToString("0.00")} | RepCostFator={(repSameCostAmount / (double)initCostAmountRepUntilBreak).ToString("0.00")}");
                }
            }

            temperature = temperature * alpha;
        }

        CloseCycleInPath(ref globalBestSolution.path);
        return globalBestSolution;
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

    
    private (int[] path, int cost)? CreateSolutionNeighbour((int[] path, int cost) solution, Action<int[], int, int> changePositionsFunction, AdjMatrix matrix, CancellationToken cancellationToken)
    {
        int[] currentPath = (int[])solution.path.Clone();

        int[] bestPath = new int[0];
        int bestCost = int.MaxValue;

        for (int i = 0; i < this.maxRepPerNeighbourSearch; i++)
        {
            if (cancellationToken.IsCancellationRequested) return null;
            int? cost = null;
            do
            {
                if (cancellationToken.IsCancellationRequested) return null;

                int firstIndex = random.Next(0, matrix.GetMatrixSize);
                int secondIndex = random.Next(0, matrix.GetMatrixSize);

                changePositionsFunction(currentPath, firstIndex, secondIndex);

                cost = CalculatePathCost(currentPath, matrix);

                if(cost.HasValue && cost.Value < bestCost)
                {
                    bestCost = cost.Value;
                    bestPath = (int[])currentPath.Clone();
                }
                changePositionsFunction(currentPath, firstIndex, secondIndex);


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
