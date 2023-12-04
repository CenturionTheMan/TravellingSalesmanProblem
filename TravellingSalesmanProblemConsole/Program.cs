﻿using System.Diagnostics;
using TravellingSalesmanProblemLibrary;
using TravellingSalesmanProblemLibrary.Algorithms;
using TravellingSalesmanProblemLibrary.Testers;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    const string TEST_RESULT_DIRECTORY = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\";

    private static string pathForMatrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\matrix_6x6.txt";
    private static string pathForm170Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv170.atsp";
    private static string pathForm403Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\rbg403.atsp";
    private static string pathForm47Matrix = "D:\\GoogleDriveMirror\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestExamples\\ftv47.atsp";


    private static int SEED = 123;


    public static void Main()
    {
        DefinedMatrixErrorTest();
        Console.ReadKey();
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
        new DefinedMatrixErrorTest(new SimulatedAnnealing(15, 0.02, 1000, 10, 100000, SimulatedAnnealing.CoolingFunction.LINEAR),
            "rgb403", pathForm403Matrix,
            2465)
            .SetRunTime(new TimeSpan(0, 6, 0))
            .RunTest(TEST_RESULT_DIRECTORY);
        new DefinedMatrixErrorTest(new SimulatedAnnealing(15, 6.5, 1000, 1, 100000, SimulatedAnnealing.CoolingFunction.LOGARITHMIC),
            "rgb403", pathForm403Matrix,
            2465)
            .SetRunTime(new TimeSpan(0, 6, 0))
            .RunTest(TEST_RESULT_DIRECTORY);
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

