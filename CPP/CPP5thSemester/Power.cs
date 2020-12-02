using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    public class Power: AbstractClass, IFunction
    {
        public IFunction Operandleft { get; set; }
        public IFunction Operandright { get; set; }

        public Power() : base() { }
        public Power(IFunction operandleft, IFunction operandright) : base()
        {
            this.Operandleft = operandleft;
            this.Operandright = operandright;

        }
        public override string ToInfix()
        {
            string toprefixvalue = Operandleft.ToInfix()  + Operandright.ToInfix();
            return toprefixvalue;
        }

        public override string ToPrefix()
        {
            string toprefixvalue = Operandleft.ToPrefix() + Operandright.ToPrefix();
            return toprefixvalue;
        }

        public override string BinaryTree()
        {
            String temp = "\nnode" + this.Id + " [ label = \"^\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Operandleft.Id + "[style=dotted,color=purple]\n";
            temp += Operandleft.BinaryTree();
            temp += "node" + this.Id + " -- node" + Operandright.Id + "[shape=record,color=purple]\n";
            temp += Operandright.BinaryTree();
            return temp;
        }

        public override double Evaluate(double val)
        {
            double output =Math.Pow(Operandleft.Evaluate(val), Operandright.Evaluate(val));
            return output;
        }

        public override double Derivative(double val)
        {
            double output = Operandright.Evaluate(val) * Math.Pow( Operandleft.Evaluate(val), (Operandright.Evaluate(val) - 1));
            return output;
        }

        public override IFunction derivative()
        {
            IFunction leftSide, rightSide, powerDderivative, newDefinedPower;
            int rightValue = Convert.ToInt32(Operandright.ToInfix());
            leftSide = new Numbers(rightValue);
            newDefinedPower = new Numbers(rightValue - 1);
            if (Operandleft.ToInfix() == "x")
                rightSide = new XValue("x");
            else rightSide = new Numbers(Convert.ToInt32(Operandleft.ToInfix()));
            powerDderivative = new Multiplication(leftSide,new Power(rightSide, newDefinedPower));
            return powerDderivative;
        }
    }
}
