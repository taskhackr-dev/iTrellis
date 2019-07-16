namespace MapsNavigation
{
    /// <summary>
    /// A cardinally oriented two-dimensional point.
    /// </summary>
    public class Position
    {
        public CardinalDirection Facing { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
