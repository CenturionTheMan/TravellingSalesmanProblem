using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public interface ITSPAlgorithm
{
    public string AlgorithmName { get; }
    public string AlgorithmDetailedName { get; }

    /// <summary>
    /// Finds the best solution for Traveling Salesman Problem.
    /// </summary>
    /// <param name="matrix">Adjency matrix.</param>
    /// <param name="CancellationToken">Token used for cancelling algorithm durling runtime</param>
    /// <returns>
    /// Returns best path and cost, or null if no valid path is found.
    /// </returns>
    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken CancellationToken);

    /// Finds the best solution for Traveling Salesman Problem.
    /// </summary>
    /// <param name="matrix">Adjency matrix.</param>
    /// <returns>
    /// Returns best path and cost, or null if no valid path is found.
    /// </returns>
    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix);

    /// <summary>
    /// Sets up a periodic interval for showing the current solution during the algorithm execution.
    /// </summary>
    /// <param name="intervalLength">The interval length for displaying the current solution.</param>
    /// <param name="toInvoke">The action to invoke for displaying the current solution.</param>
    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<double?, long> toInvoke);

    /// <summary>
    /// Unsubscribes an action from the event handler for showing the current solution in intervals.
    /// </summary>
    /// <param name="toInvoke">The action to unsubscribe.</param>
    public void UnSubscribeShowCurrentSolutionInIntervals(Action<double?, long> toInvoke);
}
