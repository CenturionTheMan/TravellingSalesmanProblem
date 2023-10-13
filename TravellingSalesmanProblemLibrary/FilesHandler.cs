using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary
{
    public static class FilesHandler
    {
        /// <summary>
        /// Loads an adjacency matrix from a file with a specific format and creates an AdjMatrix object.
        /// </summary>
        /// <param name="filePath">The path to the file containing the adjacency matrix data.</param>
        /// <returns>An AdjMatrix object representing the graph, or null if loading fails.</returns>
        public static AdjMatrix? LoadAdjMatrixFromFile(string filePath)
        {
            string fileCon = File.ReadAllText(filePath);
            var vertexsAmout = GetVertexsAmount(fileCon);
            if (!vertexsAmout.HasValue) return null;

            const string endOfEntry = "EDGE_WEIGHT_SECTION";
            int entryEndIndex = fileCon.IndexOf(endOfEntry) + endOfEntry.Length;

            var numbersSingleStr = fileCon.Substring(entryEndIndex, fileCon.Length - entryEndIndex - "\nEOF".Length);

            var numbers = numbersSingleStr.Replace("\n", " ").Split(" ").ToList().FindAll(e => e != "").Select(e => int.Parse(e));

            AdjMatrix worldMap = new(vertexsAmout.Value);

            int column = 0;
            int row = 0;
            foreach (var number in numbers)
            {

                if (column == vertexsAmout)
                {
                    column = 0;
                    row++;
                }

                worldMap.SetDistance(column, row, number);

                column++;
            }

            return worldMap;
        }


        /// <summary>
        /// Extracts the number of vertices from the file content based on a specific keyword.
        /// </summary>
        /// <param name="fileCon">The content of the file.</param>
        /// <returns>The number of vertices if found, or null if not found or unable to parse.</returns>
        private static int? GetVertexsAmount(string fileCon)
        {
            const string keyWord = "DIMENSION:";

            int tmpBeg = fileCon.IndexOf(keyWord);
            int tmpEnd = fileCon.IndexOf("\n", tmpBeg + keyWord.Length);

            string tmpStr = fileCon.Substring(tmpBeg + keyWord.Length, tmpEnd - tmpBeg - keyWord.Length).Trim();

            if(int.TryParse(tmpStr, out int result))
                return result;

            return null;
        }
    }
}
