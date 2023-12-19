using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public class GeneticAlgorithm : TSPAlgorithm, ISolutionImprover
{
    public override string AlgorithmName => "GeneticAlgorithm";
    public readonly int PopulationSize;
    public readonly double CrossChance;
    public readonly double MutationChance;


    private (int[]? path, int cost)? allTimeBest = null;
    
    private readonly Random random = new();
    private TimeSpan intervalLength;
    private Action<int?, long>? onIntervalShowCurrentSolution;


    public GeneticAlgorithm(int populationSize, double crossChance, double mutationChance)
    {
        this.PopulationSize = populationSize;
        this.CrossChance = crossChance;
        MutationChance = mutationChance;

    }

    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken CancellationToken)
    {
        return RunAlgorithm(matrix, CancellationToken);
    }

    /// <summary>
     /// Sets up a periodic interval for showing the current solution during the algorithm execution.
     /// </summary>
     /// <param name="intervalLength">The interval length for displaying the current solution.</param>
     /// <param name="toInvoke">The action to invoke for displaying the current solution.</param>
    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<int?, long> toInvoke)
    {
        this.intervalLength = intervalLength;
        onIntervalShowCurrentSolution += toInvoke;
    }

    /// <summary>
    /// Unsubscribes an action from the event handler for showing the current solution in intervals.
    /// </summary>
    /// <param name="toInvoke">The action to unsubscribe.</param>
    public void UnSubscribeShowCurrentSolutionInIntervals(Action<int?, long> toInvoke)
    {
        onIntervalShowCurrentSolution -= toInvoke;
    }

    /// <summary>
    /// Initiates the periodic display of the current solution in intervals using a separate task.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to interrupt the display task.</param>
    private void CallShowSolutionInIntervals(CancellationToken cancellationToken)
    {
        _ = Task.Factory.StartNew(async () => {
            Stopwatch stopwatch = new();
            stopwatch.Restart();
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    stopwatch.Stop();
                    return;
                }
                if(allTimeBest != null)
                    onIntervalShowCurrentSolution?.Invoke(allTimeBest.Value.cost, stopwatch.ElapsedMilliseconds);
                await Task.Delay(intervalLength);
            }
        }, cancellationToken);
    }


    private (int[]? path, int cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        var population = InitializePopulation(matrix);

        int generationCounter = 1;

        while (!cancellationToken.IsCancellationRequested)
        {
            var best = population.MinBy(x => x.Cost);
            if(allTimeBest.HasValue == false || allTimeBest.Value.cost > best.Cost)
            {
                allTimeBest = (best.Path, best.Cost);
            }
            
            Console.WriteLine($"All time best: {allTimeBest.Value.cost} || Current best: {best.Cost} || Generation: {generationCounter}");

            population = SelectionRoulette(population); //select best genes
            population = CreateOffspring(matrix, population, CrossChance); //crossover
            Mutate(matrix, ref population, MutationChance); //mutation

            generationCounter++;
        }
        return allTimeBest;
    }

    private void Mutate(AdjMatrix matrix, ref List<Individual> population, double mutateChance)
    {
        mutateChance = Math.Clamp(mutateChance, 0, 1);

        List<Individual> toRemove = new();
        foreach (var item in population)
        {
            double prob = random.NextDouble();
            if (prob <= mutateChance)
            {
                toRemove.Add(item);
            }
        }

        foreach (var single in toRemove)
        {
            int first = random.Next(0, single.Path.Length);
            int second = random.Next(0, single.Path.Length);
            population.Remove(single);

            var path = single.Path.SwapElements(first, second);
            var cost = CalculatePathCost(matrix, path);
            if (cost == null) continue;
            Individual individual = new(path, cost.Value);
            population.Add(individual);
        }
    }

    //prob works
    private List<Individual> SelectionRoulette(List<Individual> population)
    {
        List<(double min, double max, Individual individual)> scoreList = new();
        
        var max = population.Max(x => x.Cost);
        double sum = population.Sum(x => max - x.Cost + 1);

        double lower = 0;
        foreach (var individual in population)
        {
            double percent = (max - individual.Cost + 1)/(double)sum;
            double upper = lower + percent;

            scoreList.Add((lower, upper, individual));
            lower = upper;
        }


        List<Individual> newPopulation = new();
        while (newPopulation.Count < PopulationSize)
        {
            double val = random.NextDouble();
            var selected = scoreList.FirstOrDefault(x => x.min <= val && x.max > val);

            newPopulation.Add(selected.individual);
        }
        return newPopulation;
    }

    private List<Individual> CreateOffspring(AdjMatrix matrix, List<Individual> parents, double crossChance)
    {
        crossChance = Math.Clamp(crossChance, 0, 1);

        List<Individual> offspring = new();
        while (offspring.Count < PopulationSize)
        {
            double prob = random.NextDouble();

            Individual first = parents[random.Next(0, parents.Count)];
            Individual second = parents[random.Next(0, parents.Count)];

            if(prob <= crossChance)
            {
                offspring.Add(CreateChild(matrix, first, second));
                offspring.Add(CreateChild(matrix, second, first));
            }
            else
            {
                offspring.Add(first);
                offspring.Add(second);
            }
        }

        return offspring;
    }

    private Individual CreateChild(AdjMatrix matrix, Individual first, Individual second)
    {
        Individual? individual = null;

        do
        {
            int offest = random.Next(0, first.Path.Length);
            List<int> tmp = first.Path.Take(offest).ToList();

            foreach (var vertex in second.Path)
            {
                if (!tmp.Contains(vertex)) 
                    tmp.Add(vertex);
            }

            int[] path = tmp.ToArray();
            int? cost = CalculatePathCost(matrix, path);
            if (cost == null) continue;
            individual = new Individual(path, cost.Value);
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
            int? cost = CalculatePathCost(matrix, path);
            if(cost == null)
            {
                i--;
                continue;
            }

            Individual first = new(path, cost.Value);
            population.Add(first);
        }

        return population;
    }

    /// <summary>
    /// Calculates the cost of the given path in the context of the provided adjacency matrix.
    /// </summary>
    /// <param name="path">The path to calculate the cost for.</param>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <returns>The cost of the path, or null if the cost could not be calculated.</returns>
    private int? CalculatePathCost(AdjMatrix matrix, int[] path)
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
        internal double Fitness => 1.0 / ((double)Cost + 1);

        public Individual(int[] path, int cost)
        {
            this.Path = path;
            this.Cost = cost;
        }
    }
}
