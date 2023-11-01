using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravellingSalesmanProblemLibrary.Utilites;

namespace TravellingSalesmanProblemLibrary
{
    public class BranchAndBound : TSPAlgorithm
    {
        private const int BEGIN_VERTEX = 0;

        public override string AlgorithmName => "BranchAndBound";

        public BranchAndBound(ref CancellationToken cancellationToken) : base(ref cancellationToken) { }
        public BranchAndBound() : base() { }


        public override (int[] path, int cost)? CalculateBestPath(AdjMatrix matrix)
        {
            var verticesToVisit = CreateListOfVertices(matrix.GetMatrixSize);
            
            int?[,] originalMatrix = matrix.Matrix;

            List<int> path = new();
            path.Add(BEGIN_VERTEX);

            int vertexFrom = BEGIN_VERTEX;
            int cost = ReduceMatrix(ref originalMatrix);

            Console.WriteLine(new AdjMatrix(originalMatrix));


            while (verticesToVisit.Count > 0)
            {
                List<(int v, int c, int?[,] m)> vertexCostMatrix = new();
                
                foreach (var vertexTo in verticesToVisit)
                {
                    (int?[,] wMatrix, int? edgeCost) = SetRowColumnToNull(originalMatrix, vertexFrom, vertexTo);
                    if (edgeCost == null) continue;

                    Console.WriteLine(TMP(path, vertexTo));
                    Console.WriteLine(new AdjMatrix(wMatrix));

                    int wCost = ReduceMatrix(ref wMatrix) + edgeCost.Value;

                    Console.WriteLine(TMP(path, vertexTo));
                    Console.WriteLine(new AdjMatrix(wMatrix));

                    vertexCostMatrix.Add((vertexTo, wCost, wMatrix));
                }
                
                var minVCM = vertexCostMatrix.MinBy(vc => vc.c);

                vertexFrom = minVCM.v;
                originalMatrix = minVCM.m;

                cost += minVCM.c;
                path.Add(minVCM.v);

                verticesToVisit.Remove(minVCM.v);
            }

            //cost += matrix.GetDistance(path[path.Count - 1], BEGIN_VERTEX);
            path.Add(BEGIN_VERTEX);

            return (path.ToArray(), cost);
        }

        private string TMP(List<int> path, int next)
        {
            string res = "";
            path.ForEach(p => res += p.ToString() + "->");
            res += next.ToString();
            return res;
        }

        private List<int> CreateListOfVertices(int vertexAmount)
        {
            List<int> res = new();
            for (int i = 0; i < vertexAmount; i++)
            {
                if (i == BEGIN_VERTEX) continue;
                res.Add(i);
            }
            return res;
        }

        private void SolveRec(AdjMatrix matrix, List<int> verticesToVisit)
        {
            
        }


        private (int?[,] matrix, int? edgeCost) SetRowColumnToNull(int?[,] matrix, int rowIndex, int columnIndex)
        {
            int?[,] workingMatrix = (int?[,])matrix.Clone();
            int? dis = matrix[rowIndex, columnIndex];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                workingMatrix[rowIndex, i] = null;
                workingMatrix[i, columnIndex] = null;
            }
            workingMatrix[columnIndex, rowIndex] = null;
            return (workingMatrix, dis);
        }

        private int ReduceMatrix(ref int?[,] matrix)
        {
            int reducionElemSum = 0;
            //reduce row
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var minRowCost = Min(matrix, false, i);
                if (minRowCost == null || minRowCost == 0) continue;
                
                matrix = ReduceMatrix(matrix, minRowCost.Value, false, i);
                reducionElemSum += minRowCost.Value;
            }

            //reduce column
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                var minColumnCost = Min(matrix, true, i);
                if (minColumnCost == null || minColumnCost == 0) continue;
                
                matrix = ReduceMatrix(matrix, minColumnCost.Value, true, i);
                reducionElemSum += minColumnCost.Value;
            }

            return reducionElemSum;
        }

        private int?[,] ReduceMatrix(int?[,] matrix, int value, bool isColumn, int index)
        {
            if(isColumn)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, index].HasValue == false) continue;
                    matrix[i, index] -= value;
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[index, i].HasValue == false) continue;
                    matrix[index, i] -= value;
                }
            }

            return matrix;
        }


        private int? Min(int?[,] matrix, bool isColumn, int index)
        {
            int? min = null;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var item = (isColumn) ? matrix[i, index] : matrix[index, i];
                if (!item.HasValue) continue;

                if (min == null || item.Value < min) min = item;
            }
            return min;
        }
    }
}
