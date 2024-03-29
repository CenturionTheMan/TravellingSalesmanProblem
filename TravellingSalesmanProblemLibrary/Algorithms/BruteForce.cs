﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public class BruteForce : ITSPAlgorithm
{
    public string AlgorithmName => "Brute Force";

    public string AlgorithmDetailedName => "BruteForce";

    public BruteForce()
    {

    }

    /// <summary>
    /// Calculates the best path cost using the brute-force algorithm for a given adjacency matrix.
    /// </summary>
    /// <param name="matrix">The AdjMatrix (adjency matrix) containing vertices and distances.</param>
    /// <returns>
    /// A tuple containing the best path as an array of vertex indices and the total cost of the path.
    /// Returns null if no valid path is found.
    /// </returns>
    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        List<int[]> permutations = GenerateNumbersPermutations(0, matrix.GetMatrixSize - 1, cancellationToken);
        var best = FindBestPath(permutations, matrix, cancellationToken);

        return best;
    }

    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix)
    {
        return CalculateBestPath(matrix, CancellationToken.None);
    }


    /// <summary>
    /// Generates all possible permutations of numbers within the specified range.
    /// </summary>
    /// <param name="minNumber">The minimum number in the range (inclusive).</param>
    /// <param name="maxNumber">The maximum number in the range (inclusive).</param>
    /// <returns>
    /// A list of integer arrays, each representing a unique permutation of numbers.
    /// </returns>
    private List<int[]> GenerateNumbersPermutations(int minNumber, int maxNumber, CancellationToken cancellationToken)
    {
        List<int> numbers = new();
        for (int i = minNumber; i <= maxNumber; i++)
        {
            numbers.Add(i);
        }

        List<int[]> permutations = new();
        GenerateNumberPermutationsRecursively(new List<int>(), numbers, ref permutations, cancellationToken);

        return permutations;
    }

    /// <summary>
    /// Finds the best path among a list of paths in a given AdjMatrix.
    /// </summary>
    /// <param name="paths">A list of integer arrays representing different paths.</param>
    /// <param name="map">The AdjMatrix representing the vertices and distances between them (Adjency Matrix).</param>
    /// <returns>
    /// A tuple containing the best path (as an array of vertex indices) and its cost.
    /// If no valid path is found, returns null.
    /// </returns>
    private (int[] path, double cost)? FindBestPath(List<int[]> paths, AdjMatrix map, CancellationToken cancellationToken)
    {
        double bestCost = double.MaxValue;
        int[]? bestPath = null;

        foreach (var path in paths)
        {
            if (cancellationToken.IsCancellationRequested) return null;


            var cost = CalculatePathCost(path, map);
            if (cost == null) continue;

            if (cost < bestCost)
            {
                bestCost = cost.Value;
                bestPath = path;
            }
        }

        return bestPath == null ? null : (bestPath, bestCost);
    }

    /// <summary>
    /// Calculates the cost of a given path in a AdjMatrix.
    /// </summary>
    /// <param name="path">An array of vertex indices representing the path to calculate the cost for.</param>
    /// <param name="map">The AdjMatrix representing the vertices and distances between them.</param>
    /// <returns>
    /// The total cost of the path if it's valid, or null if the path contains invalid vertex index.
    /// </returns>
    private double? CalculatePathCost(int[] path, AdjMatrix map)
    {
        double sum = 0;
        for (int i = 0; i < path.Length - 1; i++)
        {
            int endIndex = i + 1;

            if (map.TryGetDistance(path[i], path[endIndex], out double dis))
            {
                sum += dis;
            }
            else
            {
                return null;
            }
        }
        return sum;
    }

    /// <summary>
    /// Recursively generates permutations of numbers from a list.
    /// </summary>
    /// <param name="numbersOut">The list of numbers in the current permutation being constructed.</param>
    /// <param name="numbersIn">The list of available numbers to choose from.</param>
    /// <param name="result">The list where permutations are stored.</param>
    private void GenerateNumberPermutationsRecursively(List<int> numbersOut, List<int> numbersIn, ref List<int[]> result, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        if (numbersIn.Count == 0)
        {

            if (numbersOut.Count > 0)
            {
                numbersOut.Add(numbersOut[0]);
                result.Add(numbersOut.ToArray());
                numbersOut.RemoveAt(numbersOut.Count - 1);
            }
        }
        else
        {
            foreach (var number in numbersIn)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                numbersOut.Add(number);
                List<int> newNumbersIn = numbersIn.FindAll(x => x != number);
                GenerateNumberPermutationsRecursively(numbersOut, newNumbersIn, ref result, cancellationToken);
                numbersOut.Remove(number);
            }
        }
    }

    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<double?, long> toInvoke)
    {
        throw new NotImplementedException();
    }

    public void UnSubscribeShowCurrentSolutionInIntervals(Action<double?, long> toInvoke)
    {
        throw new NotImplementedException();
    }

    
}
