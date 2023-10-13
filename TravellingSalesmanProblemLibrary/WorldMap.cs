using System.Text;
using System.Xml;

namespace TravellingSalesmanProblemLibrary;

public class AdjMatrix
{
	public int GetMatrixSize { get { return size; } }

    private int?[,] matrix;
	private int size;


    /// <summary>
    /// Initializes a new instance of the AdjMatrix class with the specified number of vertices.
    /// </summary>
    /// <param name="verticesAmount">The number of vertices in the world map.</param>
    /// <param name="fillRandom">If true matrix will be filled with random values</param>
    public AdjMatrix(int verticesAmount)
    {
        matrix = new int?[verticesAmount, verticesAmount];
        size = verticesAmount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="verticesAmount"></param>
    /// <param name="minDistance"></param>
    /// <param name="maxDistance"></param>
    public AdjMatrix(int verticesAmount, int minDistance, int maxDistance) : this(verticesAmount)
    {
        FillMapWithRandomValues(minDistance, maxDistance);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    /// <exception cref="ArgumentException"></exception>
    public AdjMatrix(int?[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("Both dimensions must be equal in lenght!");

        this.matrix = matrix;
        this.size = matrix.GetLength(0);
    }


    /// <summary>
    /// Sets the distance value between two vertices in the world map.
    /// </summary>
    /// <param name="begin">The index of the starting vertex.</param>
    /// <param name="end">The index of the ending vertex.</param>
    /// <param name="value">The distance value between the two vertices.</param>
    /// <param name="isDoubleDirection">Indicates whether the distance should be set in both directions (from begin to end and from end to begin).</param>
    /// <returns>True if the distance is successfully set, false otherwise.</returns>
    public bool SetDistance(int begin, int end, int value, bool isDoubleDirection = true)
	{
		if(CheckIndexes(begin, end))
		{
			matrix[begin, end] = value;

            if (isDoubleDirection)
            {
				if(!CheckIndexes(end, begin)) return false;

				matrix[end, begin] = value;
            }

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
    public int GetDistance(int begin, int end)
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
    public bool TryGetDistance(int begin, int end, out int distance)
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
		int precision = 4;

		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				stringBuilder.Append(String.Format("{0,-" + precision + "} ", matrix[i,j]));
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
    public void FillMapWithRandomValues(int min, int max)
    {
        Random random = new Random();
        for (int i = 0; i < GetMatrixSize; i++)
        {
            for (int j = 0; j < GetMatrixSize; j++)
            {
                matrix[i, j] = random.Next(min, max + 1);
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