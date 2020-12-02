using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    public interface IFunction
    {
        int Id { get; set; }
        string ToInfix();
        string ToPrefix();
        string BinaryTree();

        double Evaluate(double val);
        double Derivative(double val);
        IFunction derivative();


    }
}
