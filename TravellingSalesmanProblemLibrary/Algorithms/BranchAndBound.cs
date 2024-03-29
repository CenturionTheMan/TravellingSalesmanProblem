﻿using System.ComponentModel;
using static TravellingSalesmanProblemLibrary.Utilities;

namespace TravellingSalesmanProblemLibrary;

public class BranchAndBound : ITSPAlgorithm
{
    public string AlgorithmName => "Branch And Bound";
    public string AlgorithmDetailedName => "BranchAndBound_" + searchType;


    public SearchType SelectedSearchType { get { return searchType; } private set { searchType = value; } }

    private const int BEGIN_VERTEX = 0;
    private SearchType searchType = SearchType.LOW_COST;



    public BranchAndBound(SearchType searchType = SearchType.LOW_COST)
    {
        this.searchType = searchType;
    }



    /// <summary>
    /// Calculates the best path in an adjacency matrix using the Branch and Bound algorithm.
    /// </summary>
    /// <param name="matrix">The adjacency matrix representing the problem.</param>
    /// <returns>
    /// A tuple containing the best path as an array of vertex indices and the total cost,
    /// or null if the operation is canceled due to a cancellation request or impossible to solve matrix.
    /// </returns>
    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix, CancellationToken cancellationToken)
    {
        List<Node> nodes = new();
        List<int>? bestPath = null;
        double upperBound = double.MaxValue;
        double?[,] cMatrix = matrix.Matrix;
        int vertexFrom = BEGIN_VERTEX;

        //calculate initial upper bound value using closest-neighbour selection
        var initValues = GetInitUpperBound(matrix);
        if (initValues != null)
        {
            bestPath = initValues.Value.initPath;
            upperBound = initValues.Value.initCost;
        }

        //reduce initial matrix
        double cost = ReduceMatrix(ref cMatrix);

        //add initial node to queue
        Node initNode = new Node(cMatrix, cost, vertexFrom);
        nodes.Add(initNode);

        while (nodes.Count > 0)
        {
            if(cancellationToken.IsCancellationRequested)
            {
                return null;
            }

            //search type handling
            Node node;
            switch (searchType)
            {
                case SearchType.LOW_COST:
                    node = nodes.MinBy(n => n.cost);
                    break;
                case SearchType.DEEP:
                    node = nodes.Last();
                    break;
                case SearchType.BREADTH:
                    node = nodes.FirstOrDefault();
                    break;
                default:
                    throw new NotImplementedException();
            }
            nodes.Remove(node);

            //if given node cost (lower bound) is higher than current upper bound -> skip
            if (node.cost >= upperBound)
            {
                continue;
            }
            else
            {
                //if given path is completed and its cost is lower than current upper bound
                //assing it as new upper bound
                if (node.path.Count == matrix.GetMatrixSize)
                {
                    upperBound = node.cost;
                    bestPath = node.path;
                }
            }

            //search for next sub-path. From last vertex in currenly creatd path
            vertexFrom = node.path.Last();

            //check all possible connections
            for (int vertexTo = 0; vertexTo < matrix.GetMatrixSize; vertexTo++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return null;
                }

                //if vertex already in curently created path -> skip
                if (node.path.Contains(vertexTo)) continue;

                //get cost from vertex to next vertex
                double? edgeCost = node.matrix[vertexFrom, vertexTo];
                if (edgeCost == null) continue;

                //remove colun and row from matrix at choosen vertices (set as null)
                double?[,] wMatrix = SetRowColumnToNull(node.matrix, vertexFrom, vertexTo);

                //reduce matrix
                double wCost = ReduceMatrix(ref wMatrix) + edgeCost.Value + node.cost;

                //add new sub-node to state space tree
                Node tmp = new Node(wMatrix, wCost, node.path, vertexTo);
                nodes.Add(tmp);
            }
        }

        if (bestPath != null) bestPath.Add(BEGIN_VERTEX);

        return bestPath == null? null : (bestPath.ToArray(), upperBound);
    }

    public (int[] path, double cost)? CalculateBestPath(AdjMatrix matrix)
    {
        return CalculateBestPath(matrix, new CancellationToken());
    }

    /// <summary>
    /// Method will return initial value for upper bound as well as path asociated with it.
    /// Path is being created using closest-neighbour selection.
    /// </summary>
    /// <param name="adjMatrix">The adjacency matrix representing the problem.</param>
    /// <returns>Initial upper bound value with path or null if could not created valid path</returns>
    private (double initCost, List<int> initPath)? GetInitUpperBound(AdjMatrix adjMatrix)
    {
        List<int> path = new();
        double sumCost = 0;
        int fromVertex = BEGIN_VERTEX;
        path.Add(BEGIN_VERTEX);

        for (int i = 0; i < adjMatrix.GetMatrixSize - 1; i++)
        {
            var next = FindClosestNeigh();
            if (next == null) return null;

            path.Add(next.Value.vertex);
            sumCost += next.Value.cost;
            fromVertex = next.Value.vertex;
        }
        if (adjMatrix.TryGetDistance(path[path.Count - 1], BEGIN_VERTEX, out double last) == false) return null;
        sumCost += last;
        return (sumCost, path);


        (double cost, int vertex)? FindClosestNeigh()
        {
            double? minCost = null;
            int vertex = -1;
            for (int j = 0; j < adjMatrix.GetMatrixSize; j++)
            {
                if (path.Contains(j)) continue;

                if (adjMatrix.TryGetDistance(fromVertex, j, out double dis) == false) continue;

                if(minCost == null || dis < minCost)
                {
                    minCost = dis;
                    vertex = j;
                }
            }

            return minCost.HasValue? (minCost.Value, vertex) : null;
        }
    }

    /// <summary>
    /// Sets the specified row and column in the matrix to null.
    /// </summary>
    /// <param name="matrix">The matrix to modify.</param>
    /// <param name="rowIndex">The index of the row to set to null.</param>
    /// <param name="columnIndex">The index of the column to set to null.</param>
    /// <returns>A modified matrix with the specified row and column set to null.</returns>
    private double?[,] SetRowColumnToNull(double?[,] matrix, int rowIndex, int columnIndex)
    {
        double?[,] workingMatrix = (double?[,])matrix.Clone();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            workingMatrix[rowIndex, i] = null;
            workingMatrix[i, columnIndex] = null;
        }
        workingMatrix[columnIndex, rowIndex] = null;
        return workingMatrix;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    private double ReduceMatrix(ref double?[,] matrix)
    {
        double reductionElemSum = 0;
        //reduce row
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var minRowCost = Min(matrix, false, i);
            if (minRowCost == null || minRowCost == 0) continue;
            
            matrix = ReduceMatrix(ref matrix, minRowCost.Value, false, i);
            reductionElemSum += minRowCost.Value;
        }

        //reduce column
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            var minColumnCost = Min(matrix, true, i);
            if (minColumnCost == null || minColumnCost == 0) continue;
            
            matrix = ReduceMatrix(ref matrix, minColumnCost.Value, true, i);
            reductionElemSum += minColumnCost.Value;
        }

        return reductionElemSum;
    }

    /// <summary>
    /// Reduces the matrix by subtracting the minimum element of each row and column, 
    /// and returns the total reduction value.
    /// </summary>
    /// <param name="matrix">The matrix to reduce, which is modified in place.</param>
    /// <returns>The total reduction value obtained by subtracting minimum elements from rows and columns.</returns>
    private double?[,] ReduceMatrix(ref double?[,] matrix, double value, bool isColumn, int index)
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

    /// <summary>
    /// Finds and returns the minimum value in a specified row or column of the matrix.
    /// </summary>
    /// <param name="matrix">The matrix to search for the minimum value.</param>
    /// <param name="isColumn">A flag indicating whether to search in a column (true) or a row (false).</param>
    /// <param name="index">The index of the column or row to search for the minimum value.</param>
    /// <returns>The minimum value found in the specified row or column, or null if no values are present.</returns>
    private double? Min(double?[,] matrix, bool isColumn, int index)
    {
        double? min = null;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var item = (isColumn) ? matrix[i, index] : matrix[index, i];
            if (!item.HasValue) continue;

            if (min == null || item.Value < min) min = item;
        }
        return min;
    }

    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<double?, long> toInvoke)
    {
        throw new NotImplementedException();
    }

    public void UnSubscribeShowCurrentSolutionInIntervals(Action<double?, long> toInvoke)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Represents a node in the Branch and Bound algorithm for solving the traveling salesman problem.
    /// </summary>
    private struct Node
    {
        public double?[,] matrix;
        public List<int> path;
        public double cost;

        public Node(double?[,] matrix, double cost, int vertex)
        {
            this.matrix = matrix;
            this.cost = cost;
            this.path = new List<int>();
            path.Add(vertex);
        }

        public Node(double?[,] matrix, double cost, List<int> path, int vertex)
        {
            this.matrix = matrix;
            this.cost = cost;
            this.path = new List<int>(path);
            this.path.Add(vertex);
        }
    }
}
