using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BoardNamespace;

public enum EnumColor
{
    Black  = 0,
    White = 1,
    Empty = 2
}

namespace FigureNamespace
{

  

    abstract class Figure 
    {
        
        public string icon;

        public abstract (int x, int y)[] Directions { get; }


        public EnumColor color;


        public Figure(EnumColor color)
        {
            this.color = color;
            icon = "F";
        }

        public virtual void Move() { }

        public virtual bool IsTurnValid((int x, int y) newCoords) { return true; }
    }


    class Pawn : Figure
    {
      
        private bool IsMoved = false;

        public (int x, int y)[] DirectionsOnAttack
        {
            get
            {
                return new (int x, int y)[]
                {
                    (1, 1), (-1, 1),(1, -1), (-1, -1),
                };
            }
        }

        public override (int x, int y)[] Directions
        {
            get
            {
                if (IsMoved)
                {
                    return new (int x, int y)[] 
                    {
                        (0, 1),(0, -1)
                    };

                }
                return new (int x, int y)[]
                {
                    (0, 2), (0, 1),(0, -2), (0, -1)
                };

            }
        }
        

        public void SetIsMove() 
        {
            IsMoved = true;
        }



        public Pawn(EnumColor color) : base( color)
        {
            icon = color == EnumColor.Black ? "bp" : "wp";
           
        }

        

        //public override bool IsTurnValid((int x, int y) newCoords)
        //{
        //    //Console.WriteLine($"y1 {y}");
        //    //Console.WriteLine($"y2 {newCoords.Item2}");

        //    //Console.WriteLine($"x1 {x}");
        //    //Console.WriteLine($"x1 {newCoords.Item1}");

        //    //if(x == null) return false; //null check

        //    //if (board[] == 'o') return false; 
            
        //    //if (Math.Abs(y - newCoords.Item2) <= 2 && x == newCoords.Item1) // pawn`s ability 
        //    //{   
        //    //    return true;
        //    //}
        //    //return false;
        //}

        public override void Move()
        {

            SetIsMove();

        }


    }


    class Kngith : Figure
    {
        public Kngith(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "bK" : "wk";

        }

        public override (int x, int y)[] Directions
        {
            get
            {
                return new (int x, int y)[] 
                {

                };
            }
        }
    }



}
