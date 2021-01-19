using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CPP5thSemester
{
    public class Parsing
    {
        string function = "";
        private string RemoveWhiteSpaces(ref string s)
        {
            s = s.Replace(" ", String.Empty);
            return s;
        }
        public IFunction fpa(ref string s)  //parse the proposition 
        {
            IFunction f;
            while (s != null)
            {
                
                switch (s[0])
                {
                    case '0':
                        s = s.Remove(0, 1);
                        f = new Numbers(0);
                        function += "0";
                        return f;

                    case '1':
                        s = s.Remove(0, 1);
                        f = new Numbers(1);
                        function += "1";
                        return f;

                    case '2':
                        s = s.Remove(0, 1);
                        f = new Numbers(2);
                        function += "2";
                        return f;
                    case '3':
                        s = s.Remove(0, 1);
                        f = new Numbers(3);
                        function += "3";
                        return f;
                    case '4':
                        s = s.Remove(0, 1);
                        f = new Numbers(4);
                        function += "4";
                        return f;
                    case '5':
                        s = s.Remove(0, 1);
                        f = new Numbers(5);
                        function += "5";
                        return f;
                    case '6':
                       s = s.Remove(0, 1);
                        f = new Numbers(6);
                        function += "6";
                        return f;
                    case '7':
                        s = s.Remove(0, 1);
                        f = new Numbers(7);
                        function += "7";
                        return f;
                    case '8':
                        s = s.Remove(0, 1);
                        f = new Numbers(8);
                        function += "8";
                        return f;
                    case '9':
                        s = s.Remove(0, 1);
                        f = new Numbers(9);
                        function += "9";
                        return f;
                    case 'x':
                        s = s.Remove(0, 1);
                        f = new XValue("x");
                        function += "x";
                        return f;
                    case 'p':
                        s = s.Remove(0, 1);
                        f = new PValue("p");
                        function += "Pi";
                        return f;

                    case '!':
                        s = s.Remove(0, 1);
                        string[] myNumber = s.Split(new char[] { '(', ')', ',' });
                        int cnt = myNumber.Count();
                        RemoveWhiteSpaces(ref s);
                        RemoveWhiteSpaces(ref s);
                        int number1 = Convert.ToInt32(myNumber[1]);
                        s = s.Remove(0, 1);                         //remove (
                        foreach (char var in myNumber[1])
                        {
                            s = s.Remove(0, 1);                     //remove int number
                        }
                        s = s.Remove(0, 1);                        //remove )
                        f = new Factorial(number1);
                        function += number1.ToString();
                        function += "!";
                        Console.WriteLine(function);
                        return f;

                    case 'l':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "ln(";
                        IFunction val = fpa(ref s);
                        function += ")";
                        s = s.Remove(0, 1);
                        f = new Ln(val);
                        //f = f.Simplify();
                        return f;

                    case '+':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "(";
                        IFunction left = fpa(ref s);
                        function += "+";
                        s = s.Remove(0, 1);
                        IFunction right = fpa(ref s);
                        function += ")";
                        s = s.Remove(0, 1);
                        f = new AddFunction(left, right);
                       // f = f.Simplify();
                        return f;

                    case '-':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "(";
                        IFunction leftMinus = fpa(ref s);
                        function += "-";
                        s = s.Remove(0, 1);
                        IFunction rightMinus = fpa(ref s);
                        function += ")";
                        s = s.Remove(0, 1);
                        f = new MinusFunction(leftMinus, rightMinus);
                        //f = f.Simplify();
                        return f;

                    case 's':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "s(";
                        IFunction inputForSinValue = fpa(ref s);
                        f = new Sin(inputForSinValue);
                        function += ")";
                        s = s.Remove(0, 1);
                        return f;

                    case '^':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "(";
                        IFunction left1 = fpa(ref s);
                        function += "^";
                        s = s.Remove(0, 1);
                        IFunction right2 = fpa(ref s);
                        function += ")";
                        s = s.Remove(0, 1);
                        f = new Power(left1,right2);
                        //f = f.Simplify();
                        return f;

                    case 'n':
                        s = s.Remove(0, 1);
                        string[] myNumbers = s.Split(new char[] { '(', ')', ',' });
                        int count = myNumbers.Count();
                        RemoveWhiteSpaces(ref s);
                        RemoveWhiteSpaces(ref s);
                        int num = Convert.ToInt32( myNumbers[1]);                        
                        s = s.Remove(0, 1);                         //remove (
                        foreach (char var in myNumbers[1])
                        {
                            s = s.Remove(0, 1);                     //remove int number
                        }
                        s = s.Remove(0, 1);                        //remove )
                        f = new Numbers(num);
                        function += "n(" + num.ToString() + ")"; 
                        return f;

                    case 'r':
                        s = s.Remove(0, 1);
                        string[] myRealNumbers = s.Split(new char[] { '(', ')', ',' });
                        int countRealNr = myRealNumbers.Count();
                        RemoveWhiteSpaces(ref s);
                        RemoveWhiteSpaces(ref s);
                        decimal realNumber = Convert.ToDecimal(myRealNumbers[1]);
                        s = s.Remove(0, 1);                         //remove (
                        foreach (char var in myRealNumbers[1])
                        {
                            s = s.Remove(0, 1);                     //remove int number
                        }
                        s = s.Remove(0, 1);                        //remove )
                        f = new RealNumber(realNumber);
                        function += "r(" + realNumber.ToString() + ")";
                        return f;

                    case '*':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "(";
                        IFunction leftMuiltiplication = fpa(ref s);
                        function += "*";
                        s = s.Remove(0, 1);
                        IFunction rightMuiltiplication = fpa(ref s);
                        s = s.Remove(0, 1);
                        function += ")";
                        f = new Multiplication(leftMuiltiplication, rightMuiltiplication);
                        //f = f.Simplify();
                        return f;

                    case '/':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "(";
                        IFunction leftDevision = fpa(ref s);
                        function += "/";
                        s = s.Remove(0, 1);
                        IFunction rightDevision = fpa(ref s);
                        function += ")";
                        s = s.Remove(0, 1);
                        f = new DevisionFunction(leftDevision, rightDevision);
                       // f = f.Simplify();
                        return f;

                    case 'c':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        function += "cos(";
                        IFunction inputForCosValue = fpa(ref s);
                        f = new Cos(inputForCosValue);
                        function += ")";
                        s = s.Remove(0, 1);
                        return f;

                    case 'e':
                        s = s.Remove(0, 1);
                        function += "exp(";
                        string[] myExponential = s.Split(new char[] { '(', ')', ',' });
                        if (myExponential[1] == "") // l(e)
                        {
                            f = new RealNumber((decimal)2.718281);
                            function += ")";
                        }
                        else
                        {
                            s = s.Remove(0, 1);
                            IFunction innerEqExp = fpa(ref s);
                            function += ")";
                            f = new Expotential(innerEqExp);
                           // f = f.Simplify();
                            s = s.Remove(0, 1);
                        }
                        return f;
                    default:
                        MessageBox.Show("unhandled value for the input textbox: " + s[0]);
                        throw new ArgumentOutOfRangeException("unknown value");
                }
            }
            return null;
        }
        public string EquationHumanReadablitly()
        {
            return function;
        }
    }
}
