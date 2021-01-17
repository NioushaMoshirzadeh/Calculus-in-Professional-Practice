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
        int[,] arrayAnswer;
        List<int> diffList = new List<int>();
        int diff = 0;
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
                //Array.Clear(arrayAnswer, 0, arrayAnswer.Length);
                
                SecondY = FirstY.Equalizer();        // Pe(y)
                SecondY = SecondY.mult(2);           // 2*Pe(y)
                SecondY = FirstY.Subtract(SecondY);  // 2*Pe(y) - y
                SecondY = SecondY.Selector();        // Ps(2*Pe(y) - y)
               // arrayAnswer = SecondY.returnArray();
                Ps = SecondY;
                temp = FirstY.Equalizer();           // Pe(y)
                SecondY = temp.Subtract(SecondY);    // Ps(2*Pe(y) - y) - Pe(y)
                SecondY = FirstY.Add(SecondY);       // Ps(2*Pe(y) - y) - Pe(y) + y
                step = SecondY.Comparator(Ps, temp);
                if (!step)
                {
                    diff = SecondY.Difference(SecondY, FirstY);
                    diffList.Add(diff);
                    FirstY = SecondY;
                }
                else
                {
                    diff = SecondY.Difference(SecondY, FirstY);
                    diffList.Add(diff);
                    arrayAnswer = SecondY.SudokuAnswer(temp);
                }
                loop += 1;
            }
            return step;
        }

        public int[,] SudokuAnswerForm()
        {
            return arrayAnswer;
        }
        public List<int> diffData()
        {
            return diffList;
        }
    }
}
