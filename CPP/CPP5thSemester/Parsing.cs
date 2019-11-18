using System;
using System.Collections.Generic;
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
        public void fpa(ref string s)
        {


            switch (s[0])
            {

                case '0':
                    s = s.Remove(0, 1);
                    break; 
                case '1':
                    s = s.Remove(0, 1);
                    break;

                case '2':
                    s = s.Remove(0, 1);
                    break;
                case '3':
                    s = s.Remove(0, 1);
                    break;
                case '4':
                    s = s.Remove(0, 1);
                    break;
                case '5':
                    s = s.Remove(0, 1);
                    break;
                case '6':
                    s = s.Remove(0, 1);
                    break;
                case '7':
                    s = s.Remove(0, 1);
                    break;
                case '8':
                    s = s.Remove(0, 1);
                    break;
                case '9':
                    s = s.Remove(0, 1);
                    break;
                case 'x':
                    s = s.Remove(0, 1);
                    break;
                case '+':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case '(':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case ',':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case '-':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case '*':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case '^':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case 's':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    //fpa(ref s);
                    ////check the (,) adn eat it
                    //s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case 'c':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    //fpa(ref s);
                    ////check the (,) adn eat it
                    //s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;
                case '/':
                    s = s.Remove(0, 1);
                    //check and eat ('(')
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (,) adn eat it
                    s = s.Remove(0, 1);
                    fpa(ref s);
                    //check the (')') and eat it
                    s = s.Remove(0, 1);
                    break;

                case 'n':
                    //the split function does not work correctly 
                    s = s.Remove(0, 1);
                    string[] myNumbers = s.Split(new char[] { '(', ')' });
                    int count = myNumbers.Count();
                    RemoveWhiteSpaces(ref s);
                    MessageBox.Show(s);
                    
                    for (int i = 0; i < count; i++)
                    {

                        s = myNumbers[i];
                        MessageBox.Show(s);
                    }
                    RemoveWhiteSpaces(ref s);
                    MessageBox.Show(s);
                    fpa(ref s);
                    break;
            }


        }



    }
}
