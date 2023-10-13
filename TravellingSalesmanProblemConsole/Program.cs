using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    public static void Main()
    {
        //AdjMatrix matrix = new(15, 1, 100);

        var matrix = FilesHandler.LoadAdjMatrixFromFile("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv47.atsp");
        var bestPath = DynamicProgramming.GetBestPath(matrix);

        Console.WriteLine(bestPath);
    }
}

