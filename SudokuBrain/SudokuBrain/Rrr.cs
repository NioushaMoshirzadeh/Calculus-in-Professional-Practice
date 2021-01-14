using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //the Formula :                         y = y + Ps(2*Pe(y) - y) - Pe(y)
            bool step = false;
            FourCube FirstY;                        //instance of the Y
            FirstY = this.fourCube;                 //init with newspaper Sudoku
            FourCube SecondY;                       //instance of the Y'
            FourCube temp; 
            
            
            while (step != true)
            {
                SecondY = FirstY.Equalizer();        // Pe(y)
                SecondY = SecondY.mult(2);           // 2*Pe(y)
                SecondY = FirstY.Subtract(SecondY);  // 2*Pe(y) - y
                SecondY = SecondY.Selector();        // Ps(2*Pe(y) - y)
                temp = FirstY.Equalizer();           // Pe(y)
                SecondY = temp.Subtract(SecondY);    // Ps(2*Pe(y) - y) - Pe(y)
                SecondY = FirstY.Add(SecondY);       // Ps(2*Pe(y) - y) - Pe(y) + y
                SecondY.StepPrinting(temp);
               // step = SecondY.Comparator();
                if (step == false)
                {
                    FirstY = SecondY;
                }
            }
            MessageBox.Show("finished");
            return step;
        }
    }
}
