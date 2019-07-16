using NUnit.Framework;
using MapsNavigation;

namespace MapsNavigationTests.RouteTests
{
    public class ParseShould
    {
        [Test]
        public void AddAllDirectionsToRouteInOrder()
        {
            var route = Route.Parse("L3,L2,L5");
            var expectedDirections = new Direction[]
            {
                new Direction(LeftOrRight.Left, 3),
                new Direction(LeftOrRight.Left, 2),
                new Direction(LeftOrRight.Left, 5)
            };

            CollectionAssert.AreEqual(expectedDirections, route);
        }
    }
}
