using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class RealNumber:AbstractClass,IFunction
    {

        private static int nrOfVariables = 0;
        public decimal Value { get; set; }

        public RealNumber(decimal var)
        {
            Value = var;
            nrOfVariables++;
        }
        public RealNumber() { }

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
        public override IFunction McLaurin(IFunction derivative)
        {
            throw new NotImplementedException();
        }
    }
}
