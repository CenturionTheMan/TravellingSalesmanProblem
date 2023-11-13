using System.Diagnostics;
using TravellingSalesmanProblemLibrary;
using TravellingSalesmanProblemLibrary.Testers;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    const string DIRECTORY_PATH = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\";

    private static string pathForMatrix = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\matrix_6x6.txt";

    public static void Main()
    {
        var matrix = FilesHandler.LoadAdjMatrixFromFile(pathForMatrix);
        BranchAndBound bab = new BranchAndBound(BranchAndBound.SearchType.DEEP);
        
        
        var res = bab.CalculateBestPath(matrix);
        Console.WriteLine(res.ToStringCustom());

        DynamicProgramming dp = new DynamicProgramming();
        var res2 = dp.CalculateBestPath(matrix);
        Console.WriteLine(res2.ToStringCustom());




        return;

        //TestTime();
        TestMemory();
        Console.WriteLine("DONE");
        Console.ReadKey();
    }


    public static void TestTime()
    {
        //TimePerformanceTester ptBruteForce = new(new BruteForce());
        //ptBruteForce.SetMatrixDistances(10, 1000).SetMatrixSizeForTest(2, 12, 1).SetRepeatAmount(1, 100);
        //ptBruteForce.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");

        //TimePerformanceTester ptDynamicProgramming = new(new DynamicProgramming());
        //ptDynamicProgramming.SetMatrixSizeForTest(10, 20, 1);
        //ptDynamicProgramming.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");
    }

    public static void TestMemory()
    {
        //MemoryUsageTester babTester = new MemoryUsageTester(new BranchAndBound());
        //babTester.SetMatrixSizeForTest(2, 20, 1).SetRepeatAmount(1);
        //babTester.PerformMemoryTest(DIRECTORY_PATH);

        MemoryUsageTester dpTester = new MemoryUsageTester(new DynamicProgramming());
        dpTester.SetMatrixSizeForTest(2, 20, 1).SetRepeatAmount(1);
        dpTester.PerformMemoryTest(DIRECTORY_PATH);
    }
}

