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
}

namespace FigureNamespace
{

    public interface IFigureStaticMotion
    {
        (int x, int y)[] Directions { get; }
    }

    public interface IFigureDynamicMotion 
    {
        (int x, int y)[] OneStepCoordAdjustment { get; }
    }


    public abstract class Figure 
    {
        
        public string icon;


        public EnumColor color;


        public Figure(EnumColor color)
        {
            this.color = color;
        }

        public virtual void Move() { }

        public virtual bool IsTurnValid((int x, int y) newCoords) { return true; }
    }


    class Pawn : Figure, IFigureStaticMotion
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

        public (int x, int y)[] Directions
        {
            get
            {
                if (IsMoved)// ТУТ ПОСТАВИТЬ  IF COLOR == BLACK
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



        public Pawn(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "♙" : "♙";
           
        }

        public override void Move()
        {
            SetIsMove();
        }


    }


    class Kngith : Figure, IFigureStaticMotion
    {
        public Kngith(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "♘" : "♞";

        }

        public (int x, int y)[] Directions
        {
            get
            {
                return new (int x, int y)[]
                {
                    (2,1),
                    (2,-1),
                    (1,2),
                    (1,-2),
                    (-2,1),
                    (-2,-1),
                    (-1,-2), 
                    (1,-2), 
                    (-1, 2) 
                };
                
            }
        }
    }


    class Rook : Figure, IFigureDynamicMotion
    {
        public Rook(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "♖" : "♜";

        }

        public (int x, int y)[] OneStepCoordAdjustment
        {
            get
            {
                return new (int x, int y)[]
                {
                    (1, 0), // right
                    (-1, 0), // left
                    (0, 1), // up
                    (0, -1) // down
                    
                };
            }
        }

    }


    class Bishop : Figure, IFigureDynamicMotion
    {
        public Bishop(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "♗" : "♝";

        }

        public (int x, int y)[] OneStepCoordAdjustment
        {
            get
            {
                return new (int x, int y)[]
                {
                    (-1, -1), // down left
                    (-1, 1), // down right
                    (1, 1), // up right
                    (1, -1) // up left
                    
                };
            }
        }
    }

    class Queen : Figure, IFigureDynamicMotion
    {
        public Queen(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "♕" : "♛";

        }

        public (int x, int y)[] OneStepCoordAdjustment
        {
            get
            {
                return new (int x, int y)[]
                {
                    (-1, -1), // down left
                    (-1, 1), // down right
                    (1, 1), // up right
                    (1, -1), // up left
                    (1, 0), // right
                    (-1, 0), // left
                    (0, 1), // up
                    (0, -1) // down
                    
                };
            }
        }
    }


    class King : Figure, IFigureStaticMotion
    {
 
        public (int x, int y)[] Directions
        {
            get
            {
                return new (int x, int y)[]
                {
                    (-1, -1), // down left
                    (-1, 1), // down right
                    (1, 1), // up right
                    (1, -1), // up left
                    (1, 0), // right
                    (-1, 0), // left
                    (0, 1), // up
                    (0, -1) // down
                };

                

            }
        }



        public King(EnumColor color) : base(color)
        {
            icon = color == EnumColor.Black ? "♔" : "♚";

        }



    }


}
