using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    public static void Main()
    {
        WorldMap map = new(6);

        map.SetDistance(0, 1, 16, false);
        map.SetDistance(1, 2, 21, false);
        map.SetDistance(2, 3, 12, false);
        map.SetDistance(3, 1, 9, false);
        map.SetDistance(3, 4, 15, true);
        map.SetDistance(4, 5, 16, true);
        map.SetDistance(5, 0, 34, false);
        map.SetDistance(5, 2, 7, false);

        var bestPath = DynamicProgramming.GetBestPath(map);

        Console.WriteLine(bestPath);
    }
}

