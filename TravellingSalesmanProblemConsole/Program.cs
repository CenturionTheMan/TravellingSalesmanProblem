using System.Diagnostics;
using TravellingSalesmanProblemLibrary;
using TravellingSalesmanProblemLibrary.Algorithms;
using TravellingSalesmanProblemLibrary.Testers;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    const string TEST_RESULT_DIRECTORY = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\";

    private static string pathForMatrix = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\matrix_6x6.txt";
    private static string pathForm170Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv170.atsp";
    private static string pathForm403Matrix = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\rbg403.atsp";
    private static string pathForm47Matrix = "G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv47.atsp";


    private static int SEED = 123;


    public static void Main()
    {
        //var matrix = FilesHandler.LoadAdjMatrixFromFile(pathForMatrix);
        //var matrix = new AdjMatrix(new int?[,] {
        //    { null, 1,1,2},
        //    { 2, null,4,4},
        //    { 2,4,null,5},
        //    { 5,3,6,null}});
        //BranchAndBound bab = new BranchAndBound(BranchAndBound.SearchType.DEEP);



        //DynamicProgramming dp = new DynamicProgramming();
        //var res2 = dp.CalculateBestPath(matrix);
        //Console.WriteLine(res2.ToStringCustom());

        //var matrix = FilesHandler.LoadAdjMatrixFromFile(pathForm170Matrix);
        //if (matrix == null) throw new ArgumentNullException();
        //SimulatedAnnealing simulatedAnnealing = new(500, 0.998, 1500, 15, 100000);
        //var res2 = simulatedAnnealing.CalculateBestPath(matrix);
        //Console.WriteLine(res2.ToStringCustom());

        //var res1 = bab.CalculateBestPath(matrix);
        //Console.WriteLine(res1.ToStringCustom());

        //return;

        //Random rnd = new();
        //SEED = rnd.Next(0,100000);

        //TestTime();
        //TestMemory();
        //TestPercentFinished();
        //Console.WriteLine("DONE");
        //Console.WriteLine(SEED);

        DefinedMatrixErrorTest();
        Console.ReadKey();
    }

    public static void DefinedMatrixErrorTest()
    {
        new DefinedMatrixErrorTest(new SimulatedAnnealing(500, 0.995, 1000, 100, 100000),
            "ftv74", pathForm47Matrix, 
            1776).RunTest(TEST_RESULT_DIRECTORY);

        new DefinedMatrixErrorTest(new SimulatedAnnealing(500, 0.995, 1000, 100, 100000),
            "ftv170", pathForm170Matrix,
            2755).RunTest(TEST_RESULT_DIRECTORY);

        new DefinedMatrixErrorTest(new SimulatedAnnealing(500, 0.995, 1000, 100, 100000),
            "rgb403", pathForm403Matrix,
            2465).RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestTime()
    {
        //TimePerformanceTester ptBruteForce = new(new BruteForce());
        //ptBruteForce.SetMatrixDistances(10, 1000).SetMatrixSizeForTest(2, 12, 1).SetRepeatAmount(1, 100);
        //ptBruteForce.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester dpTester = new(new DynamicProgramming(), SEED);
        dpTester.SetMatrixSizeForTest(2, 20, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babLowCostTester = new(new BranchAndBound(BranchAndBound.SearchType.LOW_COST), SEED);
        babLowCostTester.SetMatrixSizeForTest(2, 20, 1);
        babLowCostTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babBFSTester = new(new BranchAndBound(BranchAndBound.SearchType.BREADTH), SEED);
        babBFSTester.SetMatrixSizeForTest(2, 11, 1);
        babBFSTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babDFSTester = new(new BranchAndBound(BranchAndBound.SearchType.DEEP), SEED);
        babDFSTester.SetMatrixSizeForTest(2, 20, 1);
        babDFSTester.RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestMemory()
    {
        MemoryUsageTester dpTester = new MemoryUsageTester(new DynamicProgramming(), SEED);
        dpTester.SetMatrixSizeForTest(2, 20, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTesterLC = new MemoryUsageTester(new BranchAndBound(BranchAndBound.SearchType.LOW_COST), SEED);
        babTesterLC.SetMatrixSizeForTest(2, 20, 1);
        babTesterLC.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTesterBFS = new MemoryUsageTester(new BranchAndBound(BranchAndBound.SearchType.BREADTH), SEED);
        babTesterBFS.SetMatrixSizeForTest(2, 11, 1);
        babTesterBFS.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTesterDFS = new MemoryUsageTester(new BranchAndBound(BranchAndBound.SearchType.DEEP), SEED);
        babTesterDFS.SetMatrixSizeForTest(2, 20, 1);
        babTesterDFS.RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestPercentFinished()
    {
        PercentFinishTester babLowCostTester = new(new BranchAndBound(BranchAndBound.SearchType.LOW_COST), SEED);
        babLowCostTester.SetMatrixSizeForTest(2, 25, 1);
        babLowCostTester.RunTest(TEST_RESULT_DIRECTORY);

        PercentFinishTester dpTester = new PercentFinishTester(new DynamicProgramming(), SEED);
        dpTester.SetMatrixSizeForTest(2, 25, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        PercentFinishTester babBFSTester = new(new BranchAndBound(BranchAndBound.SearchType.BREADTH), SEED);
        babBFSTester.SetMatrixSizeForTest(2, 25, 1);
        babBFSTester.RunTest(TEST_RESULT_DIRECTORY);

        PercentFinishTester babDFSTester = new(new BranchAndBound(BranchAndBound.SearchType.DEEP), SEED);
        babDFSTester.SetMatrixSizeForTest(2, 25, 1);
        babDFSTester.RunTest(TEST_RESULT_DIRECTORY);
    }
}

