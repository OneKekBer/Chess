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

        public Figure[,] board = new Figure[row, column]; // object = figure    empty == null 


        public void PlaceFigure(Figure figure, (int x, int y) coords) // intitalizing.....
        {
            board[coords.y - 1, coords.x - 1] = figure;
        }

        public void EditBoard((int x, int y) coords, Figure figure)
        {
            board[coords.y == 0 ? coords.y : coords.y - 1, coords.x == 0 ? coords.x : coords.x - 1] = figure;  
        }


        public void Initialize()
        {
            PlaceFigure(new Pawn(EnumColor.Black), (1, 2)); // шахмате не нужно знать ее коорды 
            PlaceFigure(new Pawn(EnumColor.Black), (2, 2)); // перемещение шахмат изменением индексов 
            PlaceFigure(new Pawn(EnumColor.Black), (3, 2));
            PlaceFigure(new Pawn(EnumColor.Black), (4, 2));
            PlaceFigure(new Pawn(EnumColor.Black), (5, 2));
            PlaceFigure(new Pawn(EnumColor.Black), (6, 2));
            PlaceFigure(new Pawn(EnumColor.Black), (7, 2));
            PlaceFigure(new Pawn(EnumColor.Black), (8, 2));


            PlaceFigure(new Kngith(EnumColor.Black), (2, 1));
            PlaceFigure(new Kngith(EnumColor.Black), (7, 1));

            PlaceFigure(new Rook(EnumColor.Black), (1, 1));
            PlaceFigure(new Rook(EnumColor.Black), (8, 1));

            PlaceFigure(new Bishop(EnumColor.Black), (3, 1));
            PlaceFigure(new Bishop(EnumColor.Black), (6, 1));

            PlaceFigure(new Queen(EnumColor.Black), (4, 1));

            PlaceFigure(new King(EnumColor.Black), (5, 1));




            PlaceFigure(new Pawn(EnumColor.White), (1, 7)); // шахмате не нужно знать ее коорды 
            PlaceFigure(new Pawn(EnumColor.White), (2, 7)); // перемещение шахмат изменением индексов 
            PlaceFigure(new Pawn(EnumColor.White), (3, 7));
            PlaceFigure(new Pawn(EnumColor.White), (4, 7));
            PlaceFigure(new Pawn(EnumColor.White), (5, 7));
            PlaceFigure(new Pawn(EnumColor.White), (6, 7));
            PlaceFigure(new Pawn(EnumColor.White), (7, 7));
            PlaceFigure(new Pawn(EnumColor.White), (8, 7));


            PlaceFigure(new Kngith(EnumColor.White), (2, 8));
            PlaceFigure(new Kngith(EnumColor.White), (7, 8));

            PlaceFigure(new Rook(EnumColor.White), (1, 8));
            PlaceFigure(new Rook(EnumColor.White), (8, 8));

            PlaceFigure(new Bishop(EnumColor.White), (3, 8));
            PlaceFigure(new Bishop(EnumColor.White), (6, 8));

            PlaceFigure(new Queen(EnumColor.White), (4, 8));

            PlaceFigure(new King(EnumColor.White), (5, 8));








            PrintBoard();
        }

        public Figure GetFigureOnTitle((int x, int y) coords) // я считаю здесь сделано умом
        {
            (int x, int y) = coords;

            x = x == 0 ? x : x - 1; 
            y = y == 0 ? y : y - 1;

            Figure item;

            try 
            {
                item = board[y,x];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid !! {ex}");
                return null;
            }
            
            return item != null ? item : null;

           
        }


        void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = null;
                }
            }
        }


        public void PrintBoard()
        {
            //Console.Clear();

            Console.WriteLine("------------");
            Console.WriteLine("\t a \t" + "b \t" + "c \t" + "d \t" + "e \t" + "f \t" + "g \t" + "h \t");
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(i + 1 + "\t");
                

                for (int j = 0; j < board.GetLength(1); j++)
                {

                    if (board[i, j] != null)
                    {
                        Console.Write(board[i, j].icon + "\t");
                        continue;
                    }
                    
                    Console.Write("o" + "\t");

                }
                Console.WriteLine(i + 1);

                
            }

            Console.WriteLine();
            Console.WriteLine("\t a \t" + "b \t" + "c \t" + "d \t" + "e \t" + "f \t" + "g \t" + "h \t");

        }





    }//class


}//ns
