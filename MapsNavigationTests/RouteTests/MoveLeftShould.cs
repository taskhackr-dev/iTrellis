using NUnit.Framework;
using MapsNavigation;

namespace MapsNavigationTests.RouteTests
{
    public class MoveLeftShould
    {
        [Test]
        public void MoveWestWhenFacingNorth()
        {
            var position = new Position { Facing = CardinalDirection.North };

            Route.MoveLeft(position, 11);

            Assert.AreEqual(CardinalDirection.West, position.Facing);
            Assert.AreEqual(-11, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void MoveEastWhenFacingSouth()
        {
            var position = new Position { Facing = CardinalDirection.South };

            Route.MoveLeft(position, 2);

            Assert.AreEqual(CardinalDirection.East, position.Facing);
            Assert.AreEqual(2, position.X);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void MoveNorthWhenFacingEast()
        {
            var position = new Position { Facing = CardinalDirection.East };

            Route.MoveLeft(position, 155);

            Assert.AreEqual(CardinalDirection.North, position.Facing);
            Assert.AreEqual(0, position.X);
            Assert.AreEqual(155, position.Y);
        }

        [Test]
        public void MoveSouthWhenFacingWest()
        {
            var position = new Position { Facing = CardinalDirection.West };

            Route.MoveLeft(position, 22);

            Assert.AreEqual(CardinalDirection.South, position.Facing);
            Assert.AreEqual(0, position.X);
            Assert.AreEqual(-22, position.Y);
        }
    }
}
