using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public class BruteForceTSP : ITSPAlgorithm
{
    public string AlgorithName { get { return "Brute Force"; } }

    /// <summary>
    /// Calculates the best path cost using the brute-force algorithm for a given adjacency matrix.
    /// </summary>
    /// <param name="map">The adjacency matrix representing the graph.</param>
    /// <returns>The best path cost or null if no valid path is found.</returns>
    public int? CalculateBestPathCost(AdjMatrix map)
    {
        var res = GetBestPath(map);
        if (res == null) return null;
        return res.Value.cost;
    }


    /// <summary>
    /// Calculates the best path cost using the brute-force algorithm for a given adjacency matrix.
    /// </summary>
    /// <param name="map">The AdjMatrix (adjency matrix) containing vertices and distances.</param>
    /// <returns>
    /// A tuple containing the best path as an array of vertex indices and the total cost of the path.
    /// Returns null if no valid path is found.
    /// </returns>
    public (int[] path, int cost)? GetBestPath(AdjMatrix map)
    {
        List<int[]> permutations = GenerateNumbersPermutations(0, map.GetMatrixSize - 1);
        var best = FindBestPath(permutations, map);

        return best;
    }

    /// <summary>
    /// Generates all possible permutations of numbers within the specified range.
    /// </summary>
    /// <param name="minNumber">The minimum number in the range (inclusive).</param>
    /// <param name="maxNumber">The maximum number in the range (inclusive).</param>
    /// <returns>
    /// A list of integer arrays, each representing a unique permutation of numbers.
    /// </returns>
    private List<int[]> GenerateNumbersPermutations(int minNumber, int maxNumber)
    {
        List<int> numbers = new();
        for (int i = minNumber; i <= maxNumber; i++)
        {
            numbers.Add(i);
        }

        List<int[]> permutations = new();
        GenerateNumberPermutationsRecursively(new List<int>(), numbers, ref permutations);

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
    private (int[] path, int cost)? FindBestPath(List<int[]> paths, AdjMatrix map)
    {
        int bestCost = int.MaxValue;
        int[]? bestPath = null;

        foreach (var path in paths)
        {
            var cost = CalculatePathCost(path, map);
            if (cost == null) continue;

            if (cost < bestCost)
            {
                bestCost = cost.Value;
                bestPath = path;
            }
        }

        return bestPath ==null? null : (bestPath, bestCost);
    }

    /// <summary>
    /// Calculates the cost of a given path in a AdjMatrix.
    /// </summary>
    /// <param name="path">An array of vertex indices representing the path to calculate the cost for.</param>
    /// <param name="map">The AdjMatrix representing the vertices and distances between them.</param>
    /// <returns>
    /// The total cost of the path if it's valid, or null if the path contains invalid vertex index.
    /// </returns>
    private int? CalculatePathCost(int[] path, AdjMatrix map)
    {
        int sum = 0;
        for (int i = 0; i < path.Length - 1; i++)
        {
            int endIndex = i + 1;

            if (map.TryGetDistance(path[i], path[endIndex], out int dis))
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
    private void GenerateNumberPermutationsRecursively(List<int> numbersOut, List<int> numbersIn, ref List<int[]> result)
    {
        if(numbersIn.Count == 0)
        {
            if(numbersOut.Count > 0)
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
                numbersOut.Add(number);
                List<int> newNumbersIn = numbersIn.FindAll(x => x != number);
                GenerateNumberPermutationsRecursively(numbersOut, newNumbersIn, ref result);
                numbersOut.Remove(number);
            }
        }
    }

    
}
