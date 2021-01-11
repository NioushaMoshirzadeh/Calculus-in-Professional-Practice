using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBrain
{
    class CubeCell
    {
        public double confidence { get; set; } 
        public bool isClue { get; set; } 
        public CubeCell()
        {
            this.confidence = 1;
            this.isClue = false;
        }
    }
}
