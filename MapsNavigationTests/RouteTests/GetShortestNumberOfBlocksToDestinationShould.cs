using NUnit.Framework;
using MapsNavigation;

namespace MapsNavigationTests.RouteTests
{
    public class GetShortestNumberOfBlocksToDestinationShould
    {
        [Test]
        public void GetTheNumberOfBlocks()
        {
            var directions = new Direction[]
            {
                new Direction(LeftOrRight.Left, 3),
                new Direction(LeftOrRight.Right, 2),
                new Direction(LeftOrRight.Left, 5),
                new Direction(LeftOrRight.Right, 1),
                new Direction(LeftOrRight.Left, 1),
                new Direction(LeftOrRight.Left, 2)
            };
            var route = new Route(directions);

            Assert.AreEqual(10, route.GetShortestNumberOfBlocksToDestination());
        }

        [Test]
        public void GetZeroBlocksWhenNoDirectionsAreProvided()
        {
            var route = new Route(new Direction[0]);
            Assert.AreEqual(0, route.GetShortestNumberOfBlocksToDestination());
        }
    }
}
