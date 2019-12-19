using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Numbers :AbstractClass, IFunction
    {
        private static int nrOfVariables = 0;
        public string Value { get; set; }

        public Numbers(string var)
        {
            Value = var;
            nrOfVariables ++;
        }
        public Numbers (){}
        

       

        public override string ToInfix()
        {
            return this.Value;
        }

        public override string ToPrefix()
        {
            return this.Value;
        }

        public override string BinaryTree()
        {
            return "\nnode" + this.Id + "[label = \"" + this.Value +"\" ]\n";
        }

        public override double Evaluate(double val)
        {
            //int validateValue = 0;
            return Convert.ToDouble(this.Value); 
            
           
        }

     
    }
}
