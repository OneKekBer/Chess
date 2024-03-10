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

            
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Engine engine = new Engine();

            Board board = new Board();// добавляет и убирает шахматы

            board.Initialize();

           
            while (true)
            {
                engine.Turn(board);
                
            }

        }
    }
}

// todo
// 1 сделать так что если на пути фигуры есть тимейт то ход не возможен ---- 
// 2 доделать все фигуры ---- 
// 3 оформить доску ---- 
// 4 переделать координаты в A 1 ----
