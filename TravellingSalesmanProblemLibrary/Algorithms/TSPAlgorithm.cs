using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public abstract class TSPAlgorithm
{
    public abstract string AlgorithmName { get; }

    protected TSPAlgorithm()
    {
    }



    /// <summary>
    /// Finds the best solution for Traveling Salesman Problem.
    /// </summary>
    /// <param name="matrix">Adjency matrix.</param>
    /// <param name="CancellationToken">Token used for cancelling algorithm durling runtime</param>
    /// <returns>
    /// Returns best path and cost, or null if no valid path is found.
    /// </returns>
    public abstract (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken CancellationToken);

    /// <summary>
    /// Finds the best solution for Traveling Salesman Problem.
    /// </summary>
    /// <param name="matrix">Adjency matrix.</param>
    /// <returns>
    /// Returns best path and cost, or null if no valid path is found.
    /// </returns>
    public (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix)
    {
        return CalculateBestPath(matrix, new CancellationToken());
    }



    //public bool IsKind(AlgorithmKind kind)
    //{
    //    if(this is BruteForce && kind == AlgorithmKind.BRUTE_FORCE)
    //    {
    //        return true;
    //    }

    //    if (this is DynamicProgramming && kind == AlgorithmKind.DYNAMIC_PROGRAMMING)
    //    {
    //        return true;
    //    }

    //    if (this is BranchAndBound && kind == AlgorithmKind.BRANCH_AND_BOUND)
    //    {
    //        return true;
    //    }


    //    return false;
    //}
}
