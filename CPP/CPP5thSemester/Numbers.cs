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
        public int Value { get; set; }

        public Numbers(int var)
        {
            Value = var;
            nrOfVariables ++;
        }
        public Numbers (){}
        

       

        public override string ToInfix()
        {
            return  this.Value.ToString();
        }

        public override string ToPrefix()
        {
            return this.Value.ToString();
        }

        public override string BinaryTree()
        {
            return "\nnode" + this.Id + "[label = \"" + this.Value +"\" ]\n";
        }

        public override double Evaluate(double val)
        {
            return Convert.ToDouble(this.Value);   
        }

        public override double Derivative(double val)
        {
            return 0;
        }
    }
}
