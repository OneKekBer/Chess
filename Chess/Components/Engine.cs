using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using FigureNamespace;
using BoardNamespace;



namespace EngineNamespace
{
    class Engine
    {

        private (int x, int y) CalculateAbsoluteCoords((int x, int y) oldCoords, (int x, int y) newCoords)
        {
            return (oldCoords.x - newCoords.x, oldCoords.y - newCoords.y);
        }

        public EnumColor CurrentTurn = EnumColor.Black;



        public void ToggleTurn()
        {
            CurrentTurn = CurrentTurn == EnumColor.White ? CurrentTurn = EnumColor.Black : EnumColor.White;
        }


        public (int x, int y) GetCoords()
        {
            Console.WriteLine("Enter X");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y");
            int y1 = int.Parse(Console.ReadLine());

            return (x1, y1);
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
            Figure enemyFigure = board.GetFigureOnTitle(newCoords); // search is enemy on title 

            //check whose turn now
            if (!(CurrentTurn == figure.color)) return false;


            //check on teammates
            if (enemyFigure != null && enemyFigure.color == figure.color) return false;
             



            if (figure is Pawn) // special validtaion for pawn)
                                // prehaps problem with reading this code
            {
                Pawn pawn = (Pawn)figure; // converting figure to pawn 


                foreach ((int x, int y) coord in pawn.DirectionsOnAttack) // attack options
                {
                    //Console.WriteLine(enemyFigure is Figure);
                    //Console.WriteLine(coord == absoluteCoords);

                    //Console.WriteLine($"absolute {absoluteCoords}");


                    if (coord == absoluteCoords && enemyFigure is Figure)
                    {
                        return true;
                    }
                }

                foreach ((int x, int y) coord in figure.Directions) // simple turn options
                {
                    //Console.WriteLine($"simple {coord}");

                    if (coord == absoluteCoords && enemyFigure == null)
                    {
                        return true;
                    }
                }

                return false;
            }




            foreach ( (int x, int y) coord in figure.Directions)
            {
                Console.WriteLine(absoluteCoords);
                Console.WriteLine(coord);


                if (coord  == absoluteCoords)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
