using System.Diagnostics;
using TravellingSalesmanProblemLibrary;
using TravellingSalesmanProblemLibrary.Testers;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    const string TEST_RESULT_DIRECTORY = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\";

    private static string pathForMatrix = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\matrix_6x6.txt";

    public static void Main()
    {
        //var matrix = FilesHandler.LoadAdjMatrixFromFile(pathForMatrix);
        //BranchAndBound bab = new BranchAndBound(BranchAndBound.SearchType.DEEP);
        
        //var res = bab.CalculateBestPath(matrix);
        //Console.WriteLine(res.ToStringCustom());

        //DynamicProgramming dp = new DynamicProgramming();
        //var res2 = dp.CalculateBestPath(matrix);
        //Console.WriteLine(res2.ToStringCustom());

        //return;

        TestTime();
        TestMemory();
        Console.WriteLine("DONE");
        Console.ReadKey();
    }


    public static void TestTime()
    {
        //TimePerformanceTester ptBruteForce = new(new BruteForce());
        //ptBruteForce.SetMatrixDistances(10, 1000).SetMatrixSizeForTest(2, 12, 1).SetRepeatAmount(1, 100);
        //ptBruteForce.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester dpTester = new(new DynamicProgramming());
        dpTester.SetMatrixSizeForTest(2, 20, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babLowCostTester = new(new BranchAndBound());
        babLowCostTester.SetMatrixSizeForTest(2, 20, 1);
        babLowCostTester.RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestMemory()
    {
        MemoryUsageTester dpTester = new MemoryUsageTester(new DynamicProgramming());
        dpTester.SetMatrixSizeForTest(2, 20, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTester = new MemoryUsageTester(new BranchAndBound());
        babTester.SetMatrixSizeForTest(2, 20, 1);
        babTester.RunTest(TEST_RESULT_DIRECTORY);
    }
}

