using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    public abstract class AbstractClass : IFunction
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public abstract string ToInfix();
        public abstract string ToPrefix();

    }
}
