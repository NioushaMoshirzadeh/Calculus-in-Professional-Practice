using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Multiplication: AbstractClass, IFunction
    {
        public IFunction Toleft { get; set; }
        public IFunction ToRight { get; set; }
        public Multiplication() : base() { }
        public Multiplication(IFunction toleft, IFunction toright) : base()
        {
            this.Toleft = toleft;
            this.ToRight = toright;


        }
        public override double Evaluate(double val)
        {
            double evaluation = Toleft.Evaluate(val) * ToRight.Evaluate(val);
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
            String temp = "\nnode" + this.Id + " [ label = \"*\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Toleft.Id + "[style=dotted,color=purple]\n";
            temp += Toleft.BinaryTree();
            temp += "node" + this.Id + " -- node" + ToRight.Id + "[shape=record,color=purple]\n";
            temp += ToRight.BinaryTree();

            return temp;
        }

        public override double Derivative(double val)
        {
            double dev = (Toleft.Derivative(val) * ToRight.Evaluate(val)) + (ToRight.Derivative(val) * Toleft.Evaluate(val));
            return dev;
        }

        public override IFunction derivative() 
        {
            IFunction leftSide,rightSide, multipleDderivative ;
            if (Toleft.ToInfix().StartsWith("e"))
            {

                leftSide = new Multiplication(new Numbers(0), ToRight);
            }
            else
            {
                leftSide = new Multiplication(Toleft.derivative(), ToRight);
            }    
            rightSide = new Multiplication(Toleft, ToRight.derivative());
            multipleDderivative = new AddFunction(leftSide, rightSide);
            return multipleDderivative;
        }

        public override IFunction McLaurin(IFunction derivative)
        {
            throw new NotImplementedException();
        }
    }
}
