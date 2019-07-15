using System;
using System.Collections.Generic;
using System.Linq;

namespace MapsNavigation
{
    public class Route
    {
        private readonly IEnumerable<Direction> _directions;

        public Route(IEnumerable<Direction> directions)
        {
            _directions = directions;
        }

        public int GetShortestNumberOfBlocksToDestination()
        {
            var position = new Position { Facing = CardinalDirection.North };

            foreach (var direction in _directions)
            {
                if (direction.Move == LeftOrRight.Left)
                {
                    MoveLeft(position, direction.Blocks);
                }

                if (direction.Move == LeftOrRight.Right)
                {
                    MoveRight(position, direction.Blocks);
                }
            }

            return Math.Abs(position.X) + Math.Abs(position.Y);
        }

        public static void MoveRight(Position position, int blocks)
        {
            switch (position.Facing)
            {
                case CardinalDirection.North:
                    position.X += blocks;
                    position.Facing = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    position.Y -= blocks;
                    position.Facing = CardinalDirection.South;
                    break;
                case CardinalDirection.South:
                    position.X -= blocks;
                    position.Facing = CardinalDirection.West;
                    break;
                case CardinalDirection.West:
                    position.Y += blocks;
                    position.Facing = CardinalDirection.North;
                    break;
            }
        }

        public static void MoveLeft(Position position, int blocks)
        {
            switch (position.Facing)
            {
                case CardinalDirection.North:
                    position.X -= blocks;
                    position.Facing = CardinalDirection.West;
                    break;
                case CardinalDirection.East:
                    position.Y += blocks;
                    position.Facing = CardinalDirection.North;
                    break;
                case CardinalDirection.South:
                    position.X += blocks;
                    position.Facing = CardinalDirection.East;
                    break;
                case CardinalDirection.West:
                    position.Y -= blocks;
                    position.Facing = CardinalDirection.South;
                    break;
            }
        }

        public static Route Parse(string directions)
        {
            return Parse(directions.Split(','));
        }

        public static Route Parse(IEnumerable<string> directions)
        {
            return new Route(directions.Select(Direction.Parse));
        }
    }
}
