

namespace MarsRover
{
    public class Arena : IArena
    {


        public int X { get; set; }

        public int Y { get; set; }

        public Arena(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }


        public bool RoverInside(IPosition position)
        {
            bool isInside = false;
            if (position.X <= X && position.Y <= Y)
                isInside = true;

            return isInside;
        }

    }
}
