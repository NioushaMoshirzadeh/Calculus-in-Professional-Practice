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
    public partial class Form1 : Form
    {
        // private object parsing;
           Parsing parsing;
        private IFunction root; 
        public Form1()
        {
            InitializeComponent();
            root = null;
        }

        private void DrawBinaryTree()
        {
            
               
                    GraphVize.SaveDotFile(root, "abcd");
                    Process dot = new Process();
                    dot.StartInfo.FileName = "dot.exe";
                    dot.StartInfo.Arguments = "-T png -o abc.png abcd.dot";
                    dot.Start();
                    dot.WaitForExit();
            //Image image = Image.FromFile("C:/Users/nisha/Documents/my-git-project/CPP/CPP5thSemester/bin/Debug/abc.png");
            //picBox_tree.Image = image;
            //picBox_tree.Height = image.Height;
            //picBox_tree.Width = image.Width;
            //@"C: \Users\nisha\Downloads\graphviz\cppGraphViz\release\bin\dot.exe", @"-Tpng D:\tmp.dot -o D:\tmp.png"
            picBox_tree.ImageLocation = "abc.png";
                

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPars_Click(object sender, EventArgs e)
        {
            tbResult.Text = "";
            string s = tbParse.Text;
            parsing = new Parsing();
            root = parsing.fpa(ref s);
            tbResult.Text = root.ToInfix();
            DrawBinaryTree();
            tbParse.Text = s;
            
          

        }




    }
}
