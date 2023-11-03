using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

namespace TravellingSalesmanProblemConsole;

public class Program
{
    public static void Main()
    {
        //Test();

        var bab = new BranchAndBound();
        var bf = new BruteForce();
        var dp = new DynamicProgramming();

        //AdjMatrix matrix = new(4);

        //matrix.SetDistance(0, 1, 12);
        //matrix.SetDistance(0, 2, 14);
        //matrix.SetDistance(0, 3, 17);
        //matrix.SetDistance(1, 2, 15);
        //matrix.SetDistance(1, 3, 18);
        //matrix.SetDistance(2, 3, 29);
        AdjMatrix matrix = new AdjMatrix(new int?[,] { { null, 20, 30, 10, 11},
                                                       { 15, null, 16, 4, 2},
                                                       { 3, 5, null, 2, 4},
                                                       { 19, 6, 18, null, 3},
                                                       { 16, 4, 7, 16, null} });
        if (matrix == null) throw new Exception();

        var resultBF = bf.CalculateBestPath(matrix);
        Console.WriteLine(resultBF.ToStringCustom());

        Console.WriteLine("========================================");

        var resultDP = dp.CalculateBestPath(matrix);
        Console.WriteLine(resultDP.ToStringCustom());

        Console.WriteLine("========================================");

        var result = bab.CalculateBestPath(matrix);
        Console.WriteLine(result.ToStringCustom());

        Console.WriteLine("DONE");
        Console.ReadKey();
    }


    public static void Test()
    {
        TimePerformanceTester ptBruteForce = new(new BruteForce());
        ptBruteForce.SetMatrixDistances(10, 1000).SetMatrixSizeForTest(2, 12, 1).SetRepeatAmount(1, 100);
        ptBruteForce.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");

        //TimePerformanceTester ptDynamicProgramming = new(new DynamicProgramming());
        //ptDynamicProgramming.SetMatrixSizeForTest(10, 20, 1);
        //ptDynamicProgramming.PerformTimeTest("G:\\My Drive\\Studia\\Studia_sem_5\\PEA\\TravellingSalesmanProblem\\TestResults\\");
    }
}

