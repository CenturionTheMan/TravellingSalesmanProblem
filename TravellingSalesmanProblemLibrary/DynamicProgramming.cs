using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public class DynamicProgramming : ITSPAlgorithm
{
    private const int START_NODE = 0;

    public string AlgorithName { get { return "DynamicProgramming"; } }

    /// <summary>
    /// Calculates the best path cost using the traveling salesman algorithm for a given adjacency matrix.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the graph.</param>
    /// <returns>The best path cost or null if it exceeds the limit of int.MaxValue.</returns>
    public int? CalculateBestPathCost(AdjMatrix matrix)
    {
        var maxMask = (ulong)Math.Pow(2, matrix.GetMatrixSize);

        if (maxMask > int.MaxValue) return null;

        var memoTable = new int?[matrix.GetMatrixSize, maxMask];
        uint endMask = (uint)(1 << matrix.GetMatrixSize) - 1;
        var result = SolveReq(matrix, 1, START_NODE, endMask, memoTable);
        return result;
    }

    

    /// <summary>
    /// Recursively solves the traveling salesman problem to find the shortest path.
    /// </summary>
    /// <param name="map">The adjacency matrix representing the graph.</param>
    /// <param name="mask">Visited vertexs as a bitmask.</param>
    /// <param name="fromVertex">The starting vertex for the current path segment.</param>
    /// <param name="endMask">The bitmask representing all vertexs visited.</param>
    /// <param name="memoTable">A memoization table to store intermediate results.</param>
    /// <returns>The shortest distance to complete the traveling salesman tour.</returns>
    private int SolveReq(AdjMatrix map, uint mask, int fromVertex, uint endMask, int?[,] memoTable)
    {
        //If mask idicates that all vertices were visited in current path, if so add cost for returning to start vertex  
        if (mask == endMask) return map.GetDistance((int)fromVertex, START_NODE);

        //Check if given scenario was not already sloved, if so take result from table
        if (memoTable[fromVertex, mask].HasValue)
        {
            return memoTable[fromVertex, mask].Value;
        }

        int res = int.MaxValue;

        for (int nextVertex = 0; nextVertex < map.GetMatrixSize; nextVertex++)
        {
            //check if given vertex was already visited in given path
            if (CheckIfGivenVertexWasVisitedInGivenMask(mask, nextVertex)) continue;
            if (!map.TryGetDistance((int)fromVertex, nextVertex, out int tmpRes)) continue;

            //create new bitmask for path where nextVertex is included
            var tmpMask = SetBitInMask(mask, nextVertex);
            tmpRes += SolveReq(map, tmpMask, nextVertex, endMask, memoTable);
            if(tmpRes < res)
            {
                res = tmpRes;
            }
        }

        memoTable[fromVertex, mask] = res;
        return res;
    }

    /// <summary>
    /// Sets a specific bit at the given index in a bitmask.
    /// </summary>
    /// <param name="mask">The original bitmask where the bit will be set.</param>
    /// <param name="bitIndex">The index of the bit to set (0-based).</param>
    /// <returns>The bitmask with the specified bit set to 1 at the given index.</returns>
    private uint SetBitInMask(uint mask, int bitIndex)
    {
        return (mask | (uint)(1 << bitIndex));
    }

    /// <summary>
    /// Checks if a specific vertex is visited in a given bitmask.
    /// </summary>
    /// <param name="mask">The bitmask representing visited vertices.</param>
    /// <param name="vertex">The vertex to check for in the bitmask.</param>
    /// <returns>True if the vertex is visited in the bitmask, otherwise false.</returns>
    private bool CheckIfGivenVertexWasVisitedInGivenMask(uint mask, int vertex)
    {
        var bitVertex = (1 << vertex);
        var val = (mask & bitVertex);
        return val != 0;
    }

   
}
