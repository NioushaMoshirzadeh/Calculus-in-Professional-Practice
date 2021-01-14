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
            //Formula :                             y = y + Ps(2*Pe(y) - y) - Pe(y)
            bool step = false;
            FourCube FirstY;                        //instance of the Y
            FirstY = this.fourCube;                 //init with newspaper Sudoku
            FourCube SecondY;                       //instance of the Y'
            FourCube temp, Ps;
            UInt16 loop = 0;
            while (step != true)
            {
                ++loop;
                SecondY = FirstY.Equalizer();        // Pe(y)
                SecondY = SecondY.mult(2);           // 2*Pe(y)
                SecondY = FirstY.Subtract(SecondY);  // 2*Pe(y) - y
                SecondY = SecondY.Selector();        // Ps(2*Pe(y) - y)
                Ps = SecondY;
                temp = FirstY.Equalizer();           // Pe(y)
                SecondY = temp.Subtract(SecondY);    // Ps(2*Pe(y) - y) - Pe(y)
                SecondY = FirstY.Add(SecondY);       // Ps(2*Pe(y) - y) - Pe(y) + y
                step = SecondY.Comparator(Ps,temp);
                if (!step)
                {
                    FirstY = SecondY;
                }
                else
                {
                    int[,] array = SecondY.SudokuAnswer(SecondY);
                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine("\n");
                        for (int j = 0; j < 9; j++)
                        {
                            Console.Write(" {0} ",array[i,j]);
                        }
                    }
                }
            }
           
            MessageBox.Show("finished");
            return step;
        }
        


    }
}
