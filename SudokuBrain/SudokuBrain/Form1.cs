﻿using System;
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
        bool isbtnSample1Clicked;
        bool isbtnSample2Clicked;
        bool isbtnSample3Clicked;
        bool isbtnSample4Clicked;
        public Form1()
        {
            InitializeComponent();
            chartLoad();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
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
            ShowInitialSudolu(Sample1());
            isbtnSample1Clicked = true;
            isbtnSample2Clicked = false;
            isbtnSample3Clicked = false;
            isbtnSample4Clicked = false;
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
            int[,] Clue; //= new int[9,9];
            int[,] Answer;
            List<int> diff = new List<int>();
            chart1.Series["Difference"].Points.Clear();
            if (isbtnSample1Clicked)
            {
                Clue = Sample1();
            }
            else if(isbtnSample2Clicked)
            {
                Clue = Sample2();
            }
            else if (isbtnSample3Clicked)
            {
                Clue = Sample3();
            }
            else if (isbtnSample4Clicked)
            {
                Clue = Sample4();
            }
            else
            {
                MessageBox.Show("please select one of the samples\n" +
                                "other wise the default sample is selected");
                Clue = Sample1();
            }
            Rrr r = new Rrr(Clue);
            r.Step();
            Answer = r.SudokuAnswerForm();
            diff = r.diffData();
            PrintSudokuAnswer(Answer,"final");
            printChartDiff(diff);
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

        private int[,] Sample2()
        {
            int[,] Clue = new int[9, 9] {
                {0,0,0,0,7,2,0,6,0},
                {0,0,6,0,0,0,1,0,0},
                {5,0,0,6,0,0,0,0,0},
                {0,3,0,0,9,0,0,0,8},
                {2,0,5,0,3,0,6,0,1},
                {6,0,0,0,5,0,0,7,0},
                {0,0,0,0,0,8,0,0,4},
                {0,0,9,0,0,0,3,0,0},
                {0,8,0,9,6,0,0,0,0}
            };
            return Clue;
        }//endSample2
        private int[,] Sample3()
        {
            int[,] Clue = new int[9, 9] {
                {0,1,2,0,0,0,0,0,0},
                {0,0,0,3,0,6,5,4,0},
                {0,0,4,0,0,7,0,3,0},
                {0,5,0,0,0,8,1,2,0},
                {0,0,6,7,0,0,0,0,0},
                {0,0,0,0,0,1,6,8,0},
                {0,3,7,0,0,9,2,6,0},
                {0,0,5,0,0,0,0,1,0},
                {0,9,1,5,0,2,3,0,0}
            };
            return Clue;
        }//endSample3
        private int[,] Sample4()
        {
            int[,] Clue = new int[9, 9] {
                {8,0,0,0,0,0,0,0,0},
                {0,0,3,6,0,0,0,0,0},
                {0,7,0,0,9,0,2,0,0},
                {0,5,0,0,0,7,0,0,0},
                {0,0,0,0,4,5,7,0,0},
                {0,0,0,1,0,0,0,3,0},
                {0,0,1,0,0,0,0,6,8},
                {0,0,8,5,0,0,0,1,0},
                {0,9,0,0,0,0,4,0,0}
            };
            return Clue;
        }//endSample4
        private void ShowInitialSudolu(int[,] SudokuNewspaper)
        {
            tb11.Text = "";
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (SudokuNewspaper[r, c] != 0)
                    {
                        tb11.Text += SudokuNewspaper[r, c].ToString(); 
                        tb11.Text += " ";
                    }
                    else
                    {
                        tb11.Text += "-";
                        tb11.Text += " ";
                    }
                }
            }
        }//end ShowInitialCube
        private void PrintSudokuAnswer(int[,] SudokuArray,string txt)
        {
            int index = 0;
            int[,] sample;
            if (isbtnSample1Clicked)
            {
                sample = Sample1();
            }
            else if (isbtnSample2Clicked)
            {
                sample = Sample2();
            }
            else if (isbtnSample3Clicked)
            {
                sample = Sample3();
            }
            else if (isbtnSample4Clicked)
            {
                sample = Sample4();
            }
            else
            {
                sample = Sample1();
            }
            tb11.Text = " ";
            richTextBox1.Text = "";
            for (int row = 0; row < 9; row++)
            {
                tb11.Text += Environment.NewLine;
                richTextBox1.Text += Environment.NewLine;
                for (int column = 0; column < 9; column++)
                {
                    if (sample[row, column] != 0)
                    {
                        tb11.Text += sample[row, column].ToString();
                        tb11.Text += " ";
                        richTextBox1.Text += sample[row, column].ToString();
                        richTextBox1.Text += " ";
                    }
                    else
                    {
                        tb11.Text += SudokuArray[row, column].ToString();
                        tb11.Text += " ";
                        richTextBox1.Text += SudokuArray[row, column].ToString();
                        richTextBox1.Text += " ";
                    }
                }
            }
            if (isbtnSample1Clicked)
            {
                MakeSudokuSampleGreen(Sample1());
            }
            else if (isbtnSample2Clicked)
            {
                MakeSudokuSampleGreen(Sample2());
            }
            else if (isbtnSample3Clicked)
            {
                MakeSudokuSampleGreen(Sample3());
            }
            else if (isbtnSample4Clicked)
            {
                MakeSudokuSampleGreen(Sample4());
            }
        }
        private void MakeSudokuSampleGreen(int[,] sample)
        {
            int index;
            for (int i = 1; i < 10; i++) // rich has 9 lines that the first is empty
            {
                for (int column = 0; column < 9; column++)
                {
                    if (sample[i - 1, column] != 0)
                    {
                        int num = Convert.ToChar(sample[i - 1, column]);
                        string var = (num).ToString();
                        index = richTextBox1.Lines[i].IndexOf(var);
                        if (index != -1)
                        {
                            richTextBox1.Select(index + 1 + (i-1)*19, 1);
                            richTextBox1.SelectionColor = Color.Green;
                        }
                    }
                }
             }
        }
        private void BtnSample2_Click(object sender, EventArgs e)
        {
            ShowInitialSudolu(Sample2());
            isbtnSample1Clicked = false;
            isbtnSample2Clicked = true;
            isbtnSample3Clicked = false;
            isbtnSample4Clicked = false;
        }
        private void chartLoad()
        {
            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisX.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = 0;
            chart.AxisY.Minimum = 0;

            chart.AxisX.Interval = 10;
            chart.AxisY.Interval = 50;

            chart1.Series[0].IsVisibleInLegend = false;

            chart1.Series.Add("Difference");
            chart1.Series["Difference"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Difference"].Color = Color.Green;

            chart1.Series.Add("Iteration");
            chart1.Series["Iteration"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Iteration"].Color = Color.Blue;
            chart1.Series["Difference"].Points.AddXY(400, 400);
        }

        private void printChartDiff(List<int> diff)
        {
            int itteration = diff.Count;
            for (int i = 0; i < itteration ; i += 1)
            {
                chart1.Series["Difference"].Points.AddXY(i, diff[i]);
            }
        }

        private void BtnSample3_Click(object sender, EventArgs e)
        {
            ShowInitialSudolu(Sample3());
            isbtnSample3Clicked = true;
            isbtnSample1Clicked = false;
            isbtnSample2Clicked = false;
            isbtnSample4Clicked = false;
        }

        private void BtnSample4_Click(object sender, EventArgs e)
        {
            ShowInitialSudolu(Sample4());
            isbtnSample3Clicked = false;
            isbtnSample1Clicked = false;
            isbtnSample2Clicked = false;
            isbtnSample4Clicked = true;
        }
    }
}


