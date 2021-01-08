using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Factorial:AbstractClass,IFunction
    {
        private static int nrOfVariables = 0;
        public int Value { get; set;}
        int fact;
        public Factorial(int var)
        {
            for (int i = 1; i <= var; i++)
            {
                fact = var * i; 
            }
            Value = fact;
            nrOfVariables++;
        }
        public Factorial() { }
        public override string ToInfix()
        {
            return this.Value.ToString();
        }

        public override string ToPrefix()
        {
            return this.Value.ToString();
        }

        public override string BinaryTree()
        {
            return "\nnode" + this.Id + "[label = \"" + this.Value + "\" ]\n";
        }

        public override double Evaluate(double val)
        {
            return Convert.ToDouble(this.Value);
        }

        public override IFunction derivative()
        {
            IFunction f = new Numbers(0);
            return f;
        }
        public override IFunction Simplify()
        {
            throw new NotImplementedException();
        }

    }
}
