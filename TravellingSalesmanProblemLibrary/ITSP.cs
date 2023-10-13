using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary
{
    public interface ITSP
    {

        /// <summary>
        /// Finds the best solution for Sales Map Problem.
        /// </summary>
        /// <param name="matrix">Adjency matrix.</param>
        /// <returns>
        /// Returns best path cost or null if no valid path is found.
        /// </returns>
        public int? CalculateBestPathCost(AdjMatrix matrix);
    }
}
