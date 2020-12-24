namespace CPP5thSemester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnPars = new System.Windows.Forms.Button();
            this.tbParse = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.picBox_tree = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlot = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbX = new System.Windows.Forms.Label();
            this.lbY = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPicPlot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnIntegral = new System.Windows.Forms.Button();
            this.btnPolynomial = new System.Windows.Forms.Button();
            this.btnMCLaurin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPars
            // 
            this.btnPars.Location = new System.Drawing.Point(13, 14);
            this.btnPars.Margin = new System.Windows.Forms.Padding(4);
            this.btnPars.Name = "btnPars";
            this.btnPars.Size = new System.Drawing.Size(140, 37);
            this.btnPars.TabIndex = 0;
            this.btnPars.Text = "Parse";
            this.btnPars.UseVisualStyleBackColor = true;
            this.btnPars.Click += new System.EventHandler(this.btnPars_Click);
            // 
            // tbParse
            // 
            this.tbParse.Location = new System.Drawing.Point(161, 18);
            this.tbParse.Margin = new System.Windows.Forms.Padding(4);
            this.tbParse.Name = "tbParse";
            this.tbParse.Size = new System.Drawing.Size(771, 22);
            this.tbParse.TabIndex = 1;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(161, 48);
            this.tbResult.Margin = new System.Windows.Forms.Padding(4);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(771, 22);
            this.tbResult.TabIndex = 2;
            // 
            // picBox_tree
            // 
            this.picBox_tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_tree.Location = new System.Drawing.Point(13, 100);
            this.picBox_tree.Margin = new System.Windows.Forms.Padding(4);
            this.picBox_tree.Name = "picBox_tree";
            this.picBox_tree.Size = new System.Drawing.Size(397, 507);
            this.picBox_tree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_tree.TabIndex = 3;
            this.picBox_tree.TabStop = false;
            this.picBox_tree.Click += new System.EventHandler(this.PicBox_tree_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(34, 613);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 10);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(418, 103);
            this.btnPlot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(127, 39);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.Text = "plot the graph";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(417, 159);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(515, 294);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(13, 613);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 11);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbX.Location = new System.Drawing.Point(551, 100);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(129, 20);
            this.lbX.TabIndex = 0;
            this.lbX.Text = "Cursur_X value:";
            this.lbX.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbY.Location = new System.Drawing.Point(551, 122);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(128, 20);
            this.lbY.TabIndex = 7;
            this.lbY.Text = "Cursur_Y value:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(1000, 103);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 156);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // btnPicPlot
            // 
            this.btnPicPlot.Location = new System.Drawing.Point(951, 18);
            this.btnPicPlot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPicPlot.Name = "btnPicPlot";
            this.btnPicPlot.Size = new System.Drawing.Size(221, 41);
            this.btnPicPlot.TabIndex = 9;
            this.btnPicPlot.Text = "plot The graph on pictureBox";
            this.btnPicPlot.UseVisualStyleBackColor = true;
            this.btnPicPlot.Click += new System.EventHandler(this.BtnPicPlot_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1188, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "Plot Derivative";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(417, 525);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 56);
            this.trackBar1.TabIndex = 11;
            // 
            // btnIntegral
            // 
            this.btnIntegral.Location = new System.Drawing.Point(1310, 20);
            this.btnIntegral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIntegral.Name = "btnIntegral";
            this.btnIntegral.Size = new System.Drawing.Size(116, 36);
            this.btnIntegral.TabIndex = 12;
            this.btnIntegral.Text = "Plot Integral";
            this.btnIntegral.UseVisualStyleBackColor = true;
            this.btnIntegral.Click += new System.EventHandler(this.BtnIntegral_Click);
            // 
            // btnPolynomial
            // 
            this.btnPolynomial.Location = new System.Drawing.Point(418, 459);
            this.btnPolynomial.Margin = new System.Windows.Forms.Padding(4);
            this.btnPolynomial.Name = "btnPolynomial";
            this.btnPolynomial.Size = new System.Drawing.Size(140, 37);
            this.btnPolynomial.TabIndex = 13;
            this.btnPolynomial.Text = "Polynomial";
            this.btnPolynomial.UseVisualStyleBackColor = true;
            this.btnPolynomial.Click += new System.EventHandler(this.BtnPolynomial_Click);
            // 
            // btnMCLaurin
            // 
            this.btnMCLaurin.Location = new System.Drawing.Point(582, 459);
            this.btnMCLaurin.Margin = new System.Windows.Forms.Padding(4);
            this.btnMCLaurin.Name = "btnMCLaurin";
            this.btnMCLaurin.Size = new System.Drawing.Size(140, 37);
            this.btnMCLaurin.TabIndex = 14;
            this.btnMCLaurin.Text = "McLaurin Series";
            this.btnMCLaurin.UseVisualStyleBackColor = true;
            this.btnMCLaurin.Click += new System.EventHandler(this.BtnMCLaurin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1871, 954);
            this.Controls.Add(this.btnMCLaurin);
            this.Controls.Add(this.btnPolynomial);
            this.Controls.Add(this.btnIntegral);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPicPlot);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.lbX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picBox_tree);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbParse);
            this.Controls.Add(this.btnPars);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPars;
        private System.Windows.Forms.TextBox tbParse;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.PictureBox picBox_tree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPicPlot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnIntegral;
        private System.Windows.Forms.Button btnPolynomial;
        private System.Windows.Forms.Button btnMCLaurin;
    }
}

