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
        //public double addOperator(CubeCell b)
        //{
        //    this.confidence = this.confidence + b.confidence;
        //    this.isClue = false;
        //    return this.confidence;
        //}

        //public double minusOperator(CubeCell b)
        //{
        //    this.confidence = this.confidence - b.confidence;
        //    this.isClue = false;
        //    return this.confidence;
        //}

        //public double MultipicationOperator(double v)
        //{
        //    this.confidence = this.confidence + v;
        //    this.isClue = false;
        //    return this.confidence;
        //}


    }
}
