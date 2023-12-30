using System.Diagnostics;
using TravellingSalesmanProblemLibrary;
using TravellingSalesmanProblemLibrary.Testers;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    private const string TEST_RESULT_DIRECTORY = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\";

    private const string pathForMatrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\matrix_6x6.txt";
    private const string pathForm170Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv170.atsp";
    private const string pathForm403Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\rbg403.atsp";
    private const string pathForm47Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv47.atsp";


    private static int SEED = 123;

    /*  
     *  ZAPYTAJ O TESTY
     *  - czy test dla danych danych ma byc pwtarzany (ile razy) + jaka wartość ostateczna (średnia?)
     *  - Jeżeli jeden test dla zestawu danych -> jaki czas działania? Iloraz czasu iteracji dla symulowanego wyżarzania?
     *  - Czy trzeba się trzymać wartości początkowych z e-portalu
     *  
     */


    public static void Main()
    {
        //var tmp = new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.15, 100);
        //var matrix = FilesHandler.LoadAdjMatrixFromFile(pathForm403Matrix);
        ////var matrix = new AdjMatrix(6, 10, 100);

        //CancellationTokenSource cancellationTokenSource = new();
        //cancellationTokenSource.CancelAfter(new TimeSpan(0, 1, 0));
        //var res = tmp.CalculateBestPath(matrix, cancellationTokenSource.Token);
        //Console.WriteLine(res.ToStringCustom());


        GeneticAlghTests();
        Console.WriteLine("DONE!");
        Console.ReadKey();
    }

    public static void GeneticAlghTests()
    {
        Test47();
        Test170();
        Test403();



        void Test47()
        {
            //-----------------------------------------47

            // PMX - TRANS
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // PMX - INV
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // ORDER - TRANS
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // PMX - INV
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat47", pathForm47Matrix, 1776)
                .SetRunTime(new TimeSpan(0, 2, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");
        }


        void Test170()
        {
            //-----------------------------------------170

            // PMX - TRANS
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // PMX - INV
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // ORDER - TRANS
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // PMX - INV
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat170", pathForm170Matrix, 2755)
                .SetRunTime(new TimeSpan(0, 4, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");
        }


        void Test403()
        {
            //-----------------------------------------403

            // PMX - TRANS
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.PMX, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // PMX - INV
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.PMX, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // ORDER - TRANS
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.ORDER, 0.8, MutationType.TRANSPOSITION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");


            // PMX - INV
            new DefinedMatrixErrorTest(new GeneticAlgorithm(100, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop100");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(200, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop200");


            new DefinedMatrixErrorTest(new GeneticAlgorithm(300, CrossoverType.ORDER, 0.8, MutationType.INVERSION, 0.01, 100001),
                "mat403", pathForm403Matrix, 2465)
                .SetRunTime(new TimeSpan(0, 6, 0))
                .RunTest(TEST_RESULT_DIRECTORY, "pop300");
        }
    }

    public static void DefinedMatrixErrorTest()
    {
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(200, 0.995, 1000, 20, 100000, SimulatedAnnealing.CoolingFunction.GEOMETRIC),
        //    "ftv47", pathForm47Matrix,
        //    1776)
        //    .SetRunTime(new TimeSpan(0,2,0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(75, 0.05, 1000, 20, 100000, SimulatedAnnealing.CoolingFunction.LINEAR),
        //    "ftv47", pathForm47Matrix,
        //    1776)
        //    .SetRunTime(new TimeSpan(0, 2, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(500, 100, 1000, 20, 100000, SimulatedAnnealing.CoolingFunction.LOGARITHMIC),
        //    "ftv47", pathForm47Matrix,
        //    1776)
        //    .SetRunTime(new TimeSpan(0, 2, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);


        //new DefinedMatrixErrorTest(new SimulatedAnnealing(500, 0.996, 1000, 10, 1000000, SimulatedAnnealing.CoolingFunction.GEOMETRIC),
        //    "ftv170", pathForm170Matrix,
        //    2755)
        //    .SetRunTime(new TimeSpan(0, 4, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(75, 0.05, 1000, 10, 100000, SimulatedAnnealing.CoolingFunction.LINEAR),
        //    "ftv170", pathForm170Matrix,
        //    2755)
        //    .SetRunTime(new TimeSpan(0, 4, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(75, 40, 1000, 15, 100000, SimulatedAnnealing.CoolingFunction.LOGARITHMIC),
        //    "ftv170", pathForm170Matrix,
        //    2755)
        //    .SetRunTime(new TimeSpan(0, 4, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);


        //new DefinedMatrixErrorTest(new SimulatedAnnealing(500, 0.995, 1000, 100, 100000, SimulatedAnnealing.CoolingFunction.GEOMETRIC),
        //    "rgb403", pathForm403Matrix,
        //    2465)
        //    .SetRunTime(new TimeSpan(0, 6, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(15, 0.02, 1000, 10, 100000, CoolingFunction.LINEAR),
        //    "rgb403", pathForm403Matrix,
        //    2465)
        //    .SetRunTime(new TimeSpan(0, 6, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
        //new DefinedMatrixErrorTest(new SimulatedAnnealing(15, 6.5, 1000, 1, 100000, CoolingFunction.LOGARITHMIC),
        //    "rgb403", pathForm403Matrix,
        //    2465)
        //    .SetRunTime(new TimeSpan(0, 6, 0))
        //    .RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestTime()
    {
        //TimePerformanceTester ptBruteForce = new(new BruteForce());
        //ptBruteForce.SetMatrixDistances(10, 1000).SetMatrixSizeForTest(2, 12, 1).SetRepeatAmount(1, 100);
        //ptBruteForce.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester dpTester = new(new DynamicProgramming(), SEED);
        dpTester.SetMatrixSizeForTest(2, 20, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babLowCostTester = new(new BranchAndBound(SearchType.LOW_COST), SEED);
        babLowCostTester.SetMatrixSizeForTest(2, 20, 1);
        babLowCostTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babBFSTester = new(new BranchAndBound(SearchType.BREADTH), SEED);
        babBFSTester.SetMatrixSizeForTest(2, 11, 1);
        babBFSTester.RunTest(TEST_RESULT_DIRECTORY);

        TimePerformanceTester babDFSTester = new(new BranchAndBound(SearchType.DEEP), SEED);
        babDFSTester.SetMatrixSizeForTest(2, 20, 1);
        babDFSTester.RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestMemory()
    {
        MemoryUsageTester dpTester = new MemoryUsageTester(new DynamicProgramming(), SEED);
        dpTester.SetMatrixSizeForTest(2, 20, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTesterLC = new MemoryUsageTester(new BranchAndBound(SearchType.LOW_COST), SEED);
        babTesterLC.SetMatrixSizeForTest(2, 20, 1);
        babTesterLC.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTesterBFS = new MemoryUsageTester(new BranchAndBound(SearchType.BREADTH), SEED);
        babTesterBFS.SetMatrixSizeForTest(2, 11, 1);
        babTesterBFS.RunTest(TEST_RESULT_DIRECTORY);

        MemoryUsageTester babTesterDFS = new MemoryUsageTester(new BranchAndBound(SearchType.DEEP), SEED);
        babTesterDFS.SetMatrixSizeForTest(2, 20, 1);
        babTesterDFS.RunTest(TEST_RESULT_DIRECTORY);
    }

    public static void TestPercentFinished()
    {
        PercentFinishTester babLowCostTester = new(new BranchAndBound(SearchType.LOW_COST), SEED);
        babLowCostTester.SetMatrixSizeForTest(2, 25, 1);
        babLowCostTester.RunTest(TEST_RESULT_DIRECTORY);

        PercentFinishTester dpTester = new PercentFinishTester(new DynamicProgramming(), SEED);
        dpTester.SetMatrixSizeForTest(2, 25, 1);
        dpTester.RunTest(TEST_RESULT_DIRECTORY);

        PercentFinishTester babBFSTester = new(new BranchAndBound(SearchType.BREADTH), SEED);
        babBFSTester.SetMatrixSizeForTest(2, 25, 1);
        babBFSTester.RunTest(TEST_RESULT_DIRECTORY);

        PercentFinishTester babDFSTester = new(new BranchAndBound(SearchType.DEEP), SEED);
        babDFSTester.SetMatrixSizeForTest(2, 25, 1);
        babDFSTester.RunTest(TEST_RESULT_DIRECTORY);
    }
}

