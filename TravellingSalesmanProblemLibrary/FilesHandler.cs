﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            if (filePath == null || File.Exists(filePath) == false) return null;
            string fileCon = File.ReadAllText(filePath);

            if(fileCon.Contains("TYPE: ATSP"))
            {
                return LoadAdjMatrixFromATSPFile(fileCon);
            }
            else if(fileCon.Contains("<graph>"))
            {
                return LoadAdjMatrixFromXmlFile(fileCon);
            }
            else
            {
                return LoadAdjMatrixFromTxtFile(fileCon);
            }
        }

        private static AdjMatrix? LoadAdjMatrixFromXmlFile(string fileCon)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(fileCon);
            }
            catch
            {
                return null;
            }


            XmlNodeList vertices = doc.GetElementsByTagName("vertex");

            AdjMatrix adjMatrix = new(vertices!.Count);

            int fromVertex = 0;

            foreach (XmlNode vertex in vertices)
            {
                foreach (XmlNode edge in vertex)
                {
                    try
                    {
                        int toVertex = int.Parse(edge.InnerText);
                        double cost = double.Parse(edge.Attributes!["cost"]!.InnerText);
                        adjMatrix.SetDistance(fromVertex, toVertex, cost, false);
                    }
                    catch
                    {
                        return null;
                    }
                }
                fromVertex++;
            }
            return adjMatrix;
        }

        /// <summary>
        /// Loads an adjacency matrix from a TXT file content.
        /// </summary>
        /// <param name="fileCon">The content of the TXT file.</param>
        /// <returns>An AdjMatrix instance if successful, or null if there was an error.</returns>
        private static AdjMatrix? LoadAdjMatrixFromTxtFile(string fileCon)
        {
            var lines = fileCon.Split("\n");
            try
            {
                int vertexAmount = int.Parse(lines.First());
                var linesList = lines.ToList();
                linesList.RemoveAt(0);
                linesList.RemoveRange(lines.Length -4, 3);


                var numbers = new List<int>();

                foreach (var line in linesList)
                {
                    var strNum = line.Split(" ").Where(e => e != "");
                    var intNum = strNum.Select(e => int.Parse(e));
                    numbers.AddRange(intNum);
                }

                AdjMatrix? adjMatrix = new AdjMatrix(vertexAmount, numbers.ToArray());
                return adjMatrix;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Loads an adjacency matrix from a ATSP file content.
        /// </summary>
        /// <param name="fileCon">The content of the ATSP file.</param>
        /// <returns>An AdjMatrix instance if successful, or null if there was an error.</returns>
        private static AdjMatrix? LoadAdjMatrixFromATSPFile(string fileCon)
        {
            var vertexsAmout = GetVertexsAmount(fileCon);
            if (!vertexsAmout.HasValue) return null;

            const string endOfEntry = "EDGE_WEIGHT_SECTION";
            int entryEndIndex = fileCon.IndexOf(endOfEntry) + endOfEntry.Length;

            if (entryEndIndex < 0) return null;

            try
            {
                var numbersSingleStr = fileCon.Substring(entryEndIndex, fileCon.Length - entryEndIndex - "\nEOF".Length - 1);

                var numbersStr = numbersSingleStr.Replace("\n", " ").Replace("\r","").Split(" ").ToList().FindAll(e => e != "");

                List<int> numbers = new();
                foreach (var numStr in numbersStr)
                {
                    if(int.TryParse(numStr, out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("can not parse: " + numStr);
                    }
                }

                AdjMatrix worldMap = new(vertexsAmout.Value, numbers.ToArray());

                return worldMap;
            }
            catch
            {
                return null;
            }
            


            /// <summary>
            /// Extracts the number of vertices from the file content based on a specific keyword.
            /// </summary>
            /// <param name="fileCon">The content of the file.</param>
            /// <returns>The number of vertices if found, or null if not found or unable to parse.</returns>
            int? GetVertexsAmount(string fileCon)
            {
                const string keyWord = "DIMENSION:";

                int tmpBeg = fileCon.IndexOf(keyWord);
                int tmpEnd = fileCon.IndexOf("\n", tmpBeg + keyWord.Length);

                string tmpStr = fileCon.Substring(tmpBeg + keyWord.Length, tmpEnd - tmpBeg - keyWord.Length).Trim();

                if (int.TryParse(tmpStr, out int result))
                    return result;

                return null;
            }
        }






        /// <summary>
        /// Removes a file at the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the file to be removed.</param>
        /// <returns>
        /// True if the file was successfully removed; otherwise, false. 
        /// </returns>
        public static bool RemoveFile(string filePath)
        {
            if(File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            return false;
        }

        /// <summary>
        /// Changes file path extension
        /// </summary>
        /// <param name="str"> base string </param>
        /// <param name="extension"> needed extension </param>
        /// <returns> new string with wanted extension </returns>
        public static string ChangeFileExtension(this string str, string extension)
        {
            int beg = str.LastIndexOf(".");
            int safe = str.LastIndexOf(@"\");

            if (beg >= 0 && beg > safe) str = str.Remove(beg);

            str = str.Insert(str.Length, extension);

            return str;
        }

        /// <summary>
        /// Creates or appends data to a CSV file from a list of object arrays.
        /// </summary>
        /// <param name="data">A list of object arrays where each array represents a row of data.</param>
        /// <param name="fileOutputPath">The path to the CSV file to create or append to.</param>
        /// <param name="shouldReplace">Optional. If true, the file will be replaced with the new data; if false, the data will be appended to the existing file.</param>
        /// <param name="separator">Optional. The character used to separate values within each row.</param>
        /// <returns>
        /// True if the operation was successful, false if an error occurred.
        /// </returns>
        public static bool CreateCsvFile(List<object[]> data, string fileOutputPath, bool shouldReplace = true, char separator = ',')
        {
            fileOutputPath = fileOutputPath.ChangeFileExtension(".csv");

            var csv = new StringBuilder();

            foreach (var line in data)
            {
                string strLine = "";
                foreach (var word in line)
                {
                    strLine += word.ToString() + separator;
                }
                strLine = strLine.Remove(strLine.LastIndexOf(separator));
                csv.AppendLine(strLine);
            }


            try
            {
                if (shouldReplace)
                    File.WriteAllText(fileOutputPath, csv.ToString());
                else
                    File.AppendAllText(fileOutputPath, csv.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
