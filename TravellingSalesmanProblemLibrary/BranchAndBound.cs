using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary
{
    public class BranchAndBound : TSPAlgorithm
    {
        public BranchAndBound(ref CancellationToken cancellationToken) : base(ref cancellationToken)
        {
        }

        public override string AlgorithmName => "BranchAndBound";

        public override (int[] path, int cost)? CalculateBestPath(AdjMatrix matrix)
        {
            throw new NotImplementedException();
        }

        public new int? CalculateBestPathCost(AdjMatrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
