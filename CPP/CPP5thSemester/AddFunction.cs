using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class AddFunction :AbstractClass, IFunction
    {
       // public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // public string left { get; set; }
        //public string right { get; set; }
        // public IFunction Toleft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public IFunction toRight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
         public IFunction Toleft { get; set; }
         public IFunction ToRight { get; set; }
        // public IFunction Evaluation { get; set; }
        
        public AddFunction():base() { }
        public  AddFunction(IFunction toleft, IFunction toright):base()
        {
            this.Toleft = toleft;
            this.ToRight = toright;
            

        }
        public override double Evaluate(double val)
        {
            double evaluation = Toleft.Evaluate(val) + ToRight.Evaluate(val);
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
            String temp = "\nnode" + this.Id + " [ label = \"+\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Toleft.Id + "[style=dotted,color=purple]\n";
            temp += Toleft.BinaryTree();
            temp += "node" + this.Id + " -- node" + ToRight.Id + "[shape=record,color=purple]\n";
            temp += ToRight.BinaryTree();

            return temp;
        }

        public override double Derivative(double val)
        {
            double dev = Toleft.Derivative(val) + ToRight.Derivative(val);
            return dev;
        }

        public override IFunction derivative() ///maybe will be override 
        {
            IFunction leftSide, rightSide, addDderivative;

            leftSide = Toleft.derivative();
            rightSide = ToRight.derivative();
            addDderivative = new AddFunction(leftSide, rightSide);
            return addDderivative;
        }
    }
}
