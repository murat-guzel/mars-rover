using System.Collections.Generic;

namespace MarsRover
{
    public class Rover : IRover
    {

        public IPosition MarsRoverPosition { get; set; }
        public IArena MarsRoverArena { get; set; }
        public ILogger MarsRoverLogger { get; set; }
        public Directions _currentDirection;


        public Rover(IPosition position,IArena arena,ILogger logger ,Directions currentDirection)
        {
            MarsRoverPosition = position;
            MarsRoverArena = arena;
            MarsRoverLogger = logger;
            _currentDirection = currentDirection;
        }

        
       
         
        public void TurnLeft()
        {
            MarsRoverLogger.AddLog("TurnLeft");
            switch (_currentDirection)
            {
                case Directions.N:
                    _currentDirection = Directions.W;
                    break;
                case Directions.E:
                    _currentDirection = Directions.N;
                    break;
                case Directions.W:
                    _currentDirection = Directions.S;
                    break;
                case Directions.S:
                    _currentDirection = Directions.E;
                    break;
            }
             


        }
        public void TurnRight()
        {
            MarsRoverLogger.AddLog("TurnRight");
            switch (_currentDirection)
            {
                case Directions.N:
                    _currentDirection = Directions.E;
                    break;
                case Directions.E:
                    _currentDirection = Directions.S;
                    break;
                case Directions.W:
                    _currentDirection = Directions.N;
                    break;
                case Directions.S:
                    _currentDirection = Directions.W;
                    break;
            }

            

        }
        public void Move()
        {
            MarsRoverLogger.AddLog("Move Forward");
            if (_currentDirection == Directions.N)
                MarsRoverPosition.Y++;
            if (_currentDirection == Directions.E)
                MarsRoverPosition.X++;
            if (_currentDirection == Directions.W)
                MarsRoverPosition.X--;
            if (_currentDirection == Directions.S)
                MarsRoverPosition.Y--;

        }

        public void TakeAction(List<Motion> motionList)
        {
            MarsRoverLogger.AddLog("Take an action");
            foreach (var item in motionList)
            {
                switch (item)
                {
                    case Motion.TurnLeft:
                        TurnLeft();
                        break;
                    case Motion.TurnRight:
                        TurnRight();
                        break;
                    case Motion.Move:
                        Move();
                        break;
                    default:
                        break;
                }
            }

            
        }

       

       

    
    }
}
