using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Expotential:AbstractClass, IFunction
    {

        public IFunction Operand { get; set; }

        public Expotential() : base() { }
        public Expotential(IFunction operand) : base()
        {
            this.Operand = operand;
        }
        public override string ToInfix()
        {
            string toprefixvalue = "exp(" + Operand.ToInfix() + ")";
            return toprefixvalue;
        }

        public override string ToPrefix()
        {
            string toprefixvalue = "exp(" + Operand.ToPrefix() + ")";
            return toprefixvalue;
        }

        public override string BinaryTree()
        {
            String temp = "\nnode" + this.Id + " [ label = \"exp\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Operand.Id + "[style=dotted,color=purple]\n";
            temp += Operand.BinaryTree();
            return temp;
        }

        public override double Evaluate(double val)
        {
            double output = Math.Exp(Operand.Evaluate(val));
            return output;
        }

        public override double Derivative(double val)
        {
            double output = Math.Exp(Operand.Evaluate(val)) * Operand.Derivative(val);
            return output;
        }

        public override IFunction derivative() 
        {
            IFunction exp, inExp, result;
            inExp  = Operand.derivative();
            exp = new Expotential(Operand);
            result = new Multiplication(exp,inExp); 
            return result;
        }
    }
}
