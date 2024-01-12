using System.Net;
using System.Text;
using System.Xml;

namespace TravellingSalesmanProblemLibrary;

public class AdjMatrix
{
	public int GetMatrixSize { get { return size; } }
    public double?[,] Matrix { get { return (double?[,])matrix.Clone(); } }


    private double?[,] matrix;
	private int size;

    private double? maxDistance;

    /// <summary>
    /// Initializes a new instance of the AdjMatrix class with the specified number of vertices.
    /// </summary>
    /// <param name="verticesAmount">The number of vertices in matrix.</param>
    public AdjMatrix(int verticesAmount)
    {
        if (verticesAmount < 1)
            throw new ArgumentException("Matrix size must be greater or equal to 1");
        matrix = new double?[verticesAmount, verticesAmount];
        size = verticesAmount;
        maxDistance = null;
    }

    /// <summary>
    /// Initializes a new instance of the AdjMatrix class with the specified number of vertices.
    /// Matrix is filled with random values from given range.
    /// </summary>
    /// <param name="verticesAmount">The number of vertices in matrix</param>
    /// <param name="minDistance">Min range (inclusive)</param>
    /// <param name="maxDistance">Max range (inclusive)</param>
    /// <param name="seed">seed for random generator</param>
    public AdjMatrix(int verticesAmount, int minDistance, int maxDistance, int? seed = null) : this(verticesAmount)
    {
        FillMapWithRandomValues(minDistance, maxDistance, seed);
    }

    /// <summary>
    /// Initializes a new instance of the AdjMatrix class with the specified double dimension array of values
    /// </summary>
    /// <param name="matrix">Values to fill matrix with</param>
    /// <exception cref="ArgumentException">Dimentions of array must be equal</exception>
    public AdjMatrix(double?[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("Both dimensions must be equal in lenght!");
        if (matrix.GetLength(0) < 1)
            throw new ArgumentException("Matrix size must be greater or equal to 1");

        maxDistance = matrix[0, 0];
        foreach (var dis in matrix)
        {
            if (maxDistance < dis) maxDistance = dis;
        }

        this.matrix = matrix;
        this.size = matrix.GetLength(0);
    }

    /// <summary>
    /// Initializes a new instance of the AdjMatrix class with the specified single dimenstion array which is "joined" double dimension array
    /// </summary>
    /// <param name="verticesAmount">Amount of vertices in matrix</param>
    /// <param name="distances">Values to fill matrix with</param>
    /// <exception cref="ArgumentException">Will be thrown of length of <paramref name="distances"/> will not be equal to
    /// <paramref name="verticesAmount"/> times <paramref name="verticesAmount"/> </exception>
    public AdjMatrix(int verticesAmount, int[] distances) : this(verticesAmount)
    {
        if(verticesAmount * verticesAmount != distances.Length)
        {
            throw new ArgumentException();
        }

        int column = 0;
        int row = 0;
        foreach (var dis in distances)
        {

            if (column == verticesAmount)
            {
                column = 0;
                row++;
            }

            if (dis != -1)
                SetDistance(row, column, dis, false);

            column++;
        }
    }


    /// <summary>
    /// Sets the distance value between two vertices in the world map.
    /// </summary>
    /// <param name="begin">The index of the starting vertex.</param>
    /// <param name="end">The index of the ending vertex.</param>
    /// <param name="value">The distance value between the two vertices.</param>
    /// <param name="isDoubleDirection">Indicates whether the distance should be set in both directions (from begin to end and from end to begin).</param>
    /// <returns>True if the distance is successfully set, false otherwise.</returns>
    public bool SetDistance(int begin, int end, double value, bool isDoubleDirection = true)
	{
		if(CheckIndexes(begin, end))
		{
			matrix[begin, end] = value;

            if (isDoubleDirection)
            {
				if(!CheckIndexes(end, begin)) return false;

				matrix[end, begin] = value;
            }

            if(maxDistance == null || maxDistance < value) maxDistance = value;

            return true;
		}
		
		return false;
	}

    /// <summary>
    /// Method retrieve the distance between two vertices in the world map.
    /// </summary>
    /// <param name="begin">The index of the starting vertex.</param>
    /// <param name="end">The index of the ending vertex.</param>
    /// <returns>The distance between the two vertices</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public double GetDistance(int begin, int end)
    {
        if (CheckIndexes(begin, end) == false) throw new ArgumentOutOfRangeException();
        var tmp = matrix[begin, end];
        if (tmp.HasValue == false) throw new ArgumentNullException();
        return tmp.Value;
    }

    /// <summary>
    /// Attempts to retrieve the distance between two vertices in the world map.
    /// </summary>
    /// <param name="begin">The index of the starting vertex.</param>
    /// <param name="end">The index of the ending vertex.</param>
    /// <param name="distance">The distance between the two vertices.</param>
    /// <returns>True if the distance is successfully retrieved, false otherwise.</returns>
    public bool TryGetDistance(int begin, int end, out double distance)
	{
		distance = 0;
		if(CheckIndexes(begin, end))
		{
			var tmp = matrix[begin, end];
			if(tmp != null)
			{
				distance = tmp.Value;
				return true;
			}
		}

		return false;
	}

    /// <summary>
    /// Returns a string representation of the world map matrix.
    /// </summary>
    /// <returns>A formatted string displaying the matrix of distances between vertices.</returns>
    public override string ToString()
	{
		if(matrix == null) return "";

		StringBuilder stringBuilder = new();
        int precision = (maxDistance.HasValue)? maxDistance.Value.ToString().Length: 5;
        
        string nullVal = "";
        for (int i = 0; i < precision; i++) nullVal += "-";


		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
                object tmp = (matrix[i, j].HasValue) ? matrix[i, j]!.Value : nullVal;
                string formated = String.Format("{0,-" + precision + "} ", tmp);
                stringBuilder.Append(formated);
			}
			stringBuilder.Append("\n");
		}

		return stringBuilder.ToString();
	}


    /// <summary>
    /// Method will randomly fill adjeancy matrix with numbers
    /// </summary>
    /// <param name="min">min distance</param>
    /// <param name="max">max distance</param>
    /// <param name="seed">seed for random generator</param>
    public void FillMapWithRandomValues(int min, int max, int? seed = null)
    {
        Random random = seed == null? new Random() : new Random(seed.Value);
        for (int i = 0; i < GetMatrixSize; i++)
        {
            for (int j = 0; j < GetMatrixSize; j++)
            {
                if (i == j)
                    matrix[i, j] = null;
                else
                {
                    matrix[i, j] = random.Next(min, max + 1);
                    if (maxDistance == null || maxDistance < matrix[i, j]) maxDistance = matrix[i, j];
                }
            }
        }
    }

    /// <summary>
    /// Checks if the given indexes are valid for the world map matrix.
    /// In other words this method cheks if given indexes are between 0 and given matrix size
    /// </summary>
    /// <param name="indexes">An array of integer indexes to be checked.</param>
    /// <returns>True if all indexes are within the valid range, otherwise false.</returns>
    private bool CheckIndexes(params int[] indexes)
    {
        foreach (var index in indexes)
        {
            if (index < 0 || index >= size) return false;
        }
        return true;
    }

}