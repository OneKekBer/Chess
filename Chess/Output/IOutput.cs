using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using BoardNamespace;



namespace Chess.Output
{
    public interface IOutput
    {
        void PrintBoard(Board board);
    }
}
