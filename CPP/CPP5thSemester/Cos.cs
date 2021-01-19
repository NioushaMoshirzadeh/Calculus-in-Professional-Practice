using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Cos: AbstractClass, IFunction
    {
        public IFunction Operand { get; set; }
        public Cos() : base() { }
        public Cos(IFunction operand) : base()
        {
            this.Operand = operand;
        }
        public override string ToInfix()
        {
            string toprefixvalue = "c(" + Operand.ToInfix() + ")";
            return toprefixvalue;
        }
        public override string ToPrefix()
        {
            string toprefixvalue = "c(" + Operand.ToPrefix() + ")";
            return toprefixvalue;
        }
        public override string BinaryTree()
        {
            String temp = "\nnode" + this.Id + " [ label = \"Cos\" ][shape=polygon,sides=6,peripheries=3,color=lightpink,style=filled]\n";
            temp += "node" + this.Id + " -- node" + Operand.Id + "[style=dotted,color=purple]\n";
            temp += Operand.BinaryTree();
            return temp;
        }
        public override double Evaluate(double val)
        {
            double output;
            if (Operand.GetType() == typeof(PValue))
            {
                output = Math.Cos(Operand.Evaluate(val));
            }
            else
            {
                double radian = Math.PI * ((Operand.Evaluate(val) * 55) / 180.0); //55 is the most precise number for adjusting 
                                                                                  //the Sin and Cos values on the Canvas steps
                output = Math.Cos(radian);
            }
            return output;
        }
        public override IFunction derivative() 
        {
            return new Multiplication(Operand.derivative(), new Multiplication(new Numbers(-1), new Sin(Operand)));
        }
        public override IFunction Simplify()
        {
            throw new NotImplementedException();
        }
    }
}
