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

        public override double Derivative(double val)
        {
            double dev = ((Toleft.Derivative(val) * ToRight.Evaluate(val)) - (ToRight.Derivative(val) * Toleft.Evaluate(val))) / Math.Pow(ToRight.Evaluate(val),2);
            return dev;
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

        public override bool Simplify(IFunction derivative)
        {
            throw new NotImplementedException();
        }

    }
}
