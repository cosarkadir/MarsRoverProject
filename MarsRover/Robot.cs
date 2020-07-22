namespace MarsRover
{
    /// <summary>
    /// Robot sınıfı
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Robot sınıfı
        /// </summary>
        /// <param name="x">Robotun X koordinat değeri</param>
        /// <param name="y">Robotun Y koordinat değeri</param>
        /// <param name="direction">Robotun yönü</param>
        public Robot(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        /// <summary>
        /// Robotun X koordinat değeri
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Robotun Y koordinat değeri
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Robotun yönü
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Robotun yönünü sola döndürür
        /// </summary>
        public void TurnLeft()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.E;
            }
            else if (Direction == Direction.E)
            {
                Direction = Direction.N;
            }
        }

        /// <summary>
        /// Robotun yönünü sağa döndürür
        /// </summary>
        public void TurnRight()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.E;
            }
            else if (Direction == Direction.E)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.N;
            }
        }

        /// <summary>
        /// Robota adım attırır
        /// </summary>
        public void TakeStep()
        {
            if (Direction == Direction.N && Y < MarsPlateau.Y && MarsPlateau.Y > 0)
            {
                Y++;
            }
            else if (Direction == Direction.E && X < MarsPlateau.X && MarsPlateau.X > 0)
            {
                X++;
            }
            else if (Direction == Direction.W && X > 0)
            {
                X--;
            }
            else if (Direction == Direction.S && Y > 0)
            {
                Y--;
            }
        }
    }
}
