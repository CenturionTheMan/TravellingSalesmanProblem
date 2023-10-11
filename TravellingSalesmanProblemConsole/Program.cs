using System.Diagnostics;
using TravellingSalesmanProblemLibrary;

WorldMap map = new WorldMap(7);
map.FillMapRandom(1, 100);

Stopwatch sw = Stopwatch.StartNew();

sw.Start();
var bestPath = BruteForce.GetBestPath(map);
sw.Stop();

Console.WriteLine(sw.Elapsed);