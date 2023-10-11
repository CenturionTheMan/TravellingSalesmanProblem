using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary
{
    public static class FilesHandler
    {
        public static WorldMap? LoadWorldMapFromFile(string filePath)
        {
            string fileCon = File.ReadAllText(filePath);
            var nodesAmout = GetNodesAmount(fileCon);
            if (!nodesAmout.HasValue) return null;

            const string endOfEntry = "EDGE_WEIGHT_SECTION";
            int entryEndIndex = fileCon.IndexOf(endOfEntry) + endOfEntry.Length;

            var numbersSingleStr = fileCon.Substring(entryEndIndex, fileCon.Length - entryEndIndex - "\nEOF".Length);

            var numbers = numbersSingleStr.Replace("\n", " ").Split(" ").ToList().FindAll(e => e != "").Select(e => int.Parse(e));

            WorldMap worldMap = new(nodesAmout.Value);

            int column = 0;
            int row = 0;
            foreach (var number in numbers)
            {

                if (column == nodesAmout)
                {
                    column = 0;
                    row++;
                }

                worldMap.SetDistance(column, row, number);

                column++;
            }

            return worldMap;
        }



        private static int? GetNodesAmount(string fileCon)
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
