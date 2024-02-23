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
        private int x;
        private int y;
        private EnumColor color;

        public Figure(int x, int y, EnumColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }



    }


    class Pawn : Figure
    {
        public Pawn(int x, int y, EnumColor color) : base(x, y, color) {}

        

        public void Step()
        {

        }

    }
}
