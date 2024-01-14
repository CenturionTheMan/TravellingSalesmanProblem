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

    public Action<string>? OnAlgorithmShowInfo;

    public readonly int PopulationSize;
    public readonly double CrossoverChance;
    public readonly double MutationChance;
    public readonly MutationType @MutationType;
    public readonly CrossoverType @CrossoverType;
    public readonly int? GenerationsWithoutImprovement;

    private double? bestCostYet = null;
    
    private readonly Random random = new();
    private TimeSpan intervalLength;
    private Action<double?, long>? onIntervalShowCurrentSolution;


    /// <summary>
    /// Represents a genetic algorithm for solving the Travelling Salesman Problem.
    /// </summary>
    /// <param name="populationSize">The size of the population.</param>
    /// <param name="crossoverType">The type of crossover used in the algorithm.</param>
    /// <param name="crossChance">The probability of crossover occurring.</param>
    /// <param name="mutationType">The type of mutation used in the algorithm.</param>
    /// <param name="mutationChance">The probability of mutation occurring.</param>
    /// <param name="generationsWithoutImprovement">The number of generations without improvement before stopping the algorithm.</param>
    public GeneticAlgorithm(int populationSize, CrossoverType crossoverType, double crossChance, MutationType mutationType, double mutationChance, int? generationsWithoutImprovement)
    {
        populationSize = Math.Clamp(populationSize, 2, int.MaxValue);
        crossChance = Math.Clamp(crossChance, 0, 1);
        mutationChance = Math.Clamp(mutationChance, 0, 1);

        this.PopulationSize = populationSize;
        this.CrossoverChance = crossChance;
        this.MutationChance = mutationChance;
        this.MutationType = mutationType;
        this.CrossoverType = crossoverType;
        this.GenerationsWithoutImprovement = generationsWithoutImprovement;

    }

    #region SHOW INFO IN INTERVALS

    /// <summary>
    /// Sets a callback function to be invoked at specified intervals to show the current solution.
    /// </summary>
    /// <param name="intervalLength">The length of the interval between invocations.</param>
    /// <param name="toInvoke">The callback function to be invoked.</param>
    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<double?, long> toInvoke)
    {
        this.intervalLength = intervalLength;
        onIntervalShowCurrentSolution += toInvoke;
    }

    /// <summary>
    /// Unsubscribes a method from the event that triggers the display of the current solution at specified intervals.
    /// </summary>
    /// <param name="toInvoke">The method to be unsubscribed.</param>
    public void UnSubscribeShowCurrentSolutionInIntervals(Action<double?, long> toInvoke) => onIntervalShowCurrentSolution -= toInvoke;

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

    /// <summary>
    /// Calculates the best path using a genetic algorithm.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the graph.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A tuple containing the best path and its cost, or null if the operation was unsuccessful.</returns>
    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        return RunAlgorithm(matrix, cancellationToken);
    }

    /// <summary>
    /// Calculates the best path using a genetic algorithm.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the graph.</param>
    /// <returns>A tuple containing the best path and its cost, or null if the operation was unsuccessful.</returns>
    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix)
    {
        return CalculateBestPath(matrix, CancellationToken.None);
    }

    /// <summary>
    /// Displays a message and invokes the OnAlgorithmShowInfo event.
    /// </summary>
    /// <param name="message">The message to be displayed.</param>
    private void ShowMessage(string message)
    {
        //Console.Write(message);
        OnAlgorithmShowInfo?.Invoke(message);
    }


    /// <summary>
    /// Runs the genetic algorithm to find the optimal path for the traveling salesman problem.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the distances between cities.</param>
    /// <param name="cancellationToken">The cancellation token to stop the algorithm execution.</param>
    /// <returns>
    /// A tuple containing the optimal path and its cost if a solution is found, or null if no solution is found.
    /// </returns>
    private (int[] path, double cost)? RunAlgorithm(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        List<Individual> population = InitializePopulation(matrix);
        Individual tmp = population.MinBy(x => x.Cost)!;

        (int[] path, double cost) bestEver = (tmp.Path, tmp.Cost);
        
        bestCostYet = bestEver.cost;

        int generationCounter = 0;
        int costRepAmount = 0;

        CancellationTokenSource cancellationTokenSource = new();
        if (onIntervalShowCurrentSolution != null) 
            CallShowSolutionInIntervals(cancellationTokenSource.Token);

        while (cancellationToken.IsCancellationRequested == false && 
            (GenerationsWithoutImprovement.HasValue == false || costRepAmount < GenerationsWithoutImprovement.Value))
        {
            population = SelectionTournament(population); //select best genes
            population = CreateOffspring(matrix, population); //crossover
            DoMutations(matrix, population); //mutation

            var currentBest = population.MinBy(x => x.Cost)!;

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

            generationCounter++;


            string costBreakPerc = GenerationsWithoutImprovement is null? "-" : ((double)(100 * costRepAmount) / (double)GenerationsWithoutImprovement).ToString("0.00") + "%";
            ShowMessage($"Best: {bestEver.cost} || Current: {currentBest.Cost} || Generation: {generationCounter} || No improvement: {costBreakPerc}\n");
        }

        cancellationTokenSource.Cancel();
        CloseCycleInPath(ref bestEver.path);
        return bestEver;
    }

    /// <summary>
    /// Initializes the population for the genetic algorithm.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <returns>A list of individuals representing the initial population.</returns>
    private List<Individual> InitializePopulation(AdjMatrix matrix)
    {
        List<int> allNumbers = new();
        for (int i = 0; i < matrix.GetMatrixSize; i++)
        {
            allNumbers.Add(i);
        }

        List<Individual> population = new();

        while (population.Count < PopulationSize)
        {
            allNumbers = allNumbers.OrderBy(x => random.Next()).ToList();

            int[] path = allNumbers.ToArray();
            double? cost = CalculatePathCost(matrix, path);
            if (cost == null) continue;
            
            Individual first = new(path, cost.Value);
            population.Add(first);
        }

        return population;
    }

    /// <summary>
    /// Performs tournament selection to select individuals from the population.
    /// </summary>
    /// <param name="population">The initial population.</param>
    /// <returns>A list of selected individuals.</returns>
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

            var best = tmp.MinBy(x => x.Cost)!;
            selection.Add(best);
        }

        return selection;
    }

    /// <summary>
    /// Creates offspring
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <param name="parents">The list of parent individuals.</param>
    /// <returns>A list of offspring individuals.</returns>
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

            if (prob <= CrossoverChance)
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

    /// <summary>
    /// Creates a child using the PMX crossover method.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <param name="first">The first parent individual.</param>
    /// <param name="second">The second parent individual.</param>
    /// <returns>A new individual representing the child.</returns>
    private Individual CreateChildPMX(AdjMatrix matrix, Individual first, Individual second)
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

        int[] newPath = childPath.Select(x => x!.Value).ToArray();
        double? newCost = CalculatePathCost(matrix, newPath);
        if (newCost == null) 
            throw new Exception("Path cost could not be calculated!");

        return new Individual(newPath, newCost.Value);
    }

    /// <summary>
    /// Creates a child using OX crossover (Order Crossover) method.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the graph.</param>
    /// <param name="first">The first parent Individual.</param>
    /// <param name="second">The second parent Individual.</param>
    /// <returns>A new Individual representing the child.</returns>
    private Individual CreateChildOrder(AdjMatrix matrix, Individual first, Individual second)
    {
        int begin = random.Next(0, first.Path.Length - 1);
        int end = random.Next(begin + 1, first.Path.Length);

        List<int> childPath = first.Path.Skip(begin).Take(end - begin).ToList();
        for (int i = end + 1; childPath.Count < second.Path.Length; i++)
        {
            if (i == second.Path.Length) i = 0;

            if (childPath.Contains(second.Path[i])) continue;

            childPath.Add(second.Path[i]);
        }

        var resPath = childPath.ToArray();
        double? cost = CalculatePathCost(matrix, resPath);
        if (cost is null) 
            throw new Exception("Path cost could not be calculated!");

        Individual individual = new(resPath, cost.Value);
        return individual;
    }


    /// <summary>
    /// Performs mutations on the population based on the specified mutation type and chance.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem instance.</param>
    /// <param name="population">The list of individuals in the population.</param>
    private void DoMutations(AdjMatrix matrix, List<Individual> population)
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
                        MutateUsingTransposition(matrix, population[i]);
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

    /// <summary>
    /// Mutates the individual using transposition mutation.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the graph.</param>
    /// <param name="individual">The individual to be mutated.</param>
    private void MutateUsingTransposition(AdjMatrix matrix, Individual individual)
    {
        double? newPathCost;
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

            Utilities.SwapArrayElementsAtIndex(newPath, first, second);
            newPathCost = CalculatePathCost(matrix, newPath);
        } while (newPathCost is null);

        individual.Path = newPath;
        individual.Cost = newPathCost.Value;
    }

    /// <summary>
    /// Mutates the individual using the inverse mutation operator.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <param name="individual">The individual to be mutated.</param>
    private void MutateUsingInverse(AdjMatrix matrix, Individual individual)
    {
        int[] newPath;
        double? newPathCost;
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

    /// <summary>
    /// Mutates the individual using the insertion mutation operator.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <param name="individual">The individual to be mutated.</param>
    private void MutateUsingInsertion(AdjMatrix matrix, Individual individual)
    {
        double? newCost;
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
    private double? CalculatePathCost(AdjMatrix matrix, int[] path)
    {
        double sum = 0;
        for (int i = 0; i < path.Length - 1; i++)
        {
            int from = path[i];
            int to = path[i + 1];
            if (matrix.TryGetDistance(from, to, out double dis) == false) return null;
            sum += dis;
        }
        if (matrix.TryGetDistance(path[path.Length - 1], path[0], out double lastDis) == false) return null;
        sum += lastDis;
        return sum;
    }

    /// <summary>
    /// Represents an individual in the genetic algorithm population.
    /// </summary>
    internal class Individual
    {
        internal int[] Path = null!;
        internal double Cost;

        public Individual(int[] path, double cost)
        {
            this.Path = path;
            this.Cost = cost;
        }
    }
}
