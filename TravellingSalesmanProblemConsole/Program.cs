using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    public static void Main()
    {
        Test();
        Console.WriteLine("DONE");
        Console.ReadKey();
    }


    public static void Test()
    {
        TimePerformanceTester ptBruteForce = new(new BruteForce());
        ptBruteForce.SetMatrixDistances(10, 1000).SetMatrixSizeForTest(2, 11, 1).SetRepeatAmount(1, 100);
        ptBruteForce.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");

        //TimePerformanceTester ptDynamicProgramming = new(new DynamicProgramming());
        //ptDynamicProgramming.SetMatrixSizeForTest(10, 20, 1);
        //ptDynamicProgramming.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");
    }
}

