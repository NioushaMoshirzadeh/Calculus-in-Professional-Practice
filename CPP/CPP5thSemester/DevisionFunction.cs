using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPP5thSemester
{
    class DevisionFunction:AbstractClass, IFunction
    {
        public IFunction Toleft { get; set; }
        public IFunction ToRight { get; set; }
        public DevisionFunction() : base() { }
        public DevisionFunction(IFunction toleft, IFunction toright) : base()
        {
            this.Toleft = toleft;
            this.ToRight = toright;
        }
        public override double Evaluate(double val)
        {
            if (ToRight.Evaluate(val) == 0)
            {
                throw new Exception("you can not devide by zero!");
            }
            double evaluation = Toleft.Evaluate(val) / ToRight.Evaluate(val);
            return evaluation;
        }
        public override string ToInfix()
        {
            string toprefixvalue = Toleft.ToInfix() + ToRight.ToInfix();
            return toprefixvalue;
        }

        public override string ToPrefix()
        {
            string toprefixvalue = Toleft.ToPrefix() + ToRight.ToPrefix();
            return toprefixvalue;
        }
        public override string BinaryTree()
        {
            String temp = "\nnode" + this.Id + " [ label = \"/\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Toleft.Id + "[style=dotted,color=purple]\n";
            temp += Toleft.BinaryTree();
            temp += "node" + this.Id + " -- node" + ToRight.Id + "[shape=record,color=purple]\n";
            temp += ToRight.BinaryTree();
            return temp;
        }
        public override IFunction derivative()
        {
            IFunction  devisionDderivative, leftabove,rightabove, minusAboveDevision, powerDown;
            leftabove = new Multiplication(Toleft.derivative(), ToRight);
            rightabove = new Multiplication(Toleft, ToRight.derivative());
            minusAboveDevision= new MinusFunction(leftabove,rightabove);
            powerDown = new Power(Toleft, new Numbers(2));
            devisionDderivative = new DevisionFunction(minusAboveDevision, powerDown);
            return devisionDderivative;
        }
        public override IFunction Simplify()
        {
            if (ToRight.GetType() == typeof(Numbers))
            {
                if (ToRight.ToInfix() == "0")
                {
                    throw new Exception("Can not divide by zero!");
                }
            }
            if (Toleft.GetType() == typeof(Numbers))
            {
                if (Toleft.ToInfix() == "0")
                {
                    return new Numbers(0);
                }
            }
            return new DevisionFunction(Toleft, ToRight);
        }

    }
}
