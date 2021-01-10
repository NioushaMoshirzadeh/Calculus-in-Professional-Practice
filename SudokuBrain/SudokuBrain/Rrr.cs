using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBrain
{
    public class Rrr
    {
        FourCube fourCube;
        public Rrr(int[,] Sudoku)
        {
            this.fourCube = new FourCube(Sudoku);
        }
        public bool Step()
        {
            //the Formula is y = y + Ps(2*Pe(y) - y) - Pe(y)
            if (true)
            {
                fourCube = fourCube.Equalizer(); //eq
                fourCube = fourCube.mult(2);     //*2 
                return true;
            }
            
        }
    }
}
