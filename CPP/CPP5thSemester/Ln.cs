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
            double output = Math.Log(Operand.Evaluate(val));
            return output;
        }

        public override double Derivative(double val)
        {
            double output = Math.Log(Operand.Evaluate(val));
            return output;
        }

        public override IFunction derivative()
        {
            IFunction numerator, lnDerivative;
            numerator = Operand.derivative();
            lnDerivative = new DevisionFunction(numerator, Operand);
            return lnDerivative;
        }
        public override bool Simplify(IFunction derivative)
        {
            throw new NotImplementedException();
        }
    }
}
