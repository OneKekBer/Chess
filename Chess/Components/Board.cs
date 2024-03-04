using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FigureNamespace;


namespace BoardNamespace
{

    

    class Board
    {

        private static readonly int row = 8;
        private static readonly int column = 8;

        public Figure[,] board = new Figure[row, column]; // object = figure    empty == null 


        public void PlaceFigure(Figure figure, (int x, int y) coords) // intitalizing.....
        {
            board[coords.y - 1, coords.x - 1] = figure;
        }

        public void EditBoard((int x, int y) coords, Figure figure)
        {
            board[coords.y == 0 ? coords.y : coords.y - 1, coords.x == 0 ? coords.x : coords.x - 1] = figure;  
        }


        public Figure GetFigureOnTitle((int x, int y) coords) // я считаю здесь сделано умом
        {
            (int x, int y) = coords;

            x = x == 0 ? x : x - 1; 
            y = y == 0 ? y : y - 1;

            Figure item;

            try 
            {
                item = board[y,x];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid !! {ex}");
                return null;
            }
            
            return item != null ? (Figure)item : null;

            

        }

        //public void Turn()
        //{

        //    Figure currentFigure = GetFigureOnTitle(coords);

        //    if (currentFigure == null)
        //    {
        //        Console.WriteLine("There is no figure here!!");
        //        return;
        //    }


        //    // idea for validation is class validator with switch case 

        //    //validation only in board or only in figure class 


        //    (int x, int y) newCoords = WriteCoords();

        //    //Console.WriteLine($"{currentFigure.x} {currentFigure.y}");



        //    bool isTurnValid = currentFigure.IsTurnValid(newCoords); // кто должен валидировать ход
        //                                                             // фигура или доска или какой то движок игры мб
        //                                                             // но пока у меня будет валидация и в фигуре и доске 
        //    //Console.WriteLine($"{isTurnValid}");

        //    if (!isTurnValid)
        //    {
        //        Console.WriteLine("Turn is not valid!");
        //        return;
        //    }

        //    currentFigure.Move(newCoords);



        //    EditBoard(newCoords, currentFigure); // проблема в том что внутри фигуры меняется x y и
        //                                         // они почти ни на что не влияют(онли валидацию) а
        //                                         // этот метод делает то что должна делать фигра я думаю это не по ооп!! 

        //    EditBoard(coords, "o");

        //    PrintBoard();

        //}



        

      

        void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = null;
                }
            }
        }


        public void PrintBoard()
        {
            //Console.Clear();
            Console.WriteLine("------------");
      
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != null)
                    {
                        Console.Write(board[i, j].icon + "\t");
                        continue;
                    }
                    Console.Write("o" + "\t");
                }
                Console.WriteLine();
            }
        }


        


    }//class


}//ns
