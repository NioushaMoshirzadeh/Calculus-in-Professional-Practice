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
        //method to draw the binary tree on form
       


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
                        f = new Numbers("0");
                        return f;

                    case '1':
                        s = s.Remove(0, 1);
                        f = new Numbers("1");
                        return f;

                    case '2':
                        s = s.Remove(0, 1);
                        f = new Numbers("2");
                        return f;
                    case '3':
                        s = s.Remove(0, 1);
                        f = new Numbers("3");
                        return f;
                    case '4':
                        s = s.Remove(0, 1);
                        f = new Numbers("4");
                        return f;
                    case '5':
                        s = s.Remove(0, 1);
                        f = new Numbers("5");
                        return f;
                    case '6':
                        s = s.Remove(0, 1);
                        f = new Numbers("6");
                        return f;
                    case '7':
                        s = s.Remove(0, 1);
                        f = new Numbers("7");
                        return f;
                    case '8':
                        s = s.Remove(0, 1);
                        f = new Numbers("8");
                        return f;
                    case '9':
                        s = s.Remove(0, 1);
                        f = new Numbers("9");
                        return f;
                    case 'x':
                        s = s.Remove(0, 1);
                        f = new Numbers("x");
                        return f;

                    case '+':
                        s = s.Remove(0, 1);
                        s = s.Remove(0, 1);

                        IFunction left = fpa(ref s);
                        s = s.Remove(0, 1);
                        IFunction right = fpa(ref s);
                        s = s.Remove(0, 1);
                        //  return firstCloud + secondCloud;
                        // break;
                        f = new AddFunction(left, right);
                        AddFunction a = new AddFunction(left, right);
                        double addResult = a.add();

                        return f;

                        //case '-':
                        //    s = s.Remove(0, 1);
                        //    //check and eat ('(')
                        //    s = s.Remove(0, 1);
                        //    //MakeTree.Add('-');
                        //    firstCloud = fpa(ref s);
                        //    //check the (,) adn eat it
                        //    s = s.Remove(0, 1);
                        //    secondCloud = fpa(ref s);
                        //    //check the (')') and eat it
                        //    s = s.Remove(0, 1);
                        //    return firstCloud - secondCloud;
                        //   // break;

                        //case '*':
                        //    s = s.Remove(0, 1);
                        //    //check and eat ('(')
                        //    s = s.Remove(0, 1);
                        //  //  MakeTree.Add('*');

                        //    firstCloud = fpa(ref s);
                        //    firstOperand.Add("*");
                        //    firstOperand.Add(firstCloud.ToString());
                        //    realFirsrt = firstCloud;
                        //    //first.Add(firstCloud);
                        //    //check the (,) adn eat it
                        //    s = s.Remove(0, 1);
                        //    secondCloud = fpa(ref s);
                        //    secondOperand.Add(secondCloud.ToString());
                        //   // second.Add(secondCloud);
                        //    //check the (')') and eat it
                        //    s = s.Remove(0, 1);
                        //    //return first[0] * second.Last();
                        //    //break;
                        //    return realFirsrt * secondCloud;

                        //case '^':
                        //    s = s.Remove(0, 1);
                        //    //check and eat ('(')
                        //    s = s.Remove(0, 1);
                        //   // MakeTree.Add('^');
                        //    fpa(ref s);
                        //    //check the (,) adn eat it
                        //    s = s.Remove(0, 1);
                        //    fpa(ref s);
                        //    //check the (')') and eat it
                        //    s = s.Remove(0, 1);
                        //    break;

                        //case 's':
                        //    s = s.Remove(0, 1);
                        //    //check and eat ('(')
                        //    s = s.Remove(0, 1);
                        //   // MakeTree.Add('s');
                        //    //fpa(ref s);
                        //    ////check the (,) adn eat it
                        //    //s = s.Remove(0, 1);
                        //    fpa(ref s);
                        //    //check the (')') and eat it
                        //    s = s.Remove(0, 1);
                        //    break;

                        //case 'c':
                        //    s = s.Remove(0, 1);
                        //    //check and eat ('(')
                        //    s = s.Remove(0, 1);
                        //   // MakeTree.Add('c');
                        //    //fpa(ref s);
                        //    ////check the (,) adn eat it
                        //    //s = s.Remove(0, 1);
                        //    fpa(ref s);
                        //    //check the (')') and eat it
                        //    s = s.Remove(0, 1);
                        //    break;

                        //case '/':
                        //    s = s.Remove(0, 1);
                        //    //check and eat ('(')
                        //    s = s.Remove(0, 1);
                        //    //MakeTree.Add('/');
                        //    firstCloud = fpa(ref s);
                        //    //check the (,) adn eat it
                        //    s = s.Remove(0, 1);
                        //    secondCloud = fpa(ref s);
                        //    //check the (')') and eat it
                        //    s = s.Remove(0, 1);
                        //    return firstCloud / secondCloud;
                        //   // break;

                        //case 'n':
                        //    //the split function does not work correctly 
                        //    s = s.Remove(0, 1);
                        //   // MakeTree.Add('n');
                        //    string[] myNumbers = s.Split(new char[] { '(', ')' });
                        //    int count = myNumbers.Count();
                        //    //return myNumbers[1];
                        //    RemoveWhiteSpaces(ref s);
                        //    RemoveWhiteSpaces(ref s);
                        //    fpa(ref s);
                        //    break;
                }

            }
            return null;
        }



    }
}
