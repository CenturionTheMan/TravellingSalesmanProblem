using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public static class BruteForce
{
    /// <summary>
    /// Finds the best solution for Sales Map Problem withon given WorldMap using a brute-force approach.
    /// </summary>
    /// <param name="map">The WorldMap (adjency matrix) containing cities and distances.</param>
    /// <returns>
    /// A tuple containing the best path as an array of city indices and the total cost of the path.
    /// Returns null if no valid path is found.
    /// </returns>
    public static (int[] path, int cost)? GetBestPath(WorldMap map)
    {
        List<int[]> permutations = GenerateNumbersPermutations(0, map.GetCitiesAmount - 1);
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
    private static List<int[]> GenerateNumbersPermutations(int minNumber, int maxNumber)
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
    /// Finds the best path among a list of paths in a given WorldMap.
    /// </summary>
    /// <param name="paths">A list of integer arrays representing different paths.</param>
    /// <param name="map">The WorldMap representing the cities and distances between them (Adjency Matrix).</param>
    /// <returns>
    /// A tuple containing the best path (as an array of city indices) and its cost.
    /// If no valid path is found, returns null.
    /// </returns>
    private static (int[] path, int cost)? FindBestPath(List<int[]> paths, WorldMap map)
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
    /// Calculates the cost of a given path in a WorldMap.
    /// </summary>
    /// <param name="path">An array of city indices representing the path to calculate the cost for.</param>
    /// <param name="map">The WorldMap representing the cities and distances between them.</param>
    /// <returns>
    /// The total cost of the path if it's valid, or null if the path contains invalid city index.
    /// </returns>
    private static int? CalculatePathCost(int[] path, WorldMap map)
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
    private static void GenerateNumberPermutationsRecursively(List<int> numbersOut, List<int> numbersIn, ref List<int[]> result)
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
