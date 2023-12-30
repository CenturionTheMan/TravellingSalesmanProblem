using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravellingSalesmanProblemLibrary.GeneticAlgorithm;

namespace TravellingSalesmanProblemLibrary;

public class GeneticAlgorithm : ITSPAlgorithm
{
    public string AlgorithmName => "Genetic Algorithm";

    public string AlgorithmDetailedName => $"GeneticAlgorithm_{MutationType}_{CrossoverType}";

    public readonly int PopulationSize;
    public readonly double CrossChance;
    public readonly double MutationChance;
    public readonly MutationType @MutationType;
    public readonly CrossoverType @CrossoverType;
    public readonly int? CostRepAmountWithoutImprovementUntilBreak;

    private int? bestCostYet = null;
    
    private readonly Random random = new();
    private TimeSpan intervalLength;
    private Action<int?, long>? onIntervalShowCurrentSolution;


    public GeneticAlgorithm(int populationSize, CrossoverType crossoverType, double crossChance, MutationType mutationType, double mutationChance, int? costRepAmountWithoutImprovementUntilBreak)
    {
        populationSize = Math.Clamp(populationSize, 2, int.MaxValue);
        crossChance = Math.Clamp(crossChance, 0, 1);
        mutationChance = Math.Clamp(mutationChance, 0, 1);

        this.PopulationSize = populationSize;
        this.CrossChance = crossChance;
        this.MutationChance = mutationChance;
        this.MutationType = mutationType;
        this.CrossoverType = crossoverType;
        this.CostRepAmountWithoutImprovementUntilBreak = costRepAmountWithoutImprovementUntilBreak;

    }

    #region SHOW INFO IN ITERVALS

    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<int?, long> toInvoke)
    {
        this.intervalLength = intervalLength;
        onIntervalShowCurrentSolution += toInvoke;
    }

    public void UnSubscribeShowCurrentSolutionInIntervals(Action<int?, long> toInvoke) => onIntervalShowCurrentSolution -= toInvoke;


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
                if(bestCostYet != null)
                    onIntervalShowCurrentSolution?.Invoke(bestCostYet.Value, stopwatch.ElapsedMilliseconds);
                await Task.Delay(intervalLength);
            }
        }, cancellationToken);
    }

    #endregion

    public (int[] path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken CancellationToken)
    {
        return RunAlgorithm(matrix, CancellationToken);
    }

    public (int[] path, int cost)? CalculateBestPath(AdjMatrix matrix)
    {
        return CalculateBestPath(matrix, CancellationToken.None);
    }



    private (int[] path, int cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        List<Individual> population = InitializePopulation(matrix);
        Individual? tmp = population.MinBy(x => x.Cost);
        if (tmp is null)
            throw new Exception();

        (int[] path, int cost) bestEver = (tmp.Path, tmp.Cost);
        bestCostYet = bestEver.cost;
        int generationCounter = 1;
        int costRepAmount = 0;

        CancellationTokenSource cancellationTokenSource = new();
        if (onIntervalShowCurrentSolution != null) { CallShowSolutionInIntervals(cancellationTokenSource.Token); }

        while (cancellationToken.IsCancellationRequested == false && 
            (CostRepAmountWithoutImprovementUntilBreak.HasValue == false || costRepAmount < CostRepAmountWithoutImprovementUntilBreak.Value))
        {
            population = SelectionTournament(population); //select best genes
            population = CreateOffspring(matrix, population); //crossover
            DoMutataions(matrix, population); //mutation

            var currentBest = population.MinBy(x => x.Cost);
            if (currentBest is null) throw new Exception();

            if (bestEver.cost > currentBest.Cost)
            {
                bestEver = (currentBest.Path, currentBest.Cost);
                bestCostYet = currentBest.Cost;
                costRepAmount = 0;
            }
            else
            {
                costRepAmount++;
            }

            string costBreakPerc = CostRepAmountWithoutImprovementUntilBreak is null? "-" : ((double)(100 * costRepAmount) / (double)CostRepAmountWithoutImprovementUntilBreak).ToString("0.00") + "%";
            //Console.WriteLine($"All time best: {bestEver.cost} || Current avg: {population.Average(x => x.Cost).ToString("0.")} || Current best: {currentBest.Cost} || Generation: {generationCounter} || Cost break: {costBreakPerc}");
            Console.WriteLine($"All time best: {bestEver.cost} || Current best: {currentBest.Cost} || Generation: {generationCounter} || Cost break: {costBreakPerc}");


            generationCounter++;
        }

        cancellationTokenSource.Cancel();
        CloseCycleInPath(ref bestEver.path);
        return bestEver;
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
            if (cost == null)
            {
                i--;
                continue;
            }

            Individual first = new(path, cost.Value);
            population.Add(first);
        }

        return population;
    }



    private List<Individual> SelectionTournament(List<Individual> population)
    {
        List<Individual> selection = new();

        int tournamentSize = population.Count() / 20;
        tournamentSize = Math.Clamp(tournamentSize, 2, population.Count());

        while (selection.Count < population.Count())
        {
            List<Individual> tmp = new();

            while (tmp.Count < tournamentSize)
            {
                tmp.Add(population[random.Next(0, population.Count)]);
            }

            var best = tmp.MinBy(x => x.Cost);
            if (best is null)
                throw new Exception("");
            selection.Add(best);
        }

        return selection;
    }



    private List<Individual> CreateOffspring(AdjMatrix matrix, List<Individual> parents)
    {
        List<Individual> offspring = new();
        while (offspring.Count < PopulationSize)
        {
            double prob = random.NextDouble();

            Individual first = parents[random.Next(0, parents.Count)];
            Individual second;
            do
            {
                second = parents[random.Next(0, parents.Count)];
            } while (second == first);

            if (prob <= CrossChance)
            {
                Individual child1, child2;

                switch (CrossoverType)
                {
                    case CrossoverType.ORDER:
                        child1 = CreateChildOrder(matrix, first, second);
                        child2 = CreateChildOrder(matrix, second, first);
                        break;
                    case CrossoverType.PMX:
                        child1 = CreateChildPMX(matrix, first, second);
                        child2 = CreateChildPMX(matrix, second, first);
                        break;
                    default:
                        throw new ArgumentException();
                }

                offspring.Add(child1);
                offspring.Add(child2);
            }
            else
            {
                offspring.Add(first);
                offspring.Add(second);
            }
        }

        return offspring;
    }

    private Individual CreateChildPMX(AdjMatrix matrix, Individual first, Individual second)
    {
        int? newCost;
        int[] newPath;

        do
        {
            int begin = random.Next(0, first.Path.Length - 1);
            int end = random.Next(begin + 1, first.Path.Length);


            int?[] childPath = new int?[first.Path.Length];

            for (int i = begin; i <= end; i++)
            {
                childPath[i] = first.Path[i];
            }

            for (int i = begin; i <= end; i++)
            {
                if (childPath.Contains(second.Path[i])) continue;

                int numberToPlace = second.Path[i];
                int currentIndex = i;

                do
                {
                    currentIndex = Array.FindIndex(second.Path, x => x == first.Path[currentIndex]);
                }
                while (currentIndex >= begin && currentIndex <= end);

                childPath[currentIndex] = numberToPlace;
            }

            for (int i = 0; i < first.Path.Length; i++)
            {
                if (childPath[i] is not null) continue;

                childPath[i] = second.Path[i];
            }

            newPath = childPath.Select(x => x!.Value).ToArray();
            newCost = CalculatePathCost(matrix, newPath);
        } while (newCost is null);

        return new Individual(newPath, newCost.Value);
    }


    private Individual CreateChildOrder(AdjMatrix matrix, Individual first, Individual second)
    {
        Individual? individual = null;
        do
        {
            int begin = random.Next(0, first.Path.Length - 1);
            int end = random.Next(begin + 1, first.Path.Length);

            List<int> childPath = first.Path.Skip(begin).Take(end - begin).ToList();
            for (int i = begin + 1; childPath.Count < second.Path.Length; i++)
            {
                if (i == second.Path.Length) i = 0;

                if (childPath.Contains(second.Path[i])) continue;
                childPath.Add(second.Path[i]);
            }

            var resPath = childPath.ToArray();
            int? cost = CalculatePathCost(matrix, resPath);
            if (cost is null) continue;

            individual = new(resPath, cost.Value);

        } while (individual is null);

        return individual;
    }



    private void DoMutataions(AdjMatrix matrix, List<Individual> population)
    {
        for (int i = 0; i < population.Count; i++)
        {
            double prob = random.NextDouble();
            if (prob <= MutationChance)
            {
                switch (MutationType)
                {
                    case MutationType.INVERSION:
                        MutateUsingInverse(matrix, population[i]);
                        break;
                    case MutationType.TRANSPOSITION:
                        MutateUsingTranspostion(matrix, population[i]);
                        break;
                    case MutationType.INSERTION:
                        MutateUsingInsertion(matrix, population[i]);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }

    private void MutateUsingTranspostion(AdjMatrix matrix, Individual individual)
    {
        int? newPathCost;
        int[] newPath = new int[individual.Path.Length]; 
        do
        {
            individual.Path.CopyTo(newPath, 0);
            int first = random.Next(0, individual.Path.Length);
            int second;
            do
            {
                second = random.Next(0, individual.Path.Length);
            } while (second == first);

            Utilites.SwapArrayElementsAtIndex(newPath, first, second);
            newPathCost = CalculatePathCost(matrix, newPath);
        } while (newPathCost is null);

        individual.Path = newPath;
        individual.Cost = newPathCost.Value;
    }

    private void MutateUsingInverse(AdjMatrix matrix, Individual individual)
    {
        int[] newPath;
        int? newPathCost;
        do
        {
            int firstIndex = random.Next(0, individual.Path.Length - 1);
            int secondIndex = random.Next(firstIndex + 1, individual.Path.Length);

            newPath = new int[individual.Path.Length];

            for (int i = 0; i < individual.Path.Length; i++)
            {
                if (i >= firstIndex && i <= secondIndex)
                {
                    newPath[i] = individual.Path[secondIndex - (i - firstIndex)];
                }
                else
                {
                    newPath[i] = individual.Path[i];
                }
            }

            newPathCost = CalculatePathCost(matrix, newPath);
        } while (newPathCost is null);

        individual.Path = newPath;
        individual.Cost = newPathCost.Value;
    }    

    private void MutateUsingInsertion(AdjMatrix matrix, Individual individual)
    {
        int? newCost;
        List<int> newPath = new(individual.Path);

        do
        {
            int fromPos = random.Next(0, newPath.Count());
            int toPos;

            int tmp = newPath[fromPos];
            newPath.RemoveAt(fromPos);

            do
            {
                toPos = random.Next(newPath.Count());
            } while (toPos == fromPos);

            newPath.Insert(toPos, tmp);

            newCost = CalculatePathCost(matrix, newPath.ToArray());

        } while (newCost is null);

        individual.Path = newPath.ToArray();
        individual.Cost = newCost.Value;
    }


    /// <summary>
    /// Closes the cycle in the given path to create a Hamilton cycle.
    /// </summary>
    /// <param name="path">The path to close the cycle.</param>
    private void CloseCycleInPath(ref int[] path)
    {
        Array.Resize(ref path, path.Length);
        path[path.Length - 1] = path[0];
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



    internal class Individual
    {
        internal int[] Path = null!;
        internal int Cost;
        //internal double Fitness => 1.0 / ((double)Cost + 1);

        public Individual(int[] path, int cost)
        {
            this.Path = path;
            this.Cost = cost;
        }
    }
}
