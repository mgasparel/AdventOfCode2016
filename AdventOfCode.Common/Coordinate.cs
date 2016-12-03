namespace AdventOfCode
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate()
        {
        }

        public Coordinate(Coordinate position)
        {
            X = position.X;
            Y = position.Y;
        }
    }
}