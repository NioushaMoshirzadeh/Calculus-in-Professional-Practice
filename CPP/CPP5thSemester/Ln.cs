using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPP5thSemester
{
    class Ln:AbstractClass,IFunction
    {
        public IFunction Operand { get; set; }
        public Ln() : base() { }
        public Ln(IFunction operand) : base()
        {
            this.Operand = operand;
        }
        public override string ToInfix()
        {
            string toprefixvalue = "ln(" + Operand.ToInfix() + ")";
            return toprefixvalue;
        }
        public override string ToPrefix()
        {
            string toprefixvalue = "ln(" + Operand.ToPrefix() + ")";
            return toprefixvalue;
        }
        public override string BinaryTree()
        {
            String temp = "\nnode" + this.Id + " [ label = \"Ln\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Operand.Id + "[style=dotted,color=purple]\n";
            temp += Operand.BinaryTree();
            return temp;
        }
        public override double Evaluate(double val)
        {
            if (Operand.Evaluate(val) == 0)
            {
                throw new Exception("ln(0) is undefined, therefore Ln doesn't have the MClaurin series!");
            }
            double output = Math.Log(Operand.Evaluate(val)); //calculate log on base e
            return output;
        }

        public override IFunction derivative()
        {
            IFunction numerator, lnDerivative;
            numerator = Operand.derivative();
            lnDerivative = new DevisionFunction(numerator, Operand);
            return lnDerivative;
        }
        public override IFunction Simplify()
        {
            
            if (Operand.GetType() == typeof(Numbers))
            {
                if (Operand.ToInfix() == "1")
                {
                    return new Numbers(0);
                }
            }
            if (Operand.GetType() == typeof(RealNumber))
            {
                if (Operand.ToInfix() == "2.718281")
                {
                    return new Numbers(1);
                }
            }
           return new Ln(this.Operand);
        }
    }
}
