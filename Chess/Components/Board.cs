using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FigureNamespace;



namespace BoardNamespace
{
    class Board
    {

        private static readonly int row = 8;
        private static readonly int column = 8;

        public string[,] board = new string[row, column];

        public Board()
        {
            FillBoard();
            //PrintBoard();
        }

        public void InitializeFigure(Figure figure)
        {
            board[figure.y , figure.x ] = figure.icon;

        }


        public void GetFigureOnTitle(Tuple<int, int> coords)
        {
            string item = board[coords.Item2, coords.Item1];

            if (item != "o")
            {
                Console.WriteLine(item);
            }
            //return null;
        }

        public void MoveFigure(Figure figure, Tuple<int, int> newCoords)
        {
            figure.ChnageLocation(newCoords);
        }

        public void CheckFigureOnCoords(Tuple<int, int> coords) 
        {

        }

        void FillBoard()
        {
            //char currentChar = 'A';
            //int value = 1;

            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //if (i == 0 || i == 9)
                    //{
                    //    board[i, j] = Convert.ToString(j + 1);
                    //    continue;
                    //}
                    //if (j == 0 || j == 9)
                    //{
                    //    board[i, j] = Convert.ToString((char)(currentChar));
                    //    currentChar++;
                    //    continue;
                    //}

                    board[i, j] = "o";
                }
            }
        }


        public void PrintBoard()
        {
            //const string WhiteBackground = "\x1b[107m";
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


    }//class
}//ns
