using System;
namespace MapsNavigation
{
    public struct Direction
    {
        public LeftOrRight Move { get; }
        public int Blocks { get; }

        public Direction(LeftOrRight move, int blocks)
        {
            Move = move;
            Blocks = blocks;
        }

        public static Direction Parse(string dir)
        {
            dir = dir.Replace(" ", "");
            var leftOrRight = char.ToLower(dir[0]);
            var blocks = int.Parse(dir.Substring(1));

            if (leftOrRight != 'l' && leftOrRight != 'r')
            {
                throw new FormatException();
            }

            if (leftOrRight == 'l')
            {
                return new Direction(LeftOrRight.Left, blocks);
            }

            return new Direction(LeftOrRight.Right, blocks);
        }
    }
}
