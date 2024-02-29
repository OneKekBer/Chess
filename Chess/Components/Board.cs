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
        public const string emptyIcon = "o";


        private static readonly int row = 8;
        private static readonly int column = 8;

        public object[,] board = new object[row, column];



        public Board()
        {
            FillBoard();
            //PrintBoard();
        }

        public void InitializeFigure(Figure figure)
        {
            board[figure.y - 1 , figure.x - 1  ] = figure;
        }

        public void EditBoard<T>(Tuple<int,int> coords, T val)
        {
            board[coords.Item2 == 0 ? coords.Item2 : coords.Item2 - 1, coords.Item1 == 0 ? coords.Item1 : coords.Item1 - 1] = val;
        }


        public Figure GetFigureOnTitle(Tuple<int, int> coords)
        {
            int x = coords.Item1 == 0 ? coords.Item1 : coords.Item1 - 1;
            int y = coords.Item2 == 0 ? coords.Item2 : coords.Item2 - 1;
            var item = board[y,x ];

            return item != emptyIcon ? (Figure)item : null;

        }

        public void Turn()
        {

            Tuple<int, int> coords = WriteCoords();

            Figure currentFigure = GetFigureOnTitle(coords);

            if (currentFigure == null)
            {
                Console.WriteLine("There is no figure here!!");
                return;
            }

            Tuple<int, int> newCoords = WriteCoords();

            Console.WriteLine($"{currentFigure.x} {currentFigure.y}");



            bool isTurnValid = currentFigure.IsTurnValid(newCoords);

            if (isTurnValid)
            {
                Console.WriteLine("Turn is not valid!");
                return;
            }
            currentFigure.Move(newCoords);

            EditBoard(newCoords, currentFigure);

            EditBoard(coords, "o");

            PrintBoard();
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

                    board[i, j] = emptyIcon;
                }
            }
        }


        public void PrintBoard()
        {
            //Console.Clear();
            Console.WriteLine("------------");
      
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] is Figure)
                    {
                        Console.Write(((Figure)board[i, j]).icon + "\t");
                        continue;
                    }
                    Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        public static Tuple<int, int> WriteCoords()
        {
            Console.WriteLine("Enter X");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y");
            int y1 = int.Parse(Console.ReadLine());

            Tuple<int, int> coords = new Tuple<int, int>(x1, y1);

            return coords;
        }


    }//class




}//ns
