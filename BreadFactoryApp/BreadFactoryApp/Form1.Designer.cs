﻿namespace BreadFactoryApp
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
            this.rbBrownBread = new System.Windows.Forms.RadioButton();
            this.rbWhiteBread = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnManufacture = new System.Windows.Forms.Button();
            this.lbLogger = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rbBrownBread
            // 
            this.rbBrownBread.AutoSize = true;
            this.rbBrownBread.Location = new System.Drawing.Point(53, 88);
            this.rbBrownBread.Name = "rbBrownBread";
            this.rbBrownBread.Size = new System.Drawing.Size(172, 29);
            this.rbBrownBread.TabIndex = 0;
            this.rbBrownBread.TabStop = true;
            this.rbBrownBread.Text = "Brown Bread ";
            this.rbBrownBread.UseVisualStyleBackColor = true;
            // 
            // rbWhiteBread
            // 
            this.rbWhiteBread.AutoSize = true;
            this.rbWhiteBread.Location = new System.Drawing.Point(53, 176);
            this.rbWhiteBread.Name = "rbWhiteBread";
            this.rbWhiteBread.Size = new System.Drawing.Size(167, 29);
            this.rbWhiteBread.TabIndex = 1;
            this.rbWhiteBread.TabStop = true;
            this.rbWhiteBread.Text = "White Bread ";
            this.rbWhiteBread.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 264);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 31);
            this.textBox1.TabIndex = 2;
            // 
            // btnManufacture
            // 
            this.btnManufacture.Location = new System.Drawing.Point(209, 324);
            this.btnManufacture.Name = "btnManufacture";
            this.btnManufacture.Size = new System.Drawing.Size(175, 62);
            this.btnManufacture.TabIndex = 3;
            this.btnManufacture.Text = "Manufacture";
            this.btnManufacture.UseVisualStyleBackColor = true;
            // 
            // lbLogger
            // 
            this.lbLogger.FormattingEnabled = true;
            this.lbLogger.ItemHeight = 25;
            this.lbLogger.Location = new System.Drawing.Point(563, 14);
            this.lbLogger.Name = "lbLogger";
            this.lbLogger.Size = new System.Drawing.Size(1080, 854);
            this.lbLogger.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 908);
            this.Controls.Add(this.lbLogger);
            this.Controls.Add(this.btnManufacture);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rbWhiteBread);
            this.Controls.Add(this.rbBrownBread);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBrownBread;
        private System.Windows.Forms.RadioButton rbWhiteBread;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnManufacture;
        private System.Windows.Forms.ListBox lbLogger;
    }
}

