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

        public void ChangeX(int newX)
        {
            x = newX;
        }

        public virtual void Move(Tuple<int, int> newCoords, object[,] board) { }

        public void ChnageLocation(Tuple<int, int> newCoords)
        {
            
        }


    }


    class Pawn : Figure
    {
        public string name = "pawn";
        public Pawn(int x, int y, EnumColor color) : base(x, y, color)
        {
            icon = color == EnumColor.Black ? "bp" : "wp";
           
        }

        public override void Move(Tuple<int, int> newCoords, object[,] board)
        {
            _ = this;

            Console.WriteLine($"{x} {y}");

            Board.EditBoard(new Tuple<int,int>(x, y), board, "o");

            x = newCoords.Item1 - 1;
            y = newCoords.Item2 - 1;

            Console.WriteLine($"{x} {y}");

            board[y, x] = this;
        }


    }




}
