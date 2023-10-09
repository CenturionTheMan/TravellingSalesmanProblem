using TravellingSalesmanProblemLibrary;

WorldMap map = new(4);

map.SetDistance(0, 1, 12);
map.SetDistance(0, 2, 14);
map.SetDistance(0, 3, 17);
map.SetDistance(1, 2, 15);
map.SetDistance(1, 3, 18);
map.SetDistance(2, 3, 29);

var bestPath = BruteForce.GetBestPath(map);

Console.WriteLine(bestPath.ToStringCustom());