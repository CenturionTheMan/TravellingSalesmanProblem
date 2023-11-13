using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Algorithm;

public class DynamicProgramming : TSPAlgorithm
{
    private const int START_NODE = 0;

    private uint endMask;


    public DynamicProgramming(ref CancellationToken cancellationToken) : base(ref cancellationToken) { }
    public DynamicProgramming() : base() { }

    public override string AlgorithmName => "DynamicProgramming";


    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix)
    {
        if (matrix.GetMatrixSize > 32) return null;

        var maxMask = (ulong)Math.Pow(2, matrix.GetMatrixSize);

        var memoTable = new int?[matrix.GetMatrixSize, maxMask];
        var parentTable = new int[matrix.GetMatrixSize, maxMask];

        endMask = (uint)(1 << matrix.GetMatrixSize) - 1;
        uint beginMask = 1;

        var cost = SolveReq(matrix, beginMask, START_NODE, memoTable, parentTable);
        var path = RetrivePath(parentTable, beginMask, START_NODE, matrix.GetMatrixSize);

        return (path, cost);
    }

    /// <summary>
    /// Retrieves a path from a parent table
    /// </summary>
    /// <param name="parentTable">A table containing parent vertex information.</param>
    /// <param name="beginMask">The initial mask</param>
    /// <param name="beginVertex">The starting vertex for the path.</param>
    /// <returns>An array representing the retrieved path.</returns>
    private int[] RetrivePath(int[,] parentTable, uint beginMask, int beginVertex, int expectedPathLength)
    {
        uint mask = beginMask;
        int vertex = beginVertex;

        List<int> path = new();
        path.Add(beginVertex);

        for (int i = 0; i < expectedPathLength - 1; i++)
        {
            int prev = parentTable[vertex, mask];
            path.Add(prev);
            mask = SetBitInMask(mask, prev);
            vertex = prev;
        }

        path.Add(beginVertex);

        return path.ToArray();
    }


    /// <summary>
    /// Recursively solves the traveling salesman problem to find the shortest path.
    /// </summary>
    /// <param name="map">The adjacency matrix representing the graph.</param>
    /// <param name="mask">Visited vertexs as a bitmask.</param>
    /// <param name="fromVertex">The starting vertex for the current path segment.</param>
    /// <param name="memoTable">A memoization table to store intermediate results.</param>
    /// <param name="parentTable">A memoization table to store path.</param>
    /// <returns>The shortest distance to complete the traveling salesman tour.</returns>
    private int SolveReq(AdjMatrix map, uint mask, int fromVertex, int?[,] memoTable, int[,] parentTable)
    {
        if (CancellationToken.IsCancellationRequested)
        {
            return int.MaxValue;
        }

        //If mask idicates that all vertices were visited in current path, if so add cost for returning to start vertex  
        if (mask == endMask)
        {
            return map.GetDistance(fromVertex, START_NODE);
        }

        //Check if given scenario was not already sloved, if so take result from table
        if (memoTable[fromVertex, mask].HasValue)
        {
            return memoTable[fromVertex, mask].Value;
        }

        int res = int.MaxValue;

        for (int nextVertex = 0; nextVertex < map.GetMatrixSize; nextVertex++)
        {
            if (CancellationToken.IsCancellationRequested)
            {
                return int.MaxValue;
            }

            //check if given vertex was already visited in given path
            if (CheckIfGivenVertexWasVisitedInGivenMask(mask, nextVertex)) continue;
            if (!map.TryGetDistance(fromVertex, nextVertex, out int tmpRes)) continue;

            //create new bitmask for path where nextVertex is included
            var tmpMask = SetBitInMask(mask, nextVertex);
            tmpRes += SolveReq(map, tmpMask, nextVertex, memoTable, parentTable);

            if (tmpRes < res)
            {
                res = tmpRes;
                parentTable[fromVertex, mask] = nextVertex;
            }
        }

        memoTable[fromVertex, mask] = res;
        return res;
    }

    private int CaluclatePathCost(AdjMatrix matrix, List<int> path)
    {
        int sum = 0;
        for (int i = 0; i < path.Count - 1; i++)
        {
            sum += matrix.GetDistance(path[i], path[i + 1]);
        }
        return sum;
    }

    /// <summary>
    /// Sets a specific bit at the given index in a bitmask.
    /// </summary>
    /// <param name="mask">The original bitmask where the bit will be set.</param>
    /// <param name="bitIndex">The index of the bit to set (0-based).</param>
    /// <returns>The bitmask with the specified bit set to 1 at the given index.</returns>
    private uint SetBitInMask(uint mask, int bitIndex)
    {
        return mask | (uint)(1 << bitIndex);
    }

    /// <summary>
    /// Checks if a specific vertex is visited in a given bitmask.
    /// </summary>
    /// <param name="mask">The bitmask representing visited vertices.</param>
    /// <param name="vertex">The vertex to check for in the bitmask.</param>
    /// <returns>True if the vertex is visited in the bitmask, otherwise false.</returns>
    private bool CheckIfGivenVertexWasVisitedInGivenMask(uint mask, int vertex)
    {
        var bitVertex = 1 << vertex;
        var val = mask & bitVertex;
        return val != 0;
    }


}
