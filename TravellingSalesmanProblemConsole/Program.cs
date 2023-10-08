using TravellingSalesmanProblemLibrary;

WorldMap map = new(4);

map.SetDistance(0, 1, 10);
map.SetDistance(0, 3, 20);
map.SetDistance(0, 2, 15);

map.SetDistance(1, 3, 25);
map.SetDistance(1, 2, 35);

map.SetDistance(2, 3, 30);

Console.WriteLine(map);

var res = BruteForce.GetBestPath(map);

Console.WriteLine(res.ToStringCustom());