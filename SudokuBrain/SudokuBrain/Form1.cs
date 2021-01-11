using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuBrain
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            tb12.TextAlign = HorizontalAlignment.Center;
            tb21.TextAlign = HorizontalAlignment.Center;
            tb22.TextAlign = HorizontalAlignment.Center;
            tb32.TextAlign = HorizontalAlignment.Center;
            tb33.TextAlign = HorizontalAlignment.Center;
            tb34.TextAlign = HorizontalAlignment.Center;
            tb25.TextAlign = HorizontalAlignment.Center;
            tb16.TextAlign = HorizontalAlignment.Center;
            tb37.TextAlign = HorizontalAlignment.Center;
            tb28.TextAlign = HorizontalAlignment.Center;
            tb18.TextAlign = HorizontalAlignment.Center;
            tb19.TextAlign = HorizontalAlignment.Center;
            tb29.TextAlign = HorizontalAlignment.Center;
            tb41.TextAlign = HorizontalAlignment.Center;
            tb52.TextAlign = HorizontalAlignment.Center;
            tb62.TextAlign = HorizontalAlignment.Center;
            tb53.TextAlign = HorizontalAlignment.Center;
            tb55.TextAlign = HorizontalAlignment.Center;
            tb57.TextAlign = HorizontalAlignment.Center;
            tb48.TextAlign = HorizontalAlignment.Center;
            tb59.TextAlign = HorizontalAlignment.Center;
            tb69.TextAlign = HorizontalAlignment.Center;
            tb81.TextAlign = HorizontalAlignment.Center;
            tb91.TextAlign = HorizontalAlignment.Center;
            tb82.TextAlign = HorizontalAlignment.Center;
            tb92.TextAlign = HorizontalAlignment.Center;
            tb73.TextAlign = HorizontalAlignment.Center;
            tb94.TextAlign = HorizontalAlignment.Center;
            tb86.TextAlign = HorizontalAlignment.Center;
            tb76.TextAlign = HorizontalAlignment.Center;
            tb77.TextAlign = HorizontalAlignment.Center;
            tb78.TextAlign = HorizontalAlignment.Center;
            tb88.TextAlign = HorizontalAlignment.Center;
            tb89.TextAlign = HorizontalAlignment.Center;
            tb89.TextAlign = HorizontalAlignment.Center;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox70_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb31_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb33_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb41_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb54_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSample1_Click(object sender, EventArgs e)
        {
            tb12.Text = "8";
            tb21.Text = "3";
            tb22.Text = "5";
            tb32.Text = "4";
            tb33.Text = "1";
            tb34.Text = "7";
            tb25.Text = "8";
            tb16.Text = "2";
            tb37.Text = "9";
            tb28.Text = "4";
            tb18.Text = "5";
            tb19.Text = "3";
            tb29.Text = "1";
            tb41.Text = "5";
            tb52.Text = "1";
            tb62.Text = "6";
            tb53.Text = "3";
            tb55.Text = "6";
            tb57.Text = "8";
            tb48.Text = "9";
            tb59.Text = "5";
            tb69.Text = "2";
            tb81.Text = "8";
            tb91.Text = "7";
            tb82.Text = "1";
            tb92.Text = "2";
            tb73.Text = "5";
            tb94.Text = "8";
            tb86.Text = "7";
            tb76.Text = "1";
            tb77.Text = "6";
            tb78.Text = "8";
            tb88.Text = "2";
            tb89.Text = "3";
            tb89.Text = "9";
        }

        private void Tb13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb61_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb62_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb64_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb69_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb83_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb95_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb94_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb86_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb85_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb84_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb96_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb74_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb93_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb75_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tb97_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            bool st;
            int[,] Clue = new int[9,9];
            Clue = Sample1();
            Rrr r = new Rrr(Clue);
            st = r.Step();
            Console.WriteLine(st.ToString());
        }//endbtnSolve

        private int[,] Sample1()
        {
            int[,] Clue = new int[9, 9] {
                {0,8,0,0,0,2,0,5,3},
                {3,5,0,0,8,0,0,4,1},
                {0,4,1,7,0,0,9,0,0},
                {5,0,0,0,0,0,0,9,0},
                {1,0,3,0,6,0,8,0,5},
                {0,6,0,0,0,0,0,0,2},
                {0,0,5,0,0,1,6,8,0},
                {8,1,0,0,7,0,0,2,9},
                {7,2,0,8,0,0,0,3,0}
            };
            return Clue;
        }//endSample1
        private void ShowInitialCube(int[,,] cube)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {

                    for (int a = 0; a < 9; a++)
                    {
                        Console.WriteLine("r: "+r+"c: "+c+"a "+a+" = " + cube[r, c, a]);
                    }
                    Console.WriteLine("\n");
                }

            }
        }//end ShowInitialCube
    }
}

//for (int r = 0; r< 9; r++) //Counting of Cubes cells starts from 0 to 8
//            {
//                for (int c = 0; c< 9; c++)
//                {
                    
                    
//                    if (Clue[r, c] == 0) // for Sudoku that row and culumn has 0
//                    {
//                        for (int a = 0; a< 9; a++)
//                        {
//                            cubeHolder[r, c, a] = 0;
//                        }
                               
//                    }
//                    else // for Sudoku that row and culumn has digit
//                    {
//                        int digit;
//                        for (int a = 0; a< 9; a++)
//                        {
//                            digit = Clue[r, c];
//                            if (a == digit - 1)
//                            {
//                                cubeHolder[r, c, a] = digit;
//                            }
//                            else
//                                cubeHolder[r, c, a] = 0;

//                        }
//                    }
//                }
