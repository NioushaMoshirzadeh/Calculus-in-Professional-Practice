using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Numbers :AbstractClass, IFunction
    {
        private static int nrOfVariables = 0;
        public string Value { get; set; }

        public Numbers(string var)
        {
            Value = var;
            nrOfVariables ++;
        }
        public Numbers (){}
        

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ToInfix()
        {
            return this.Value;
        }

        public override string ToPrefix()
        {
            return this.Value;
        }
    }
}
