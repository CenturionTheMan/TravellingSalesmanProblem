using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public static class DynamicProgramming
{
    private const int START_NODE = 0;

    /// <summary>
    /// Finds the best solution for Sales Map Problem withon given WorldMap using a dynamic programming approach.
    /// </summary>
    /// <param name="map">The WorldMap (adjency matrix) containing cities and distances.</param>
    /// <returns>
    /// A tuple containing the best path as an array of city indices and the total cost of the path.
    /// Returns null if no valid path is found.
    /// </returns>
    public static (int[] path, int cost)? GetBestPath(WorldMap map)
    {
        throw new NotImplementedException();   
    }


    public static int Solve(WorldMap map)
    {
        var memoTable = new int?[map.GetCitiesAmount, (uint)Math.Pow(2, map.GetCitiesAmount)];
        uint endMask = (uint)(1 << map.GetCitiesAmount) - 1;
        var result = SolveReq(map, 1, START_NODE, endMask, memoTable);
        return result;
    }

    private static int SolveReq(WorldMap map, uint mask, int fromNode, uint endMask, int?[,] memoTable)
    {
        if (mask == endMask) return map.GetDistance((int)fromNode, START_NODE);

        if (memoTable[fromNode, mask].HasValue)
        {
            return memoTable[fromNode, mask].Value;
        }

        int res = int.MaxValue;

        for (int nextNode = 0; nextNode < map.GetCitiesAmount; nextNode++)
        {
            if(CheckIfGivenNodeWasVisitedInGivenMask(mask, nextNode) == false)
            {
                int tmpRes = map.GetDistance((int)fromNode, nextNode) + SolveReq(map, SetBitInMask(mask, nextNode), nextNode, endMask);
                if(tmpRes < res)
                {
                    res = tmpRes;
                }
            }
        }

        return res;
    }

    private static uint SetBitInMask(uint mask, int bitIdex)
    {
        return (mask | (uint)(1 << bitIdex));
    }

    private static bool CheckIfGivenNodeWasVisitedInGivenMask(uint mask, int node)
    {
        return (mask & (1 << node)) == 0;
    }

}
