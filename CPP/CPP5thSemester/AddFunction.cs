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
        
        public AddFunction():base() { }
        public  AddFunction(IFunction toleft, IFunction toright):base()
        {
            this.Toleft = toleft;
            this.ToRight = toright;
            

        }
        

        public double add()
        {
            string left =Toleft.ToInfix();
            string right = ToRight.ToPrefix();
            double value1 = Convert.ToDouble(left);
            double value2 = Convert.ToDouble(right);
            double result = value1 + value2;
            return result;
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
    }
}
