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
            this.btnPars = new System.Windows.Forms.Button();
            this.tbParse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPars
            // 
            this.btnPars.Location = new System.Drawing.Point(71, 49);
            this.btnPars.Name = "btnPars";
            this.btnPars.Size = new System.Drawing.Size(105, 23);
            this.btnPars.TabIndex = 0;
            this.btnPars.Text = "Parse";
            this.btnPars.UseVisualStyleBackColor = true;
            this.btnPars.Click += new System.EventHandler(this.btnPars_Click);
            // 
            // tbParse
            // 
            this.tbParse.Location = new System.Drawing.Point(210, 51);
            this.tbParse.Name = "tbParse";
            this.tbParse.Size = new System.Drawing.Size(100, 20);
            this.tbParse.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 261);
            this.Controls.Add(this.tbParse);
            this.Controls.Add(this.btnPars);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPars;
        private System.Windows.Forms.TextBox tbParse;
    }
}

