using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public class GeneticAlgorithm : TSPAlgorithm, ISolutionImprover
{
    public override string AlgorithmName => "GeneticAlgorithm";
    public readonly int PopulationSize;

    private readonly Random random = new();

    public GeneticAlgorithm(int populationSize)
    {
        this.PopulationSize = populationSize;
    }

    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<int?, long> toInvoke)
    {
        throw new NotImplementedException();
    }

    public void UnSubscribeShowCurrentSolutionInIntervals(Action<int?, long> toInvoke)
    {
        throw new NotImplementedException();
    }


    private void RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        var population = InitializePopulation(matrix);
    }


    private Individual CreateChild(Individual first, Individual second, AdjMatrix matrix)
    {
        Individual? individual = null;

        do
        {
            int offest = random.Next(0, first.Path.Length);

            List<int> tmp = first.Path.Take(offest).ToList();

            foreach (var vertex in second.Path)
            {
                if (!tmp.Contains(vertex)) tmp.Add(vertex);
            }

            int[] path = tmp.ToArray();
            int? cost = CalculatePathCost(path, matrix);
            if (cost == null) continue;
            float fitness = CalculateFitness(cost.Value);
            individual = new Individual(path, cost.Value, fitness);
        } while (individual == null);

        return individual.Value;
    }

    private List<Individual> InitializePopulation(AdjMatrix matrix)
    {
        List<int> allNumbers = new();
        for (int i = 0; i < matrix.GetMatrixSize; i++)
        {
            allNumbers.Add(i);
        }

        List<Individual> population = new();

        for (int i = 0; i < PopulationSize; i++)
        {
            allNumbers = allNumbers.OrderBy(x => random.Next()).ToList();

            int[] path = allNumbers.ToArray();
            int? cost = CalculatePathCost(path, matrix);
            if(cost == null)
            {
                i--;
                continue;
            }
            float fitness = CalculateFitness(cost.Value);

            Individual first = new(path, cost.Value, fitness);
            population.Add(first);
        }

        return population;
    }

    private float CalculateFitness(int cost)
    {
        return 1 / (cost + 1);
    }

    /// <summary>
    /// Calculates the cost of the given path in the context of the provided adjacency matrix.
    /// </summary>
    /// <param name="path">The path to calculate the cost for.</param>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <returns>The cost of the path, or null if the cost could not be calculated.</returns>
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



    internal struct Individual
    {
        internal int[] Path = null!;
        internal int Cost;
        internal float Fitness;

        public Individual(int[] path, int cost, float fitness)
        {
            this.Path = path;
            this.Cost = cost;
            this.Fitness = fitness;
        }
    }
}
