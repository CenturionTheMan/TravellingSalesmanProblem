using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static TravellingSalesmanProblemLibrary.Utilites;

namespace TravellingSalesmanProblemLibrary;

public class BranchAndBound : TSPAlgorithm
{
    private const int BEGIN_VERTEX = 0;

    public override string AlgorithmName => "BranchAndBound";

    public BranchAndBound(ref CancellationToken cancellationToken) : base(ref cancellationToken) { }
    public BranchAndBound() : base() { }

    public override (int[]? path, int cost)? CalculateBestPath(AdjMatrix matrix)
    {
        List<Node> nodes = new();

        int?[,] cMatrix = matrix.Matrix;
        int vertexFrom = BEGIN_VERTEX;
        int cost = ReduceMatrix(ref cMatrix);

        Node initNode = new Node(cMatrix, cost, vertexFrom);

        nodes.Add(initNode);

        int upperBound = int.MaxValue;

        List<int>? bestPath = null;

        while (nodes.Count > 0)
        {
            Node node = nodes.MinBy(n => n.cost);
            nodes.Remove(node);

            if (node.cost >= upperBound) continue;

            if (node.path.Count == matrix.GetMatrixSize && node.cost < upperBound)
            {
                upperBound = node.cost;
                bestPath = node.path;
            }

            vertexFrom = node.path.Last();

            for (int vertexTo = 0; vertexTo < matrix.GetMatrixSize; vertexTo++)
            {
                if (node.path.Contains(vertexTo)) continue;

                int? edgeCost = node.matrix[vertexFrom, vertexTo];
                int?[,] wMatrix = SetRowColumnToNull(node.matrix, vertexFrom, vertexTo);
                if (edgeCost == null) continue;
                int wCost = ReduceMatrix(ref wMatrix) + edgeCost.Value + node.cost;


                Node tmp = new Node(wMatrix, wCost, node.path, vertexTo);
                nodes.Add(tmp);
            }
        }

        if (bestPath != null) bestPath.Add(BEGIN_VERTEX);

        return bestPath == null? null : (bestPath.ToArray(), upperBound);
    }

    private int?[,] SetRowColumnToNull(int?[,] matrix, int rowIndex, int columnIndex)
    {
        int?[,] workingMatrix = (int?[,])matrix.Clone();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            workingMatrix[rowIndex, i] = null;
            workingMatrix[i, columnIndex] = null;
        }
        workingMatrix[columnIndex, rowIndex] = null;
        return workingMatrix;
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


    private struct Node
    {
        public int?[,] matrix;
        public List<int> path;
        public int cost;

        public Node(int?[,] matrix, int cost, int vertex)
        {
            this.matrix = matrix;
            this.cost = cost;
            this.path = new List<int>();
            path.Add(vertex);
        }

        public Node(int?[,] matrix, int cost, List<int> path, int vertex)
        {
            this.matrix = matrix;
            this.cost = cost;
            this.path = new List<int>(path);
            this.path.Add(vertex);
        }
    }
}
