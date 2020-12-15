using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Ln:AbstractClass,IFunction
    {
        private static int nrOfVariables = 0;
        public IFunction Operand { get; set; }
        public double Value { get; set; }

        public Ln(int var)
        {
            Value = Math.Log(var);
            nrOfVariables++;
        }
        //public Ln(IFunction operand) : base()
        //{
        //    this.Operand = operand;
        //}
        public Ln() { }

        //public override string ToInfix()
        //{
        //    string toprefixvalue = "l(" + Operand.ToInfix() + ")";
        //    return toprefixvalue;
        //}

        //public override string ToPrefix()
        //{
        //    string toprefixvalue = "l(" + Operand.ToPrefix() + ")";
        //    return toprefixvalue;
        //}


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

        public override double Derivative(double val)
        {
            return 0;
        }

        public override IFunction derivative()
        {
            IFunction f = new Numbers(0);
            return f;
        }
    }
}
