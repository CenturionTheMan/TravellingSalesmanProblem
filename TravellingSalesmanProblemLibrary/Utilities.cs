using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public static class Utilities
{
    /// <summary>
    /// Swaps elements at the specified indexes in the given array.
    /// </summary>
    /// <param name="array">The array in which to swap elements.</param>
    /// <param name="firstIndex">The index of the first element to swap.</param>
    /// <param name="secondIndex">The index of the second element to swap.</param>
    public static void SwapArrayElementsAtIndex<T>(T[] array, int firstIndex, int secondIndex)
    {
        T tmp = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = tmp;
    }

    public static T[] SwapElements<T>(this T[] array, int firstIndex, int secondIndex)
    {
        var tmp = new List<T>(array).ToArray();
        SwapArrayElementsAtIndex(tmp, firstIndex, secondIndex);
        return tmp;
    }

    public static void DoAfterTime(Action toDo, TimeSpan waitAmount)
    {
        var tmp = new Thread(() => { 
            Thread.Sleep(waitAmount);
            toDo();
        });
        tmp.Start();
    }
   
    /// <summary>
    /// Converts a tuple representing a path and its cost into a formatted string.
    /// </summary>
    /// <param name="result">The tuple containing the path and cost.</param>
    /// <returns>A formatted string representation of the path and its cost.</returns>
    public static string ToStringCustom(this (int[] path, double cost)? result)
    {
        if(result.HasValue == false)
        {
            return "NULL";
        }

        StringBuilder stringBuilder = new();

        stringBuilder.Append("Path: ");
        foreach (var item in result.Value.path)
        {
            stringBuilder.Append(item + " ");
        }
        stringBuilder.AppendLine($"\nCost: {result.Value.cost.ToString("0.0")}");

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Converts an integer array to a path string representation.
    /// </summary>
    /// <param name="path">The integer array representing a path.</param>
    /// <returns>
    /// A string representation of the path, or "Null" if the input array is null.
    /// </returns>
    public static string ArrayToPathString(this int[]? path)
    {
        if (path == null) return "Null";
        string pathStr = "";
        foreach (var item in path)
        {
            pathStr += item + "->";
        }
        if(path.Length > 0)
        {
            pathStr = pathStr.Remove(pathStr.Length - 2, 2);
        }
        return pathStr;
    }

    /// <summary>
    /// Calculates the factorial of a given integer.
    /// </summary>
    /// <param name="n">The integer for which to calculate the factorial.</param>
    /// <returns>The factorial of the input integer.</returns>
    public static long Factorial(int n)
    {
        if (n == 0 || n == 1) return 1;

        long sum = 1;
        for (; n > 1; n--)
        {
            sum *= n;
        }
        return sum;
    }

    public static double Median(this IEnumerable<double> source)
    {
        int count = source.Count();
        source = source.OrderBy(x => x);
        double median = source.ElementAt(count / 2) + source.ElementAt((count - 1) / 2);
        return median / 2;
    }
}
