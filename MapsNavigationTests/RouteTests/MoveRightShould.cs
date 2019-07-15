using NUnit.Framework;
using MapsNavigation;

namespace MapsNavigationTests.RouteTests
{
    public class MoveRightShould
    {
        [Test]
        public void MoveEastWhenFacingNorth()
        {
            var position = new Position { Facing = CardinalDirection.North };

            Route.MoveRight(position, 3);

            Assert.AreEqual(CardinalDirection.East, position.Facing);
            Assert.AreEqual(3, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void MoveWestWhenFacingSouth()
        {
            var position = new Position { Facing = CardinalDirection.South };

            Route.MoveRight(position, 2);

            Assert.AreEqual(CardinalDirection.West, position.Facing);
            Assert.AreEqual(-2, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void MoveSouthWhenFacingEast()
        {
            var position = new Position { Facing = CardinalDirection.East };

            Route.MoveRight(position, 188);

            Assert.AreEqual(CardinalDirection.South, position.Facing);
            Assert.AreEqual(0, position.X);
            Assert.AreEqual(-188, position.Y);
        }

        [Test]
        public void MoveNorthWhenFacingWest()
        {
            var position = new Position { Facing = CardinalDirection.West };

            Route.MoveRight(position, 39);

            Assert.AreEqual(CardinalDirection.North, position.Facing);
            Assert.AreEqual(0, position.X);
            Assert.AreEqual(39, position.Y);
        }
    }
}
