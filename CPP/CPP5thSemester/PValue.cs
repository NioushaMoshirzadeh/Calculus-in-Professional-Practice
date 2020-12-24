using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class PValue: AbstractClass,IFunction
    {

        public double value { get; set; }
        public PValue(string value)
        {
            this.value = Math.PI;
        }

        public override string BinaryTree()
        {
            return "\nnode" + this.Id + "[label = \"" + this.value + "\" ]\n";
        }

        public override double Evaluate(double val)
        {
            return val;
        }

        public override string ToInfix()
        {
            return this.value.ToString();
        }

        public override string ToPrefix()
        {
            return this.value.ToString();
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
