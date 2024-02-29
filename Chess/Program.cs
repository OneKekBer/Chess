using System;
using BoardNamespace;
using FigureNamespace;


namespace Program
{
    class Program
    {
        public static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Board board = new Board();

            board.InitializeFigure(new Pawn(1, 2, EnumColor.Black));
            board.InitializeFigure(new Pawn(2, 2, EnumColor.Black));
            board.InitializeFigure(new Pawn(3, 2, EnumColor.Black));


            board.InitializeFigure(new Pawn(2, 7, EnumColor.White));


            board.PrintBoard();

            while (true)
            {
                board.Turn();

            }

        }
    }
}
