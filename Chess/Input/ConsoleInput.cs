using EngineNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Axis
{
    X = 0,
    Y = 1,
}

namespace Chess.Input
{
    public class ConsoleInput : IInput
    {
        public int InputLetter()
        {
            Console.WriteLine($"Enter x:");

            do
            {
                string userInput = Console.ReadLine();
                if (Enum.TryParse(userInput.ToLower(), out EnumX convertedX))
                {
                    return (int)convertedX;
                }
                Console.WriteLine("Enter a letter!!!");
            }
            while (true);
        }

        public int InputCoordinate(Axis axis) //хотелось бы это вывести из класса
        {
            int value;
            do
            {
                Console.WriteLine($"Enter {axis}:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput.ToLower(), out value))
                {
                    return value;
                }
                Console.WriteLine("Enter a number!!!");

            } while (true);
        }
    }
}
