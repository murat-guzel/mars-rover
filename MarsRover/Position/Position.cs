

namespace MarsRover
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
    }
}
