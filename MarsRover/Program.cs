using MarsRover.Exception;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
               

                int x = 0;
                int y = 0;
                Directions compass = Directions.N;
                int areaX = 0;
                int areaY = 0;

                var input = Console.ReadLine().Split();
                areaX = Convert.ToInt32(input[0]);
                areaY = Convert.ToInt32(input[1]);


                for (int i = 0; i < 2; i++)
                {

                    var inputCor = Console.ReadLine().Split();
                    x = Convert.ToInt32(inputCor[0]);
                    y = Convert.ToInt32(inputCor[1]);

                    if (inputCor[2] == "N")
                        compass = Directions.N;
                    if (inputCor[2] == "E")
                        compass = Directions.E;
                    if (inputCor[2] == "W")
                        compass = Directions.W;
                    if (inputCor[2] == "S")
                        compass = Directions.S;



                    string directions = Console.ReadLine();


                    Rover _rover = new Rover(new Position(x, y), new Arena(areaX, areaY), new Logger(), compass);


                    List<Motion> motionList = new List<Motion>();
                    foreach (char directionEvent in directions)
                    {
                        if (directionEvent == 'L')
                            motionList.Add(Motion.TurnLeft);
                        if (directionEvent == 'R')
                            motionList.Add(Motion.TurnRight);
                        if (directionEvent == 'M')
                            motionList.Add(Motion.Move);

                    }

                    _rover.TakeAction(motionList);


                    Console.WriteLine(_rover.MarsRoverPosition.X + " " + _rover.MarsRoverPosition.Y + " " + _rover._currentDirection);

                }
            }
            catch (System.IndexOutOfRangeException ex)
            {

                Logger logger = new Logger();
                logger.AddLog("It's a out of range exception" + ex.InnerException);

                throw new CustomException(1001);
            }
            catch (System.NullReferenceException ex)
            {

                Logger logger = new Logger();
                logger.AddLog("It's a Null Reference Exception"+ex.InnerException);

                throw new CustomException(1002);
            }
            catch (System.InvalidCastException ex)
            {

                Logger logger = new Logger();
                logger.AddLog("It's a out of range exception" + ex.InnerException);

                throw new CustomException(1003);
            }




            Console.ReadKey();
        }

       
    }
}
