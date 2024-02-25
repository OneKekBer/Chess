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
            Console.WriteLine("Hello");

            Board board = new Board();

            board.InitializeFigure(new Pawn(0, 1, EnumColor.Black));
            board.InitializeFigure(new Pawn(1, 1, EnumColor.Black));
            board.InitializeFigure(new Pawn(2, 1, EnumColor.Black));

            board.PrintBoard();

            //int userCoords = int.Parse(Console.ReadLine());

            board.GetFigureOnTitle(new Tuple<int, int>(2, 1));






        }
    }
}
