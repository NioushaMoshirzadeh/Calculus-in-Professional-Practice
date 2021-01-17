namespace SudokuBrain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnSample1 = new System.Windows.Forms.Button();
            this.btnSample2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb11
            // 
            this.tb11.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tb11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb11.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb11.ForeColor = System.Drawing.Color.Black;
            this.tb11.Location = new System.Drawing.Point(12, 13);
            this.tb11.Multiline = true;
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(263, 233);
            this.tb11.TabIndex = 0;
            this.tb11.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(76, 273);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(115, 41);
            this.btnSolve.TabIndex = 81;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.BtnSolve_Click);
            // 
            // btnSample1
            // 
            this.btnSample1.Location = new System.Drawing.Point(302, 13);
            this.btnSample1.Name = "btnSample1";
            this.btnSample1.Size = new System.Drawing.Size(115, 41);
            this.btnSample1.TabIndex = 82;
            this.btnSample1.Text = "Sample1";
            this.btnSample1.UseVisualStyleBackColor = true;
            this.btnSample1.Click += new System.EventHandler(this.BtnSample1_Click);
            // 
            // btnSample2
            // 
            this.btnSample2.Location = new System.Drawing.Point(302, 60);
            this.btnSample2.Name = "btnSample2";
            this.btnSample2.Size = new System.Drawing.Size(115, 41);
            this.btnSample2.TabIndex = 84;
            this.btnSample2.Text = "Sample2";
            this.btnSample2.UseVisualStyleBackColor = true;
            this.btnSample2.Click += new System.EventHandler(this.BtnSample2_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(29, 320);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1190, 300);
            this.chart1.TabIndex = 85;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 676);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnSample2);
            this.Controls.Add(this.btnSample1);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.tb11);
            this.Name = "Form1";
            this.Text = "SudokuBrain";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb11;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnSample1;
        private System.Windows.Forms.Button btnSample2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

