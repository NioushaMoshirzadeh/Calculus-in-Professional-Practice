using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Expotential:AbstractClass, IFunction
    {
        double eValue = 2.718281828;
        public IFunction Operand { get; set;}
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
            
            if (Operand == null)
            {
                return eValue;
            }
            double output = Math.Exp(Operand.Evaluate(val));
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
        public override IFunction Simplify()
        {
            if (this.Operand.GetType() == typeof(Numbers))
            {
                if (Operand.ToInfix() == "0")
                {
                    return new Numbers(1);
                }
            }
            return new Expotential(this.Operand);
        }
    }
}
