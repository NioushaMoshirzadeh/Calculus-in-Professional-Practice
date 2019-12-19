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
        Pen pen;
        //List<double> myValues;
        //----------------------------------------------------
        
        float x1 = 0;
        float y1 = 257F;
        float y2 = 0;
        float yEx = 257; ////spacing from the top
        float eF = 50;//size multiplier
        //----------------------------------------------------
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
            int picWidth = pictureBox1.Width;
            int picHeight = pictureBox1.Height;
            Bitmap bmp = new Bitmap(picWidth, 5);
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
            //Image image = Image.FromFile("C:/Users/nisha/Documents/my-git-project/CPP/CPP5thSemester/bin/Debug/abc.png");
            //picBox_tree.Image = image;
            //picBox_tree.Height = image.Height;
            //picBox_tree.Width = image.Width;
            //@"C: \Users\nisha\Downloads\graphviz\cppGraphViz\release\bin\dot.exe", @"-Tpng D:\tmp.dot -o D:\tmp.png"
            picBox_tree.ImageLocation = "abc.png";          
        }
        double plotEvaluation(double value)
        {
            //Math.PI * degrees / 180.0
            // double val = (double) Math.PI * (double)value / 180.0;
            // s = tbParse.Text;
            //parsing = new Parsing();
            //root = parsing.fpa(ref s);
            return (value);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //in order to create chart in form 2
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-5, 5);
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(-5, 5);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

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
            //-----------------------------------------
            //for (float i = 0; i < 5; i += 1)
            //{
            //    OutPut = root.Evaluate(i);
            //    y2 = (float)plotEvaluation((double)OutPut);

            //    MessageBox.Show(y2.ToString());
            //}
            //------------------------------------------
            // double evaluation = root.Evaluate();
            // myValues = root.SinX();
            for (float i = -5; i < 5; i += 0.1F)
            {
                OutPut = root.Evaluate(i);
                chart1.Series[0].Points.AddXY(i, OutPut);
                //chart1.Series[0].Points.AddXY(i, plotEvaluation(evaluation));
                //choose type of chart is line 
                //  chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
                // this.chart1.DataBind();

        }

        private void PicBox_tree_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //2
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        //private void SinusPlot(Graphics Grf)
        //{
        //    Plot MyPlot = new Plot();
        //    double x = 0.0;
        //    double y = 0.0;
        //    MyPlot.ClientArea = this.ClientSize;
        //    MyPlot.SetPlotPort(-10, 10, -5, 5);
        //    for (x = -7.0; x < 10.0; x += 0.025)
        //    {
        //        y = Math.Sin(x);
        //        MyPlot.PlotPixel(x, y, Color.BlueViolet, Grf);
        //    }
        //}
        //private void MiraPlot(Graphics Grf)
        //{
        //    Plot MyPlot = new Plot();
        //    double a = -0.46;
        //    double b = 0.99;
        //    double c = 2.0 - 2.0 * a;
        //    double x = 12.0;    //start value
        //    double y = 0.0;     //start value
        //    double z;
        //    double w = a * x + c * x * x / (1 + x * x);
        //    MyPlot.ClientArea = this.ClientSize;
        //    MyPlot.SetPlotPort(-20, 20, -20, 20);
        //    for (int n = 0; n < 20000; n++)
        //    {
        //        MyPlot.PlotPixel(x, y, Color.Black, Grf);
        //        z = x;
        //        x = b * y + w;
        //        w = a * x + c * x * x / (1 + x * x);
        //        y = w - z;
        //    }
        //}

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
        //    Graphics Grf = e.Graphics;
        //    MiraPlot(Grf);
        //    SinusPlot(Grf);
        }

    private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnPicPlot_Click(object sender, EventArgs e)
        {
            //tbResult.Text = temp;
            pen = new Pen(Brushes.Blue, 5.0F);
            Pen gridpen = new Pen(Color.Black, 2);
            for (int i = 0; i < 514; i += 20)
            {
                g.DrawLine(gridpen, 0, i, 514, i);
                
            }
            for (int j = 0; j < 514; j += 20)
            {
                g.DrawLine(gridpen, j, 0, j, 565);

            }

            g = pictureBox1.CreateGraphics();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            int picWidth = pictureBox1.Width;
            int picHeight = pictureBox1.Height;
            Bitmap bmp = new Bitmap(picWidth, picHeight);
            float x1 = 0;
            float y1 = picWidth;
            float y2 = 0;
            float yEx = 200; ////spacing from the top
            float eF = 20;//size multiplier
            for (float i = -0.5F; i < picWidth; i +=0.1F)
            {
                y2 =(float)root.Evaluate(i);
                //y2 = (float)plotEvaluation((double)i);

                //MessageBox.Show(y2.ToString());
                // y2 = (float)Math.Sin(i);
                g.DrawLine(pen, x1 * eF, y1 * eF + yEx, i * eF, y2 * eF + yEx);
                Console.WriteLine(y2);
                // bmp.SetPixel((int)i, (picHeight / 2) - (int)y2, Color.Red);
              // bmp.SetResolution(i, (picHeight / 2) - y2);
                x1 = i;
                y1 = y2;

            }
           // pictureBox1.Image = bmp;
        }
    }
}
