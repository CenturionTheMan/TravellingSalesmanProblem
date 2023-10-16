using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    public static void Main()
    {
        //AdjMatrix matrix = new(15, 1, 100);

        //var matrix = FilesHandler.LoadAdjMatrixFromFile("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv47.atsp");
        //DynamicProgrammingTSP dynamicProgramming = new DynamicProgrammingTSP();
        //var bestPath = dynamicProgramming.CalculateBestPathCost(matrix);


        Test();

        Console.WriteLine("DONE");
    }


    public static void Test()
    {
        TimePerformanceTester ptBruteForce = new(new BruteForceTSP());
        ptBruteForce.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");

        TimePerformanceTester ptDynamicProgramming = new(new DynamicProgrammingTSP());
        ptDynamicProgramming.SetMatrixSizeForTest(10, 20, 1);
        ptDynamicProgramming.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");
    }
}

