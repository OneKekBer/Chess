using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum EnumColor
{
    Black  = 0,
    White = 1
}

namespace FigureNamespace
{
    class Figure
    {
        public string icon;
        public int x;
        public int y;
        private EnumColor color;

        public Figure(int x, int y, EnumColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            icon = "def";
        }



        public void ChnageLocation(Tuple<int, int> newCoords)
        { 
            
            x = newCoords.Item2;
            y = newCoords.Item1;
        }


    }


    class Pawn : Figure
    {
        public Pawn(int x, int y, EnumColor color) : base(x, y, color)
        {
            this.icon = color == EnumColor.Black ? "bp" : "wp";
        }
    }
}
