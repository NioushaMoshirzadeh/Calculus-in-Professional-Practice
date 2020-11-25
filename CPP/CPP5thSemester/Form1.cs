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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace CPP5thSemester
{
    public partial class Form1 : Form
    {
        Parsing parsing;// private object parsing;
        private IFunction root;
        string s , temp;
        Graphics g;
        Pen pen, derivativePen;
        int zoomValue;
        int orgX ;
        int orgY ;

        public Form1()
        {
            InitializeComponent();
            s = tbParse.Text;
            temp = s;
            //----------------------------------
            tbResult.Text = temp;
            pen = new Pen(Brushes.Black, 5.0F);
            g = pictureBox1.CreateGraphics();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //int picWidth = pictureBox1.Width;
            //int picHeight = pictureBox1.Height;
            //Bitmap bmp = new Bitmap(picWidth, 5);
            //--------------------------------------------
            
        }

        private void DrawBinaryTree()
        {
                    GraphVize.SaveDotFile(root, "abcd");
                    Process dot = new Process();
                    dot.StartInfo.FileName = "dot.exe";
                    dot.StartInfo.Arguments = "-T png -o abc.png abcd.dot";
                    dot.Start();
                    dot.WaitForExit();
                    picBox_tree.ImageLocation = "abc.png";          
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
            chart.AxisX.Interval= 1;
            chart.AxisY.Interval= 1;
            chart.AxisX.LabelStyle.IsEndLabelVisible = true;
            //--------------------------adjustment of xaxis and yaxis of chart/different scale---------------
            /*picture box properties*/
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            trackBar1.Width = 100;
            trackBar1.Height = 50;
            trackBar1.Minimum = 0;
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
            tbResult.Text = root.ToInfix();
            DrawBinaryTree();
            tbParse.Text = s;
            for (float i = -5; i < 5; i += 0.1F)
            {
               // derivativeOutput = root.Derivative(i);
                OutPut = root.Evaluate(i);
               // Console.WriteLine(derivativeOutput);
                chart1.Series["Equation_graph"].Points.AddXY(i, OutPut);
                //chart1.Series["Derivative_graph"].Points.AddXY(i, derivativeOutput);
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

        private void Button1_Click(object sender, EventArgs e)         /*  plot the derivative*/
        {
            //-----Chart1-----
            double derivativeOutput;
            for (float i = -5; i < 5; i += 0.1F)
            {
                derivativeOutput = root.Derivative(i);

                Console.WriteLine(derivativeOutput);

                chart1.Series["Derivative_graph"].Points.AddXY(i, derivativeOutput);
            }

            /*plot on the pictureBox*/
            zoomValue = trackBar1.Value;
            orgX = pictureBox1.Width / 2;
            orgY = pictureBox1.Height / 2;  
            derivativePen = new Pen(Brushes.Red, 2.0F);

            for (float i = -orgX; i < pictureBox1.Height; i += 0.01f)
            {
                double X = (double)i;
                float Y = (float)root.Derivative(X) * zoomValue;
                float Y2 = ((float)root.Derivative(i + 0.1) * zoomValue);

                g.DrawLine(pen, (float)(X * zoomValue) + orgX, orgY - Y, (float)(orgX + (X * zoomValue) + 0.1), orgY - Y2);
            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnPicPlot_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            g = pictureBox1.CreateGraphics();
            Pen pen      = new Pen(Brushes.Black, 2.0f);
            Pen grayPen  = new Pen(Brushes.LightGray, 2.0f);
            Pen whitePen = new Pen(Brushes.White, 2.0F);
            zoomValue = trackBar1.Value;
            orgX = pictureBox1.Width / 2;
            orgY = pictureBox1.Height / 2;

            if ((trackBar1.Value >= 60 && trackBar1.Value <= 90))
            {
                for (int i = 0; i < orgX; i += zoomValue)
                {
                    g.DrawLine(whitePen, i, 0, i, pictureBox1.Width);
                }
                for (int i = 200; i < pictureBox1.Width; i += zoomValue)
                {
                    g.DrawLine(whitePen, i, 0, i, pictureBox1.Width);
                }
                for (int j = 0; j < orgY; j += zoomValue)
                {
                    g.DrawLine(whitePen, 0, j, pictureBox1.Width, j);
                }
                for (int j = 200; j < pictureBox1.Height; j += zoomValue)
                {
                    g.DrawLine(whitePen, 0, j, pictureBox1.Width, j);
                }

            }
            else
            {
                for (int i = 0; i < orgX; i += zoomValue)
                {
                    g.DrawLine(grayPen, i, 0, i, 400);
                }
                for (int i = 200; i < pictureBox1.Width; i += zoomValue)
                {
                    g.DrawLine(grayPen, i, 0, i, 400);
                }
                for (int j = 0; j < orgY; j += zoomValue)
                {
                    g.DrawLine(grayPen, 0, j, pictureBox1.Width, j);
                }
                for (int j = 200; j < pictureBox1.Height; j += zoomValue)
                {
                    g.DrawLine(grayPen, 0, j, pictureBox1.Width, j);
                }
            }
            g.DrawLine(pen, 0, orgY, pictureBox1.Width, orgY);
            g.DrawLine(pen, orgX, 0, orgY, pictureBox1.Height);

            for (float i = -orgX; i < pictureBox1.Height; i += 0.01f)
            {
                double X = (double)i;
                float Y = (float)root.Evaluate(X) * zoomValue;
                float Y2 = ((float)root.Evaluate(i + 0.1) * zoomValue);

                g.DrawLine(pen, (float)(X * zoomValue) + orgX, orgY - Y, (float)(orgX + (X * zoomValue) + 0.1), orgY - Y2);


            }  
        }
    }
}
