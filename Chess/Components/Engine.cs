using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using FigureNamespace;
using BoardNamespace;

enum EnumX
{
    a = 1,
    b = 2,
    c = 3,
    d = 4,
    e = 5,
    f = 6,
    g = 7,
    h = 8,
}


namespace EngineNamespace
{
    public enum Axis
    {
        X = 0,
        Y = 1,
    }


    class Engine
    {
        public EnumColor CurrentTurn = EnumColor.White;

        private (int x, int y) GetCoords() ////хотелось бы это вывести из класса
        {

            int x1 = XInput();
            int y1 = Input(Axis.Y);

            return (x1, y1);
        }

        private (int x, int y) CalculateAbsoluteCoords((int x, int y) oldCoords, (int x, int y) newCoords) ////хотелось бы это вывести из класса
        {
            return (oldCoords.x - newCoords.x, oldCoords.y - newCoords.y);
        }



        

        private int XInput()
        {
             
            
            Console.WriteLine($"Enter x:");

            do
            {
                string userInput = Console.ReadLine();
                if (Enum.TryParse(userInput.ToLower(), out EnumX convertedX))
                {
                    return (int)convertedX;
                }
                Console.WriteLine("Enter a letter!!!");
            }
            while (true);

        }


        private int Input(Axis axis) //хотелось бы это вывести из класса
        {
            int value;
            do
            {
                Console.WriteLine($"Enter {axis}:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput.ToLower(), out value))
                {
                    return value;
                }
                Console.WriteLine("Enter a number!!!");

            } while (true);
        }


        public void ToggleTurn()
        {
            CurrentTurn = CurrentTurn == EnumColor.White ? CurrentTurn = EnumColor.Black : EnumColor.White;
        }



        public (int x, int y)[] GetFigurePath((int x, int y) oldCoords, (int x, int y) newCoords) 
        {
            return new (int x, int y)[] { (1, 2) };
        }

        public void Turn(Board board)
        {
            (int x, int y) oldCoords = GetCoords();

            Figure currentFigure = board.GetFigureOnTitle(oldCoords);

            if (currentFigure == null)
            {
                Console.WriteLine("There is no figure here!!");
                return;
            }

            (int x, int y) newCoords = GetCoords();


            (int x, int y) absoluteCoords = CalculateAbsoluteCoords(oldCoords, newCoords);

            bool isTurnValid = IsTurnValid(board, currentFigure, oldCoords, newCoords, absoluteCoords);

            if (!isTurnValid)
            {
                Console.WriteLine("Turn is not valid!");
                return;
            }

            board.EditBoard(oldCoords, null);

            board.EditBoard(newCoords, currentFigure);
            currentFigure.Move();

            board.PrintBoard();
            ToggleTurn();
        }


        public bool IsTurnValid(Board board, Figure figure, (int x, int y) oldCoords, (int x, int y) newCoords, (int x, int y) absoluteCoords) 
        {
            var enemyFigure = board.GetFigureOnTitle(newCoords); // search is enemy on title 

            //check whose turn now
            //if (CurrentTurn != figure.color) return false;


            //check on teammates
            if (enemyFigure != null && enemyFigure.color == figure.color) return false;





            if (figure is IFigureStaticMotion staticMotion)
            {
                

                if (figure is Pawn)              
                {
                    foreach ((int x, int y) coord in staticMotion.Directions) // simple turn options
                    {
                        Console.WriteLine(coord == absoluteCoords && enemyFigure is null);
                        if (coord == absoluteCoords && enemyFigure is null)
                        {
                            return true;
                        }
                    }



                    Pawn pawn = (Pawn)figure; // converting figure to pawn 


                    foreach ((int x, int y) coord in pawn.DirectionsOnAttack) // attack options
                    {

                        if (coord == absoluteCoords && enemyFigure is not null)
                        {
                            return true;
                        }
                    }
                    return false;
                }

                foreach ((int x, int y) coord in staticMotion.Directions) // simple turn options
                {
                    if (coord == absoluteCoords)
                    {
                        return true;
                    }
                }

                return false;

            }
            else if (figure is IFigureDynamicMotion dynamicMotion)
            {

                (int x, int y) correctTurnCoords = (0,0);

                

                // this part of code taking turn variants and searching coorect turn variant
                foreach ( (int x, int y ) turnCoords in dynamicMotion.OneStepCoordAdjustment)
                {
                    (int x, int y) currentCoords = absoluteCoords; // maybe currentCoords is incorrect naming of this variable

                    while (currentCoords != (0,0)) 
                    {
                        currentCoords = (currentCoords.x + turnCoords.x, currentCoords.y + turnCoords.y);

                        if (currentCoords.x > 8 || currentCoords.x < -8 || currentCoords.y > 8 || currentCoords.y < -8) break; // we have limit -8;8
                                                                                                                               // if current cords goes out of the limits
                                                                                                                               // it means that current turn variant is incorrect
                        if (currentCoords == (0, 0)) correctTurnCoords = turnCoords;
                        

                    }
                    
                }


                Console.WriteLine(correctTurnCoords);

                //check if there is figure on the way
                while (oldCoords != newCoords)
                {
                    oldCoords = (oldCoords.x + correctTurnCoords.x, oldCoords.y + correctTurnCoords.y);
                    var figureOnTitle = board.GetFigureOnTitle(oldCoords);


                    if(oldCoords == newCoords) break;
                    
                    if(figureOnTitle is not null) return false;
                    Console.WriteLine("OK");


                }

                return true;
            }

          

            return false;
        }


    }
}
