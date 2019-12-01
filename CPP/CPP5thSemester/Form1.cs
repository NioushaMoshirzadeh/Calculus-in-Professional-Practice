using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPP5thSemester
{
    public partial class Form1 : Form
    {
        // private object parsing;
           Parsing parsing;

        public Form1()
        {
            InitializeComponent();
          
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPars_Click(object sender, EventArgs e)
        {
            string s = tbParse.Text;
            parsing = new Parsing();
            
            _ = parsing.fpa(ref s);
            tbParse.Text = s;
           // AddFunction a = new AddFunction();
            //double result = a.add();
            //string result2 = result.ToString();
            //tbResult.Text = result2.ToString();
            //fpa(ref s);

            //create a binary tree 

        }




    }
}
