﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;



namespace CPP5thSemester
{
    public partial class Form1 : Form
    {
        Parsing parsing;
        private IFunction root;
        string s , temp;
        Graphics g;
        Pen pen, derivativePen;
        int zoomValue;
        int orgX ;
        int orgY ;
        List<Point> coordinates = new List<Point>();
        List<Point> polynomialPoints = new List<Point>();
        int iNumberofClicks = 0;
        Matrix matrix;

        public Form1()
        {
            InitializeComponent();
            s = tbParse.Text;
            temp = s;
            tbResult.Text = temp;
            pen = new Pen(Brushes.Black, 5.0F);
            g = pictureBox1.CreateGraphics();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void DrawBinaryTree( IFunction x)
        {
            GraphVize.SaveDotFile(x, "abcd");
            Process dot = new Process();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = "-T png -o abc.png abcd.dot";
            dot.Start();
            dot.WaitForExit();
            picBox_tree.ImageLocation = "abc.png";
        }

        private void DrawBinaryTreeMCLauran(IFunction x) // draw McLaurin on the .PNG file
        {
            GraphVize.SaveDotFile(x, "abcd");
            Process dot = new Process();
            dot.StartInfo.FileName = "dot.exe";
            dot.StartInfo.Arguments = "-T png -o abc.png abcd.dot";
            dot.Start();
            dot.WaitForExit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create chart in form 2
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-5, 5);
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(-5, 5);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //-------------------------------extend the derivative chart-----------------------------------
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series.Add("Equation_graph");
            chart1.Series["Equation_graph"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Equation_graph"].Color = Color.Blue;
            chart1.Series.Add("Derivative_graph");
            chart1.Series["Derivative_graph"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Derivative_graph"].Color = Color.Green;
            //--------------------end-----------------------------------------------------------------------
            var chart = chart1.ChartAreas[0];
            chart.AxisX.Minimum = 0;
            chart.AxisY.Minimum = 0;
            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 1;
            chart.AxisX.LabelStyle.IsEndLabelVisible = true;
            //--------------------------adjustment of xaxis and yaxis of chart/different scale---------------
            /*picture box properties*/
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            trackBar1.Width = 100;
            trackBar1.Height = 50;
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 100;
            trackBar1.Value = 10;
            trackBar1.TickFrequency = 20;
            trackBar1.TickStyle = TickStyle.BottomRight;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);
            /*End picture box properties*/
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            lbX.Refresh();
            lbY.Refresh();
            string value = chart1.ChartAreas[0]
                 .CursorX.SelectionEnd.ToString();
            string value_y = chart1.ChartAreas[0].CursorY.SelectionEnd.ToString();
            lbX.Text = "CursurX value is :" + value;
            lbY.Text = "CursurY value is :" + value_y;
        }
        private void btnPars_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbParse.Text))
            {
                MessageBox.Show("please enter your equation in the txt box!");
            }
            else
            {
                try
                {
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    double OutPut;
                    tbResult.Text = "";
                    s = tbParse.Text;
                    tbResult.Text = temp;
                    parsing = new Parsing();
                    root = parsing.fpa(ref s);
                    tbResult.Text = parsing.EquationHumanReadablitly();
                    DrawBinaryTree(root);
                    tbParse.Text = s;
                    /* plot the function on the chart */
                    for (float i = -5; i < 5; i += 0.1F)
                    {
                        OutPut = root.Evaluate(i);
                        chart1.Series["Equation_graph"].Points.AddXY(i, OutPut);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
                
        }

        /* not tochable *///-----------------------------------becarefull-----------------------------------------------
        private void PicBox_tree_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
       

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
        
        }
        /* not tochable *///----------------------------------------------------------------------------------

        private void Button1_Click(object sender, EventArgs e)         /*plot derivative*/
        {
            if (coordinates != null)
                foreach (var item in coordinates)
                {
                    coordinates.Remove(item);
                }

            /*plot on the pictureBox*/
            zoomValue = trackBar1.Value;
            orgX = pictureBox1.Width / 2;
            orgY = pictureBox1.Height / 2;
            derivativePen = new Pen(Brushes.Red, 2.0F);

            /* plot Newton's derivative with pen purple */
            derivativePen = new Pen(Brushes.Purple, 2.0F);
            for (float i = -orgX; i <= pictureBox1.Height /2; i += 0.01f)
            {
                double h = 0.01;
                double Y1 = ((root.Evaluate(i + h) - root.Evaluate(i)) / h); //f(x+h) - f(x) / h
                double Y2 = ((root.Evaluate(i + (0.01) + h) - root.Evaluate(i + (0.01))) / h);
                Y1 = ((-1) * Y1 * zoomValue) + orgY;
                Y2 = ((-1) * Y2 * zoomValue) + orgY;
                double X = (zoomValue * i) + orgX;
                double X2 = (zoomValue * i) + orgX + 0.01f;
                if (Y1 <= pictureBox1.Height && Y2 <= pictureBox1.Height && Y1 >= 0 && Y2 >= 0)
                    g.DrawLine(derivativePen, (float)X, (float)Y1, (float)X2, (float)Y2);
                /*****/
                //double h = 0.0001d;
                //float Y1 = (((float)root.Evaluate(i + h) - (float)root.Evaluate(i)) / (float)h) * zoomValue; //f(x+h) - f(x) / h
                //float Y2 = (((float)root.Evaluate(i + (0.01) + h) - (float)root.Evaluate(i + (0.01))) / (float)h) * zoomValue;
                //if (Y1 <= pictureBox1.Height/2 && Y2 <= pictureBox1.Height/2 && Y1 >= -200 && Y2 >= -200)
                //    g.DrawLine(derivativePen, (i * zoomValue) + orgX, orgY - Y1, orgX + (i * zoomValue) + 0.01f, orgY - Y2);
            }

            /* plot the Analytical derivative and plotting the tree*/
            IFunction p;
            p = root.derivative();
            DrawBinaryTree(p);
            derivativePen = new Pen(Brushes.Green, 2.0F);
            for (float i = -orgX; i <= pictureBox1.Height; i += 0.01f)
            {
                double X = (double)i;
                float Y = (float)p.Evaluate(X) * zoomValue;
                float Y2 = ((float)p.Evaluate(i + 0.1) * zoomValue);
                if (Y <= pictureBox1.Height / 2 && Y2 <= pictureBox1.Height / 2 && Y >= -200 && Y2 >= -200)
                    g.DrawLine(derivativePen, (float)(X * zoomValue) + orgX, orgY - Y, (float)(orgX + (X * zoomValue) + 0.1), orgY - Y2);
            }

        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Brushes.Red, 2.0f);
            Point point = new Point(e.X, e.Y);
            polynomialPoints.Add(point);
            coordinates.Add(point);
            iNumberofClicks++;
            if (iNumberofClicks > 0)
                foreach (var a in coordinates)
                {
                    Console.WriteLine("Points are : " + a.ToString());
                }
            g.DrawEllipse(pen, new Rectangle(e.X, e.Y, 5, 5));
            g.Save();
        }

        private void BtnIntegral_Click(object sender, EventArgs e)
        {
            orgX = pictureBox1.Width / 2;
            Pen darkblue = new Pen(Brushes.DarkBlue, 2.0F);
            int zoomValue = trackBar1.Value;
            if (coordinates.Count == 0)
            {
                MessageBox.Show("please selects your points!");
            }
            else
            {
                float X1 = (coordinates[0].X - orgX) / zoomValue;
                float X2 = (coordinates[1].X - orgX) / zoomValue;
                Console.WriteLine("Points calculated are : " + X1.ToString() + "\t" + X2.ToString());
                float Y1 = 0;
                float integral = 0;

                for (float i = X1; i <= X2; i += 0.1f)
                {
                    double X = (double)i;
                    Y1 = (float)root.Evaluate(X);
                    integral += (0.1f * Y1);
                    g.DrawLine(darkblue, (i * zoomValue) + orgX, orgX, (i * zoomValue) + orgX, orgY - (Y1 * zoomValue));
                }
                Console.WriteLine("integral value is : " + integral.ToString() + "\n");
                coordinates.Clear();
            } 
        }

        private void BtnPolynomial_Click(object sender, EventArgs e)
        {
            try
            {
                DrawGridLines();
                pictureBox1.Refresh();
                int nrOfPoints = coordinates.Count();
                orgX = pictureBox1.Width / 2;
                orgY = pictureBox1.Height / 2;
                zoomValue = trackBar1.Value;
                List<Point> convertedPoints = new List<Point>();
                Point point, demoPoints;
                for (int i = 0; i < nrOfPoints; i++)
                {
                    int X = (coordinates[i].X - orgX) / zoomValue; //the values rounded to its int values!!
                    int Y = (orgX - coordinates[i].Y) / zoomValue;
                    point = new Point(X, Y);
                    convertedPoints.Add(point);
                }

                matrix = new Matrix(nrOfPoints, convertedPoints);
                double[,] AugmentedArray = matrix.solveEquation();
                string equation = "";
                int deg = nrOfPoints - 1;
                for (int r = 0; r < nrOfPoints; r++)
                {
                    var s = string.Format("{0:0.00}", AugmentedArray[r, nrOfPoints + 1]);
                    if (s.EndsWith("00"))
                    {
                        s = ((int)AugmentedArray[r, nrOfPoints + 1]).ToString();
                    }
                    if (deg != 0)
                    {

                        equation += s + "x^" + " (" + (deg).ToString() + ") " + " + ";
                    }
                    else
                    {
                        equation += " (" + s + ") ";
                    }
                    deg--;
                }
                tbParse.Text = equation;
                Console.WriteLine(equation);
                pen = new Pen(Brushes.Green, 2.0F);
                Pen grayPen = new Pen(Brushes.LightGray, 2.0F);
                Pen blackPen = new Pen(Brushes.Black, 2.0F);
                Pen pinki = new Pen(Brushes.Pink, 2.0F);

                double Y1 = 0;
                double Y2 = 0;
                float X1 = 0;
                float X2 = 0;
                DrawGridLines();


                for (float i = -200; i < (pictureBox1.Height) / 2; i += 0.01f)
                {
                    int deg2 = nrOfPoints - 1;
                    for (int j = 0; j < nrOfPoints; j++)
                    {
                        if (deg2 > 0)
                        {
                            Y1 += (float)(AugmentedArray[j, nrOfPoints + 1] * (Math.Pow(i, deg2)));
                            Y2 += (float)(AugmentedArray[j, nrOfPoints + 1] * (Math.Pow((i + 0.01f), deg2)));

                        }
                        else
                        {
                            Y1 += (float)((AugmentedArray[j, nrOfPoints + 1]));
                            Y2 += (float)((AugmentedArray[j, nrOfPoints + 1]));
                        }
                        deg2--;
                    }
                    Y1 = Math.Round(Y1, 2);
                    Y2 = Math.Round(Y2, 2);
                    Y1 = ((-1) * Y1 * zoomValue) + orgY;
                    Y2 = ((-1) * Y2 * zoomValue) + orgY;
                    X1 = (zoomValue * i) + orgX;
                    X2 = (zoomValue * (i + 0.1f)) + orgX;
                    if (Y1 <= pictureBox1.Height && Y2 <= pictureBox1.Height && Y1 >= 0 && Y2 >= 0)
                        g.DrawLine(pen, X1, (float)Y1, X2, (float)Y2);
                    Y1 = Y2 = 0;
                }
                int poinsCount = polynomialPoints.Count;
                foreach (var item in polynomialPoints)
                {
                    demoPoints = item;
                    int x = (demoPoints.X - orgX) / zoomValue;
                    x = (zoomValue * x) + orgX;
                    int y = (demoPoints.Y - orgX) / zoomValue;
                    y = (zoomValue * y) + orgX;
                    g.DrawEllipse(new Pen(Brushes.Red, 2.0F), new Rectangle(x, y, 5, 5));
                    g.Save();
                }
                polynomialPoints.Clear();
                coordinates.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMCLaurin_Click(object sender, EventArgs e)
        {
            double result = 0;
            zoomValue = trackBar1.Value;
            double[] coefficient = new double[8];
            double Y1 = 0;
            double Y2 = 0;
            float X1 = 0;
            float X2 = 0;
            var Colors = new List<Color>
            {
                Color.Yellow,
                Color.Orange,
                Color.Pink,
                Color.Red,
                Color.Purple,
                Color.Blue,
                Color.Brown,
                Color.Black
            };

            try
            {
                for (int i = 0; i <= 7; i++) // added coefficient of the taylor series in the array
                {

                    if (i == 0)
                    {
                        result = root.Evaluate(0);
                        coefficient[i] = result;

                    }
                    else
                    {
                        root = root.derivative();
                        result = (root.Evaluate(0) / Factorial(i));
                        if (double.Equals(double.NaN, result))
                        {
                            result = 0;
                        }
                        else
                            coefficient[i] = result;
                    }
                }

                //DrawBinaryTreeMCLauran(root);
                DrawGridLines();
                for (int i = 7; i >= 0; i--)
                {
                    string equation = "";
                    equation += coefficient[i].ToString() + " * x^ " + (i).ToString();
                    Console.WriteLine(equation);
                }

                for (float j = -200; j < (pictureBox1.Height) / 2; j += 0.01f)
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        if (i == 0)
                        {
                            Y1 = coefficient[0];
                            Y2 = coefficient[0];
                        }
                        else
                        {
                            Y1 += coefficient[i] * Math.Pow(j, i);
                            Y2 += coefficient[i] * Math.Pow((j + 0.01f), i);
                        }
                        if (Y1 <= pictureBox1.Height / 2 && Y2 <= pictureBox1.Height / 2 && Y1 >= -200 && Y2 >= -200)
                            g.DrawLine(new Pen(Colors[i], 2f), (zoomValue * j) + orgX, (float)((-1) * Y1 * zoomValue + orgY), (zoomValue * j) + orgX + 0.1f, (float)((-1) * Y2 * zoomValue + orgY));
                    }
                    Y1 = ((-1) * Y1 * zoomValue) + orgY;
                    Y2 = ((-1) * Y2 * zoomValue) + orgY;
                    X1 = (zoomValue * j) + orgX;
                    X2 = (zoomValue * j) + orgX + 0.01f;
                    if (Y1 <= pictureBox1.Height && Y2 <= pictureBox1.Height && Y1 >= 0 && Y2 >= 0)
                        g.DrawLine(new Pen(Colors[6], 2f), X1, (float)Y1, X2, (float)Y2);
                    Y1 = Y2 = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        private void DrawGridLines()
        {
            pictureBox1.Refresh();
            orgX = pictureBox1.Width / 2;
            orgY = pictureBox1.Height / 2;
            zoomValue = trackBar1.Value;
            Pen grayPen = new Pen(Brushes.LightGray, 2.0F);
            Pen blackPen = new Pen(Brushes.Black, 2.0F);
            for (int i = ((pictureBox1.Width / 2) - zoomValue); i >= 0; i -= zoomValue)
            {
                g.DrawLine(grayPen, i, 0, i, 400);
            }
            for (int i = ((pictureBox1.Width / 2) - zoomValue); i <= pictureBox1.Width; i += zoomValue)
            {
                g.DrawLine(grayPen, i, 0, i, 400);
            }

            for (int j = ((pictureBox1.Height / 2) - zoomValue); j >= 0; j -= zoomValue)
            {
                g.DrawLine(grayPen, 0, j, pictureBox1.Width, j);
            }
            for (int j = ((pictureBox1.Height / 2) - zoomValue); j <= pictureBox1.Height; j += zoomValue)
            {
                g.DrawLine(grayPen, 0, j, pictureBox1.Width, j);
            }

            g.DrawLine(blackPen, 0, orgY, pictureBox1.Width, orgY);
            g.DrawLine(blackPen, orgX, 0, orgY, pictureBox1.Height);
        }


        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnPicPlot_Click(object sender, EventArgs e)
        {
            try
            {
                if (coordinates != null)
                    foreach (var item in coordinates.ToList())
                    {
                        coordinates.Remove(item);
                    }
                pictureBox1.Refresh();
                g = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Brushes.Black, 2.0f);
                Pen grayPen = new Pen(Brushes.LightGray, 2.0f);
                zoomValue = trackBar1.Value;
                orgX = pictureBox1.Width / 2;
                orgY = pictureBox1.Height / 2;
                DrawGridLines();
                for (float i = -orgX; i < pictureBox1.Height/2; i += 0.01f)
                {
                    double X = (double)i;
                    float Y = (float)root.Evaluate(X);
                    float Y2 = (float)root.Evaluate(i + 0.1);
                    Y = ((-1) * Y * zoomValue) + orgY;
                    Y2 = ((-1) * Y2 * zoomValue) + orgY;
                    X = (zoomValue * i) + orgX;
                    float X2 = (zoomValue * i) + orgX + 0.01f;
                    if (Y <= pictureBox1.Height && Y2 <= pictureBox1.Height && Y >= 0 && Y2 >= 0)
                        g.DrawLine(pen, (float)X, Y, X2, Y2);

                    /*Second option*/
                    //double X = (double)i;
                    //float Y = (float)root.Evaluate(X) * zoomValue;
                    //float Y2 = ((float)root.Evaluate(i + 0.1) * zoomValue);
                    //Y = orgY - Y;
                    //X = (float)(X * zoomValue) + orgX;
                    //float X2 = (float)(orgX + (X * zoomValue) + 0.1);
                    //Y2 = orgY - Y2;
                    //if (Y <= pictureBox1.Height && Y2 <= pictureBox1.Height && Y >= 0 && Y2 >= 0)
                    //    g.DrawLine(pen, (float)X, Y, X2, Y2);
                    /*first option*/
                    //double X = (double)i;
                    //float Y = (float)root.Evaluate(X) * zoomValue;
                    //float Y2 = ((float)root.Evaluate(i + 0.1) * zoomValue);
                    //if (Y <= pictureBox1.Height && Y2 <= pictureBox1.Height )
                    //    g.DrawLine(pen, (float)(X * zoomValue) + orgX, orgY - Y, (float)(orgX + (X * zoomValue) + 0.1), orgY - Y2);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
