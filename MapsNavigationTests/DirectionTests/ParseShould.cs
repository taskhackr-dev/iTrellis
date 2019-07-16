using NUnit.Framework;
using MapsNavigation;
using System;

namespace MapsNavigationTests.DirectionTests
{
    public class ParseShould
    {
        [Test]
        public void ThrowAnExceptionForInvalidFormat()
        {
            Assert.Throws<FormatException>(() => Direction.Parse("LR"));
        }

        [Test]
        public void ParseLeftDirection()
        {
            var actual = Direction.Parse("L3");

            Assert.AreEqual(LeftOrRight.Left, actual.Move);
            Assert.AreEqual(3, actual.Blocks);
        }

        [Test]
        public void ParseRightDirection()
        {
            var actual = Direction.Parse("R50");

            Assert.AreEqual(LeftOrRight.Right, actual.Move);
            Assert.AreEqual(50, actual.Blocks);
        }

        [Test]
        public void IgnoreWhiteSpace()
        {
            var actual = Direction.Parse(" R 50  ");

            Assert.AreEqual(LeftOrRight.Right, actual.Move);
            Assert.AreEqual(50, actual.Blocks);
        }

        [Test]
        public void IgnoreCase()
        {
            var right = Direction.Parse("r50");
            var left = Direction.Parse("l2");

            Assert.AreEqual(LeftOrRight.Right, right.Move);
            Assert.AreEqual(LeftOrRight.Left, left.Move);
        }
    }
}
