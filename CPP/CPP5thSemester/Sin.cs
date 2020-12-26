using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Sin: AbstractClass, IFunction
    {
        public IFunction Operand { get; set; }

        public Sin() : base() { }
        public Sin(IFunction operand) : base()
        {
            this.Operand = operand;
        }
        public override string ToInfix()
        {
            string toprefixvalue = "s(" + Operand.ToInfix() + ")";
            return toprefixvalue;
        }

        public override string ToPrefix()
        {
            string toprefixvalue = "s(" + Operand.ToPrefix() + ")";
            return toprefixvalue;
        }

        public override string BinaryTree()
        {
            String temp = "\nnode" + this.Id + " [ label = \"Sin\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Operand.Id + "[style=dotted,color=purple]\n";
            temp += Operand.BinaryTree();
            return temp;
        }

        public override double Evaluate(double val)
        {
            double output = Math.Sin(Operand.Evaluate(val));
            return output; 
        }

        public override double Derivative(double val)
        {
            double output = Math.Cos(Operand.Evaluate(val));
            return output;
        }

        public override IFunction derivative() 
        {
            IFunction f;
            f = new Cos(Operand);
            Console.WriteLine(f.ToInfix());
            return f;
        }

        public override bool Simplify(IFunction derivative)
        {
            throw new NotImplementedException();
        }
    }
}
