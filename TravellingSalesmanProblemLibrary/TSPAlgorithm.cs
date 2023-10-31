﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public abstract class TSPAlgorithm
{
    public abstract string AlgorithmName { get; }

    public CancellationToken CancellationToken
    {
        get;
        private set;
    }

    public TSPAlgorithm()
    {
        this.CancellationToken = new CancellationToken();
    }

    public TSPAlgorithm(ref CancellationToken cancellationToken)
    {
        this.CancellationToken = cancellationToken;
    }


    /// <summary>
    /// Finds the best solution for Sales Map Problem.
    /// </summary>
    /// <param name="matrix">Adjency matrix.</param>
    /// <param name="cancellationToken">Token for task cancellation</param>
    /// <returns>
    /// Returns best path cost or null if no valid path is found.
    /// </returns>
    public virtual int? CalculateBestPathCost(AdjMatrix matrix)
    {
        var tmp = CalculateBestPath(matrix);
        if (tmp == null) return null;
        return tmp.Value.cost;
    }

    /// <summary>
    /// Finds the best solution for Sales Map Problem.
    /// </summary>
    /// <param name="matrix">Adjency matrix.</param>
    /// <param name="cancellationToken">Token for task cancellation</param>
    /// <returns>
    /// Returns best path and cost or null if no valid path is found.
    /// </returns>
    public abstract (int[] path, int cost)? CalculateBestPath(AdjMatrix matrix);


    public bool IsKind(AlgorithmKind kind)
    {
        if(this is BruteForce && kind == AlgorithmKind.BRUTE_FORCE)
        {
            return true;
        }

        if (this is DynamicProgramming && kind == AlgorithmKind.DYNAMIC_PROGRAMMING)
        {
            return true;
        }

        if (this is BranchAndBound && kind == AlgorithmKind.BRANCH_AND_BOUND)
        {
            return true;
        }


        return false;
    }
}