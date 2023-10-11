using System.Text;
using System.Xml;

namespace TravellingSalesmanProblemLibrary;

public class WorldMap
{
	public int GetCitiesAmount { get { return size; } }

    private int?[,] matrix;
	private int size;

    /// <summary>
    /// Initializes a new instance of the WorldMap class with the specified number of cities.
    /// </summary>
    /// <param name="citiesAmount">The number of cities in the world map.</param>
    public WorldMap(int citiesAmount)
    {
        matrix = new int?[citiesAmount, citiesAmount];
        size = citiesAmount;
    }


    public WorldMap(int?[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("Both dimensions must be equal in lenght!");

        this.matrix = matrix;
        this.size = matrix.GetLength(0);
    }




    /// <summary>
    /// Sets the distance value between two cities in the world map.
    /// </summary>
    /// <param name="begin">The index of the starting city.</param>
    /// <param name="end">The index of the ending city.</param>
    /// <param name="value">The distance value between the two cities.</param>
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
    /// Attempts to retrieve the distance between two cities in the world map.
    /// </summary>
    /// <param name="begin">The index of the starting city.</param>
    /// <param name="end">The index of the ending city.</param>
    /// <param name="distance">The distance between the two cities (output).</param>
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
    /// <returns>A formatted string displaying the matrix of distances between cities.</returns>
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

    public void FillMapRandom(int min, int max)
    {
        Random r = new Random();
        for (int i = 0; i < GetCitiesAmount; i++)
        {
            for (int j = 0; j < GetCitiesAmount; j++)
            {
                matrix[i,j] = r.Next(min, max);
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