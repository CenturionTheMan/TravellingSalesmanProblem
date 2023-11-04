using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravellingSalesmanProblemLibrary.Utilites;

namespace TravellingSalesmanProblemLibrary
{
    public class MemoryUsageTester
    {
        private TSPAlgorithm algorithm;

        private int minMatrixSize = 2;
        private int maxMatrixSize = 10;
        private int stepMatrixSize = 1;

        private int matrixMinDistance = 1;
        private int matrixMaxDistance = 1000;

        private int repPerSize = 10;


        public MemoryUsageTester(TSPAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }


        /// <summary>
        /// Sets the matrix size range for testing.
        /// </summary>
        /// <param name="minMatrixSize">The minimum matrix size.</param>
        /// <param name="maxMatrixSize">The maximum matrix size.</param>
        /// <param name="stepMatrixSize">The step size for increasing the matrix size.</param>
        /// <returns>The current TimePerformanceTester instance.</returns>
        public MemoryUsageTester SetMatrixSizeForTest(int minMatrixSize, int maxMatrixSize, int stepMatrixSize)
        {
            this.minMatrixSize = minMatrixSize;
            this.maxMatrixSize = maxMatrixSize;
            this.stepMatrixSize = stepMatrixSize;
            return this;
        }

        /// <summary>
        /// Sets the distance range for matrix generation.
        /// </summary>
        /// <param name="matrixMinDistance">The minimum distance value.</param>
        /// <param name="matrixMaxDistance">The maximum distance value.</param>
        /// <returns>The current TimePerformanceTester instance.</returns>
        public MemoryUsageTester SetMatrixDistances(int matrixMinDistance, int matrixMaxDistance)
        {
            this.matrixMinDistance = matrixMinDistance;
            this.matrixMaxDistance = matrixMaxDistance;
            return this;
        }

        /// <summary>
        /// Sets the repetition amount for testing.
        /// </summary>
        /// <param name="repPerMatrix">The number of repetitions per matrix.</param>
        /// <param name="repPerSize">The number of repetitions per matrix size.</param>
        /// <returns>The current TimePerformanceTester instance.</returns>
        public MemoryUsageTester SetRepeatAmount(int repPerSize)
        {
            this.repPerSize = repPerSize;
            return this;
        }


        
        public void PerformMemoryTest(string fileDir)
        {
            fileDir = fileDir.ChangeFileExtension("");
            string pathMean = fileDir + algorithm.AlgorithmName + "MemoryTestMean" + ".csv";
            string pathMax = fileDir + algorithm.AlgorithmName + "MemoryTestMan" + ".csv";
            string pathMedian = fileDir + algorithm.AlgorithmName + "MemoryTestMedian" + ".csv";

            List<object[]> tmp = new();
            tmp.Add(new object[] { "Algorithm", "RepsPerSize", "MatrixSize", "Memory [MB]" });
            FilesHandler.CreateCsvFile(tmp, pathMean, true);
            FilesHandler.CreateCsvFile(tmp, pathMax, true);
            FilesHandler.CreateCsvFile(tmp, pathMedian, true);

            for (int matrixSize = minMatrixSize; matrixSize <= maxMatrixSize; matrixSize += stepMatrixSize)
            {
                List<double> meanRep = new();
                List<double> maxRep = new();
                List<double> medianRep = new();

                for (int repSize = 1; repSize <= repPerSize; repSize++)
                {
                    AdjMatrix matrix = new AdjMatrix(matrixSize, matrixMinDistance, matrixMaxDistance);
                    CancellationTokenSource memoryRegisterCTS = new CancellationTokenSource();

                    var memoryRegisterTaskResult = MeasureMemoryUsageInIntervals(memoryRegisterCTS, 10);
                    algorithm.CalculateBestPath(matrix);
                    memoryRegisterCTS.Cancel();

                    var memoryTable = memoryRegisterTaskResult.Result;
                    if(memoryTable == null)
                    {
                        memoryTable = new();
                        memoryTable.Add(GC.GetTotalMemory(true));
                    }

                    meanRep.Add( memoryTable.Average() );
                    maxRep.Add( memoryTable.Max() );
                    medianRep.Add( memoryTable.Median() );
                }

                double meanVal = meanRep.Average();
                double maxVal = maxRep.Max();
                double medianVal = medianRep.Median();

                List<object[]> meanRow = new List<object[]>() { new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, meanVal} };
                List<object[]> maxRow = new List<object[]>() { new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, maxVal} };
                List<object[]> medianRow = new List<object[]>() { new object[] { algorithm.AlgorithmName, repPerSize, matrixSize, medianVal} };
                FilesHandler.CreateCsvFile(meanRow, pathMean, false);
                FilesHandler.CreateCsvFile(maxRow, pathMax, false);
                FilesHandler.CreateCsvFile(medianRow, pathMedian, false);
            }
        }

        private async Task<List<double>> MeasureMemoryUsageInIntervals(CancellationTokenSource ctSource, int intervalInMiliseconds)
        {
            List<double> result = new List<double>();

            while (ctSource.Token.IsCancellationRequested == false)
            {
                long memory = GC.GetTotalMemory(true);
                result.Add(memory/(double)1000000); //to MB
                await Task.Delay(intervalInMiliseconds);
            }

            return result;
        }
    }
}
