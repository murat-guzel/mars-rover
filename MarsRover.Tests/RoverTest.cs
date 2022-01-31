using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTest
    {


        public static object[] _sourceLists = {
                
                new object[] { Directions.N, 1, 2, 5, 5, new List<Motion>() { Motion.TurnLeft, Motion.Move, Motion.TurnLeft, Motion.Move, Motion.TurnLeft, Motion.Move, Motion.TurnLeft, Motion.Move, Motion.Move },1,3,Directions.N },
                //case 1

                  new object[] { Directions.E, 3, 3, 5, 5, new List<Motion>() { Motion.Move, Motion.Move, Motion.TurnRight, Motion.Move, Motion.Move, Motion.TurnRight,
                      Motion.Move, Motion.TurnRight, Motion.TurnRight,Motion.Move },5,1,Directions.E },
                //case 2

                   new object[] { Directions.S, 1, 3, 5, 5, new List<Motion>() { Motion.TurnRight, Motion.Move, Motion.Move, Motion.TurnRight,
                       Motion.TurnRight,Motion.Move },0,3,Directions.E },
                //case 3

                    new object[] { Directions.W, 2, 4, 5, 5, new List<Motion>() { Motion.TurnRight, Motion.TurnRight, Motion.Move, Motion.Move, Motion.TurnRight,
                      Motion.Move, Motion.TurnRight, Motion.TurnRight,Motion.Move },4,4,Directions.N },
                //case 4
                                    
                                    };

        [Test, TestCaseSource("_sourceLists")]
        public void DIRECTION_with_positionanddirection_controlresult(Directions direction, int x, int y, int arenaX, int arenaY, List<Motion> motionList, int resultX, int resultY, Directions resultDirection)
        {
            Position position = new Position(x, y);
            Arena arena = new Arena(arenaX, arenaY);
            Logger logger = new Logger();
            Position Resultposition = new Position(resultX, resultY);
           

            var rover = new Rover(position, arena, logger ,direction);
           
            rover.TakeAction(motionList);


            Assert.AreEqual(rover.MarsRoverPosition.X, Resultposition.X);
            Assert.AreEqual(rover.MarsRoverPosition.Y, Resultposition.Y);
            Assert.AreEqual(rover._currentDirection, resultDirection);

        }

        [Test, TestCaseSource("_sourceLists")]
        public void ARENA_is_inside_area_rover(Directions direction, int x, int y, int arenaX, int arenaY, List<Motion> motionList, int resultX, int resultY, Directions resultDirection)
        {
            Position position = new Position(x, y);
            Arena arena = new Arena(arenaX, arenaY);
            Position Resultposition = new Position(resultX, resultY);
            Logger logger = new Logger();


            var rover = new Rover(position, arena,logger,direction);

            rover.TakeAction(motionList);
            bool IsInside = arena.RoverInside(rover.MarsRoverPosition);


            Assert.AreEqual(IsInside, true);
            

        }

        [TestCase(Directions.N,Motion.TurnLeft,Motion.TurnRight,Directions.N)]
        public void DIRECTION_only_direction_test(Directions direction,Motion m1,Motion m2, Directions resultdirection)
        {
            //MOCK***
            Position position = new Position(1, 1);
            Arena arena = new Arena(5, 5);
            Logger logger = new Logger(); 


            var rover = new Rover(position, arena, logger, direction);

            List<Motion> motionList = new List<Motion>();
            motionList.Add(m1);
            motionList.Add(m2);
            rover.TakeAction(motionList);


            Assert.AreEqual(resultdirection, rover._currentDirection);

        }

        [TestCase(1,Directions.E,Motion.Move, Motion.Move, 3)]
        public void DIRECTION_only_move_test(int start,Directions direction,Motion m1,Motion m2,int finish)
        {
            //MOCK***
            Position position = new Position(start, 1);
            Arena arena = new Arena(5, 5);
            Logger logger = new Logger(); 


            var rover = new Rover(position, arena, logger, direction);
            List<Motion> motionList = new List<Motion>();
            motionList.Add(m1);
            motionList.Add(m2);
            rover.TakeAction(motionList);


            Assert.AreEqual(rover.MarsRoverPosition.X, finish);
        }
    }
}
