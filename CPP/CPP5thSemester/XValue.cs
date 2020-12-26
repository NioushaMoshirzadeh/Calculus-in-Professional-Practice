using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class XValue : AbstractClass, IFunction
    {
        public string value { get; set; }
        public XValue(string value)
        {
            this.value = value;
        }

        public override string BinaryTree()
        {
            return "\nnode" + this.Id + "[label = \"" + this.value + "\" ]\n";
        }

        public override double Evaluate(double val)
        {
            return val ;
        }

        public override string ToInfix()
        {
            return this.value;
        }

        public override string ToPrefix()
        {
            return this.value;
        }

        public override double Derivative(double val)
        {
            return 1;
        }
        public override IFunction derivative()
        {
            IFunction f;
            f = new Numbers(1);
            return f;
        }

        public override bool Simplify(IFunction derivative)
        {
            throw new NotImplementedException();
        }
    }
}
