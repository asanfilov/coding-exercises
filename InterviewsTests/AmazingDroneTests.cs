using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Interviews.Tests
{
    [TestFixture()]
    public class AmazingDroneTests
    {
        private const int P = (int)AmazingDrone.GridObjects.ClearPath;
        private const int W = (int)AmazingDrone.GridObjects.Wall;
        private const int T = (int)AmazingDrone.GridObjects.Target;

        [Test()]
        public void GetShortestPathToTarget_ExampleGrid()
        {
            var drone = new AmazingDrone(GetExampleGrid());
            Assert.AreEqual(3, drone.GetShortestPathToTarget());
        }

        [Test()]
        public void GetShortestPathToTarget_SquareMatrixOf1000()
        {
            int size = AmazingDrone.MaxGridSize;
            var grid = AmazingDroneTestsHelper.GetGridWithSameValues(size, P);
            grid[size - 1][size - 1] = T; //South-East corner
            int shortest = 2 * (size - 1); //since can't move diagonally, count steps south and east

            var drone = new AmazingDrone(grid);

            Assert.AreEqual(shortest, drone.GetShortestPathToTarget());
        }

        [Test()]
        public void GetShortestPathToTarget_SnakePattern()
        {
            var grid = new List<List<int>> {
                new List<int> { P, P, P, P, P, P },
                new List<int> { W, W, W, W, W, P },
                new List<int> { P, P, P, P, P, P },
                new List<int> { P, W, W, W, W, W },
                new List<int> { P, P, P, P, P, P },
                new List<int> { W, W, W, W, W, T }
            };

            var drone = new AmazingDrone(grid);

            Assert.AreEqual(20, drone.GetShortestPathToTarget());
        }

        [Test()]
        public void FindPathToTarget_Exists()
        {
            var drone = new AmazingDrone(GetExampleGrid());
            Assert.NotNull(drone.FindPathToTarget());
        }

        [Test()]
        public void FindPathToTarget_NoPath()
        {
            List<List<int>> grid = new List<List<int>> {
                new List<int> { P, P },
                new List<int> { P, W },
                new List<int> { W, T }};
            var drone = new AmazingDrone(grid);
            Assert.Null(drone.FindPathToTarget());
        }

        [Test()]
        public void IsCellValid_IndexOutsideTheGrid_False()
        {
            var drone = new AmazingDrone(GetExampleGrid());
            Assert.False(drone.IsValidStep(-1, 0));
            Assert.False(drone.IsValidStep(0, -1));
            Assert.False(drone.IsValidStep(-1, -1));

            Assert.False(drone.IsValidStep(3, 0));
            Assert.False(drone.IsValidStep(0, 3));
        }

        [Test()]
        public void IsCellValid_Wall_False()
        {
            var drone = new AmazingDrone(GetExampleGrid());
            Assert.False(drone.IsValidStep(1, 0));
        }

        [Test()]
        public void IsCellValid_ClearPathOrTarget_True()
        {
            var drone = new AmazingDrone(GetExampleGrid());
            Assert.True(drone.IsValidStep(0, 0));
            Assert.True(drone.IsValidStep(2, 1));
        }

        private static List<List<int>> GetExampleGrid()
        {
            return new List<List<int>> {
                new List<int> { P, P, P},
                new List<int> { W, W, T},
                new List<int> { P, P, P }
            };
        }

        internal class AmazingDroneTestsHelper
        {
            internal static List<List<int>> GetGridWithSameValues(int size, int value)
            {
                var grid = new List<List<int>>(size);
                for (int row = 0 ; row < size ; row++)
                {
                    List<int> columns = Enumerable.Repeat(value, size).ToList();
                    grid.Add(columns);
                }

                return grid;
            }
        }
    }
}
