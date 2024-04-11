using System;
using BoardNamespace;
using FigureNamespace;

using EngineNamespace;
using Chess.Input;
using Chess.Output;



namespace Program
{
    class Program
    {
        

        public static void Main()
        {
            IInput input = new ConsoleInput();

            IOutput output = new ConsoleOutput();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Engine engine = new Engine(input, output);

            Board board = new Board();

            

            board.Initialize();
           
            while (true)
            {
                engine.Turn(board);
                
            }

        }
    }
}

