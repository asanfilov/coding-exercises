using System.Collections.Generic;

using NUnit.Framework;

namespace Interviews.Tests
{
    [TestFixture()]
    public class AmazingDroneTests
    {
        private AmazingDrone drone;

        private List<List<int>> exampleGrid = new List<List<int>> {
                new List<int> { (int)AmazingDrone.MapObjects.ClearPath, (int)AmazingDrone.MapObjects.ClearPath, (int)AmazingDrone.MapObjects.ClearPath},
                new List<int> { (int)AmazingDrone.MapObjects.Wall, (int)AmazingDrone.MapObjects.Wall, (int)AmazingDrone.MapObjects.Target},
                new List<int> { (int)AmazingDrone.MapObjects.ClearPath, (int)AmazingDrone.MapObjects.ClearPath , (int)AmazingDrone.MapObjects.ClearPath }
            };

        [Test()]
        public void GetShortestPathToTargetTest()
        {
            drone = new AmazingDrone( exampleGrid );
            Assert.AreEqual( 3, drone.GetShortestPathToTarget() );
        }

        [Test()]
        public void FindPathToTarget_Exists()
        {
            drone = new AmazingDrone( exampleGrid );
            Assert.NotNull( drone.FindPathToTarget() );
        }

        [Test()]
        public void FindPathToTarget_NoPath()
        {
            List<List<int>> grid = new List<List<int>> {
                new List<int> { (int)AmazingDrone.MapObjects.ClearPath, (int)AmazingDrone.MapObjects.Wall },
                new List<int> { (int)AmazingDrone.MapObjects.ClearPath, (int)AmazingDrone.MapObjects.Wall },
                new List<int> { (int)AmazingDrone.MapObjects.Wall, (int)AmazingDrone.MapObjects.Target }};
            drone = new AmazingDrone( grid );
            Assert.Null( drone.FindPathToTarget() );
        }

        [Test()]
        public void IsCellValid_IndexOutsideTheGrid_False()
        {
            drone = new AmazingDrone( exampleGrid );
            Assert.False( drone.IsValidStep( -1, 0 ) );
            Assert.False( drone.IsValidStep( 0, -1 ) );
            Assert.False( drone.IsValidStep( -1, -1 ) );

            Assert.False( drone.IsValidStep( 3, 0 ) );
            Assert.False( drone.IsValidStep( 0, 3 ) );
        }

        [Test()]
        public void IsCellValid_Wall_False()
        {
            drone = new AmazingDrone( exampleGrid );
            Assert.False( drone.IsValidStep( 1, 0 ) );
        }

        [Test()]
        public void IsCellValid_ClearPathOrTarget_True()
        {
            drone = new AmazingDrone( exampleGrid );
            Assert.True( drone.IsValidStep( 0, 0 ) );
            Assert.True( drone.IsValidStep( 2, 1 ) );
        }
    }
}
