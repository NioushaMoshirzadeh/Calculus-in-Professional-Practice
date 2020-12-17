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
       
        private string RemoveWhiteSpaces(ref string s)
        {
            s = s.Replace(" ", String.Empty);
            return s;
        }
        //parse the proposition 
        public IFunction fpa(ref string s)
        {
            IFunction f;
            
            while (s != null)
            {
                
                switch (s[0])
                {
                    
                    case '0':
                        s = s.Remove(0, 1);
                        f = new Numbers(0);
                        return f;

                    case '1':
                        s = s.Remove(0, 1);
                        f = new Numbers(1);
                        return f;

                    case '2':
                        s = s.Remove(0, 1);
                        f = new Numbers(2);
                        return f;
                    case '3':
                        s = s.Remove(0, 1);
                        f = new Numbers(3);
                        return f;
                    case '4':
                        s = s.Remove(0, 1);
                        f = new Numbers(4);
                        return f;
                    case '5':
                        s = s.Remove(0, 1);
                        f = new Numbers(5);
                        return f;
                    case '6':
                       s = s.Remove(0, 1);
                        f = new Numbers(6);
                        return f;
                    case '7':
                        s = s.Remove(0, 1);
                        f = new Numbers(7);
                        return f;
                    case '8':
                        s = s.Remove(0, 1);
                        f = new Numbers(8);
                        return f;
                    case '9':
                        s = s.Remove(0, 1);
                        f = new Numbers(9);
                        return f;
                    case 'x':
                        s = s.Remove(0, 1);
                        f = new XValue("x");
                        return f;
                    case 'p':
                        s = s.Remove(0, 1);
                        f = new PValue("p");
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
                        return f;
                    case 'l':
                        s = s.Remove(0, 1);
                        string[] Number = s.Split(new char[] { '(', ')', ',' });
                        int number;
                        int counted = Number.Count();
                        RemoveWhiteSpaces(ref s);
                        RemoveWhiteSpaces(ref s);
                        //if (Number[1] == "x")
                        //{
                        //    s = s.Remove(0, 1);
                        //    IFunction xVal = fpa(ref s);
                        //    f = new Ln(xVal);
                        //    s = s.Remove(0, 1);

                        //}
                       // else
                        //{
                            number = Convert.ToInt32(Number[1]);
                            s = s.Remove(0, 1);                         //remove (
                            foreach (char var in Number[1])
                            {
                                s = s.Remove(0, 1);                     //remove int number
                            }
                            s = s.Remove(0, 1);                        //remove )
                            f = new Ln(number);
                       // }
                        return f;

                    case '+':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction left = fpa(ref s);
                        s = s.Remove(0, 1);
                        IFunction right = fpa(ref s);
                        s = s.Remove(0, 1);
                        f = new AddFunction(left, right);
                       AddFunction a = new AddFunction(left, right);
                        return f;

                    case '-':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction leftMinus = fpa(ref s);
                        s = s.Remove(0, 1);
                        IFunction rightMinus = fpa(ref s);
                        s = s.Remove(0, 1);
                        f = new MinusFunction(leftMinus, rightMinus);
                        return f;

                    case 's':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction inputForSinValue = fpa(ref s);
                        f = new Sin(inputForSinValue);
                        s = s.Remove(0, 1);
                        return f;

                    case '^':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction left1 = fpa(ref s);
                        s = s.Remove(0, 1);
                        IFunction right2 = fpa(ref s);
                        s = s.Remove(0, 1);
                        f = new Power(left1,right2);
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
                        return f;

                    case '*':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction leftMuiltiplication = fpa(ref s);
                        s = s.Remove(0, 1);
                        IFunction rightMuiltiplication = fpa(ref s);
                        s = s.Remove(0, 1);
                        f = new Multiplication(leftMuiltiplication, rightMuiltiplication);
                        return f;

                    case '/':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction leftDevision = fpa(ref s);
                        s = s.Remove(0, 1);
                        IFunction rightDevision = fpa(ref s);
                        s = s.Remove(0, 1);
                        f = new DevisionFunction(leftDevision, rightDevision);
                        return f;

                    case 'c':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);
                        IFunction inputForCosValue = fpa(ref s);
                        f = new Cos(inputForCosValue);
                        s = s.Remove(0, 1);
                        return f;

                    case 'e':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);                       
                        IFunction innerEqExp = fpa(ref s);
                        f = new Expotential(innerEqExp);
                        s = s.Remove(0, 1);
                        return f;
                }

            }
            return null;
        }



    }
}
