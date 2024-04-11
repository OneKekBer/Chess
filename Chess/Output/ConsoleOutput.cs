using BoardNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FigureNamespace;

namespace Chess.Output
{
    public class ConsoleOutput : IOutput
    {

        public void PrintBoard(Board board)
        {
            Figure[,] figures = board.board;

            string[] alfabet = new string[8] { "  a", "b", "c", "d", "e", "f", "g", "h" };

            Console.WriteLine("------------");

            Console.WriteLine(string.Join(" ", alfabet));

            for (int i = 0; i < figures.GetLength(0); i++)
            {
                Console.Write(i + 1 + " ");


                for (int j = 0; j < figures.GetLength(1); j++)
                {

                    if (figures[i, j] != null)
                    {
                        Console.Write(figures[i, j].icon + " ");
                        continue;
                    }


                    Console.Write("· ");

                }
                Console.WriteLine(i + 1 + " ");
            }
            Console.WriteLine(string.Join(" ", alfabet));
        }

    }
}
