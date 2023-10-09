namespace TravellingSalesmanProblemUnitTest
{
    public class BruteForceTest
    {
        [Fact]
        public void Scenario1Test()
        {
            WorldMap map = new(4);

            map.SetDistance(0, 1, 10);
            map.SetDistance(0, 3, 20);
            map.SetDistance(0, 2, 15);

            map.SetDistance(1, 3, 25);
            map.SetDistance(1, 2, 35);

            map.SetDistance(2, 3, 30);

            var bestPath = BruteForce.GetBestPath(map);

            Assert.NotNull(bestPath);

            if (bestPath == null) return;

            Assert.Equal(80, bestPath.Value.cost);
            Assert.Equal(map.GetCitiesAmount + 1, bestPath.Value.path.Length);
            Assert.Equal(new int[] { 0, 1, 3, 2, 0 }, bestPath.Value.path);
        }

        [Fact]
        public void Scenario2Test()
        {
            WorldMap map = new(6);

            map.SetDistance(0, 1, 16, false);
            map.SetDistance(1, 2, 21, false);
            map.SetDistance(2, 3, 12, false);
            map.SetDistance(3, 1, 9, false);
            map.SetDistance(3, 4, 15, true);
            map.SetDistance(4, 5, 16, true);
            map.SetDistance(5, 0, 34, false);
            map.SetDistance(5, 2, 7, false);


            var bestPath = BruteForce.GetBestPath(map);

            Assert.NotNull(bestPath);

            if (bestPath == null) return;

            Assert.Equal(114, bestPath.Value.cost);
            Assert.Equal(map.GetCitiesAmount + 1, bestPath.Value.path.Length);
            Assert.Equal(new int[] { 0, 1, 2, 3, 4, 5, 0 }, bestPath.Value.path);
        }

        [Fact]
        public void Scenario3Test()
        {
            WorldMap map = new(4);

            map.SetDistance(0, 1, 12);
            map.SetDistance(0, 2, 14);
            map.SetDistance(0, 3, 17);
            map.SetDistance(1, 2, 15);
            map.SetDistance(1, 3, 18);
            map.SetDistance(2, 3, 29);

            var bestPath = BruteForce.GetBestPath(map);

            Assert.NotNull(bestPath);

            if (bestPath == null) return;

            Assert.Equal(64, bestPath.Value.cost);
            Assert.Equal(map.GetCitiesAmount + 1, bestPath.Value.path.Length);
            Assert.Equal(new int[] { 0, 2, 1, 3, 0 }, bestPath.Value.path);
        }

        [Fact]
        public void Scenario4Test()
        {
            int?[,] grid = { { 0, 10, 15, 20 },
                           { 10, 0, 35, 25 },
                           { 15, 35, 0, 30 },
                           { 20, 25, 30, 0 } };
            WorldMap map = new(grid);
           
            var bestPath = BruteForce.GetBestPath(map);

            Assert.NotNull(bestPath);

            if (bestPath == null) return;

            Assert.Equal(80, bestPath.Value.cost);
            Assert.Equal(map.GetCitiesAmount + 1, bestPath.Value.path.Length);
        }

    }
}