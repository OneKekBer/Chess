using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BoardNamespace;

enum EnumColor
{
    Black  = 0,
    White = 1,
    Empty = 2
}

namespace FigureNamespace
{

    public interface IFgiure
    {
        public bool IsTurnValid(Tuple<int, int> newCoords);

    }

    class Figure 
    {
        
        public string icon;
        public int x {  get; set; }
        public int y {  get; set; }
        public EnumColor color;

        public Figure(int x, int y, EnumColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            icon = "jjj";
        }

        public virtual void Move(Tuple<int, int> newCoords) { }

        public virtual bool IsTurnValid(Tuple<int, int> newCoords) { return true; }
    }


    class Pawn : Figure
    {
        public string name = "pawn";
        public Pawn(int x, int y, EnumColor color) : base(x, y, color)
        {
            icon = color == EnumColor.Black ? "bp" : "wp";
           
        }

        public override bool IsTurnValid(Tuple<int, int> newCoords)
        {
            //Console.WriteLine($"y1 {y}");
            //Console.WriteLine($"y2 {newCoords.Item2}");

            //Console.WriteLine($"x1 {x}");
            //Console.WriteLine($"x1 {newCoords.Item1}");

            Console.WriteLine((y - newCoords.Item2 == -2 || y - newCoords.Item2 == 2) && x == newCoords.Item1);

            if ((y - newCoords.Item2  == -2 || y - newCoords.Item2 == 2) && x == newCoords.Item1)
            {
                return false;
            }
            return true;
        }

        public override void Move(Tuple<int, int> newCoords)
        {
            
            x = newCoords.Item1 - 1;
            y = newCoords.Item2 - 1;


        }


    }




}
