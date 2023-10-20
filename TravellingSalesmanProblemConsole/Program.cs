using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    public static void Main()
    {
        //AdjMatrix matrix = new(15, 1, 100);
        AdjMatrix? matrix = FilesHandler.LoadAdjMatrixFromFile("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\matrix_8x8.txt");

        Console.WriteLine(matrix);

        //var matrix = FilesHandler.LoadAdjMatrixFromFile("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\br17.atsp");
        DynamicProgramming dynamicProgramming = new();
        var bestPath = dynamicProgramming.CalculateBestPathCost(matrix);

        Console.WriteLine(bestPath);

        //Test();

        Console.WriteLine("DONE");
    }


    public static void Test()
    {
        //TimePerformanceTester ptBruteForce = new(new BruteForce());
        //ptBruteForce.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");

        TimePerformanceTester ptDynamicProgramming = new(new DynamicProgramming());
        ptDynamicProgramming.SetMatrixSizeForTest(10, 20, 1);
        ptDynamicProgramming.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");
    }
}

