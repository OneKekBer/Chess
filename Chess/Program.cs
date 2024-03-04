using System;
using BoardNamespace;
using FigureNamespace;

using EngineNamespace;



namespace Program
{
    class Program
    {
        

        public static void Main()
        {

            

            //Console.OutputEncoding = System.Text.Encoding.UTF16;

            //Player player1 = new Player(EnumColor.Black);

            Engine engine = new Engine();

            Board board = new Board();// добавляет и убирает шахматы

            board.PlaceFigure(new Pawn(EnumColor.Black), (1, 2)); // шахмате не нужно знать ее коорды 
            board.PlaceFigure(new Pawn(EnumColor.Black), (2, 2)); // перемещение шахмат изменением индексов 
            board.PlaceFigure(new Pawn(EnumColor.Black), (3, 2));


            board.PlaceFigure(new Pawn(EnumColor.White), (1, 7));


            board.PrintBoard();

            //add class game engine который будет отвечать за правила и валидацию
            
            while (true)
            {

                engine.Turn(board);

                
            }

        }
    }
}
