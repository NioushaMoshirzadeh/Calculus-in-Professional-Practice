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
    }
}
