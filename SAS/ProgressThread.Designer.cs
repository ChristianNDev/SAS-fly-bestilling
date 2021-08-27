namespace SAS
{
    partial class ProgressThread
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
            this.progressData = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressData
            // 
            this.progressData.AutoSize = true;
            this.progressData.Location = new System.Drawing.Point(102, 22);
            this.progressData.Name = "progressData";
            this.progressData.Size = new System.Drawing.Size(151, 13);
            this.progressData.TabIndex = 2;
            this.progressData.Text = "Vent venligst. Indlæser data....";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(298, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.progCancel);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 128);
            this.panel1.TabIndex = 4;
            // 
            // progCancel
            // 
            this.progCancel.Location = new System.Drawing.Point(244, 87);
            this.progCancel.Name = "progCancel";
            this.progCancel.Size = new System.Drawing.Size(75, 23);
            this.progCancel.TabIndex = 0;
            this.progCancel.Text = "Anullere";
            this.progCancel.UseVisualStyleBackColor = true;
            this.progCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgressThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(336, 129);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressData);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressThread";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProgressThread";
            this.Load += new System.EventHandler(this.ProgressThread_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label progressData;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button progCancel;
    }
}