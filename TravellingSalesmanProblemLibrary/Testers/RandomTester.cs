using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Testers
{
    public abstract class RandomTester : ITester
    {
        protected ITSPAlgorithm algorithm;

        protected int minMatrixSize;
        protected int maxMatrixSize;
        protected int stepMatrixSize;

        protected int matrixMinDistance;
        protected int matrixMaxDistance;

        protected int repPerSize;
        protected int repPerMatrix;


        protected RandomTester(ITSPAlgorithm algorithm)
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
        public RandomTester SetMatrixSizeForTest(int minMatrixSize, int maxMatrixSize, int stepMatrixSize)
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
        public RandomTester SetMatrixDistances(int matrixMinDistance, int matrixMaxDistance)
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
        public RandomTester SetRepeatAmount(int repPerSize, int repPerMatrix)
        {
            this.repPerMatrix = repPerMatrix;
            this.repPerSize = repPerSize;
            return this;
        }

        public abstract void RunTest(string outputFileDir);
    }
}
