using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    public abstract class AbstractClass : IFunction
    {
        private int id;
        private static int count = 0;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public AbstractClass()
        {
            count++;
            id = count;
        }
        public abstract string ToInfix();
        public abstract string ToPrefix();
        public abstract string BinaryTree();
        public abstract double Evaluate(double val);
        public abstract double Derivative(double val);

        
    }
}
