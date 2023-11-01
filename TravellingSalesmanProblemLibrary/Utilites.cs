using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public static class Utilites
{
   
    /// <summary>
    /// Converts a tuple representing a path and its cost into a formatted string.
    /// </summary>
    /// <param name="result">The tuple containing the path and cost.</param>
    /// <returns>A formatted string representation of the path and its cost.</returns>
    public static string ToStringCustom(this (int[] path, int cost)? result)
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
        stringBuilder.AppendLine($"\nCost: {result.Value.cost}");

        return stringBuilder.ToString();
    }




    
}
