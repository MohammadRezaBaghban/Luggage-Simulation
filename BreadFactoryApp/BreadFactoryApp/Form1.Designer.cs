namespace BreadFactoryApp
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
            this.tbToBeManufactured = new System.Windows.Forms.TextBox();
            this.btnManufacture = new System.Windows.Forms.Button();
            this.lbLogger = new System.Windows.Forms.ListBox();
            this.lbFlourUpdates = new System.Windows.Forms.ListBox();
            this.lbPackagingUpdates = new System.Windows.Forms.ListBox();
            this.lbLabelingUpdates = new System.Windows.Forms.ListBox();
            this.btnStopManufacture = new System.Windows.Forms.Button();
            this.lbNbrOfLoafToBeMade = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbBrownBread
            // 
            this.rbBrownBread.AutoSize = true;
            this.rbBrownBread.Location = new System.Drawing.Point(26, 46);
            this.rbBrownBread.Margin = new System.Windows.Forms.Padding(2);
            this.rbBrownBread.Name = "rbBrownBread";
            this.rbBrownBread.Size = new System.Drawing.Size(89, 17);
            this.rbBrownBread.TabIndex = 0;
            this.rbBrownBread.TabStop = true;
            this.rbBrownBread.Text = "Brown Bread ";
            this.rbBrownBread.UseVisualStyleBackColor = true;
            // 
            // rbWhiteBread
            // 
            this.rbWhiteBread.AutoSize = true;
            this.rbWhiteBread.Location = new System.Drawing.Point(26, 92);
            this.rbWhiteBread.Margin = new System.Windows.Forms.Padding(2);
            this.rbWhiteBread.Name = "rbWhiteBread";
            this.rbWhiteBread.Size = new System.Drawing.Size(87, 17);
            this.rbWhiteBread.TabIndex = 1;
            this.rbWhiteBread.TabStop = true;
            this.rbWhiteBread.Text = "White Bread ";
            this.rbWhiteBread.UseVisualStyleBackColor = true;
            // 
            // tbToBeManufactured
            // 
            this.tbToBeManufactured.Location = new System.Drawing.Point(22, 154);
            this.tbToBeManufactured.Margin = new System.Windows.Forms.Padding(2);
            this.tbToBeManufactured.Name = "tbToBeManufactured";
            this.tbToBeManufactured.Size = new System.Drawing.Size(180, 20);
            this.tbToBeManufactured.TabIndex = 2;
            // 
            // btnManufacture
            // 
            this.btnManufacture.Location = new System.Drawing.Point(11, 196);
            this.btnManufacture.Margin = new System.Windows.Forms.Padding(2);
            this.btnManufacture.Name = "btnManufacture";
            this.btnManufacture.Size = new System.Drawing.Size(88, 47);
            this.btnManufacture.TabIndex = 3;
            this.btnManufacture.Text = "Manufacture";
            this.btnManufacture.UseVisualStyleBackColor = true;
            this.btnManufacture.Click += new System.EventHandler(this.btnManufacture_Click);
            // 
            // lbLogger
            // 
            this.lbLogger.FormattingEnabled = true;
            this.lbLogger.Location = new System.Drawing.Point(216, 32);
            this.lbLogger.Margin = new System.Windows.Forms.Padding(2);
            this.lbLogger.Name = "lbLogger";
            this.lbLogger.Size = new System.Drawing.Size(362, 433);
            this.lbLogger.TabIndex = 4;
            // 
            // lbFlourUpdates
            // 
            this.lbFlourUpdates.FormattingEnabled = true;
            this.lbFlourUpdates.Location = new System.Drawing.Point(582, 32);
            this.lbFlourUpdates.Margin = new System.Windows.Forms.Padding(2);
            this.lbFlourUpdates.Name = "lbFlourUpdates";
            this.lbFlourUpdates.Size = new System.Drawing.Size(239, 121);
            this.lbFlourUpdates.TabIndex = 5;
            // 
            // lbPackagingUpdates
            // 
            this.lbPackagingUpdates.FormattingEnabled = true;
            this.lbPackagingUpdates.Location = new System.Drawing.Point(582, 177);
            this.lbPackagingUpdates.Margin = new System.Windows.Forms.Padding(2);
            this.lbPackagingUpdates.Name = "lbPackagingUpdates";
            this.lbPackagingUpdates.Size = new System.Drawing.Size(239, 134);
            this.lbPackagingUpdates.TabIndex = 6;
            // 
            // lbLabelingUpdates
            // 
            this.lbLabelingUpdates.FormattingEnabled = true;
            this.lbLabelingUpdates.Location = new System.Drawing.Point(582, 331);
            this.lbLabelingUpdates.Margin = new System.Windows.Forms.Padding(2);
            this.lbLabelingUpdates.Name = "lbLabelingUpdates";
            this.lbLabelingUpdates.Size = new System.Drawing.Size(239, 134);
            this.lbLabelingUpdates.TabIndex = 7;
            // 
            // btnStopManufacture
            // 
            this.btnStopManufacture.Location = new System.Drawing.Point(113, 196);
            this.btnStopManufacture.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopManufacture.Name = "btnStopManufacture";
            this.btnStopManufacture.Size = new System.Drawing.Size(88, 47);
            this.btnStopManufacture.TabIndex = 8;
            this.btnStopManufacture.Text = "Stop Manufacture";
            this.btnStopManufacture.UseVisualStyleBackColor = true;
            this.btnStopManufacture.Click += new System.EventHandler(this.btnStopManufacture_Click);
            // 
            // lbNbrOfLoafToBeMade
            // 
            this.lbNbrOfLoafToBeMade.AutoSize = true;
            this.lbNbrOfLoafToBeMade.Location = new System.Drawing.Point(20, 138);
            this.lbNbrOfLoafToBeMade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNbrOfLoafToBeMade.Name = "lbNbrOfLoafToBeMade";
            this.lbNbrOfLoafToBeMade.Size = new System.Drawing.Size(117, 13);
            this.lbNbrOfLoafToBeMade.TabIndex = 9;
            this.lbNbrOfLoafToBeMade.Text = "Nbr of loafs to be made";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loafs Done";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Flours Cooked";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Packages Done";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Labels Printted";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 472);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNbrOfLoafToBeMade);
            this.Controls.Add(this.btnStopManufacture);
            this.Controls.Add(this.lbLabelingUpdates);
            this.Controls.Add(this.lbPackagingUpdates);
            this.Controls.Add(this.lbFlourUpdates);
            this.Controls.Add(this.lbLogger);
            this.Controls.Add(this.btnManufacture);
            this.Controls.Add(this.tbToBeManufactured);
            this.Controls.Add(this.rbWhiteBread);
            this.Controls.Add(this.rbBrownBread);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBrownBread;
        private System.Windows.Forms.RadioButton rbWhiteBread;
        private System.Windows.Forms.TextBox tbToBeManufactured;
        private System.Windows.Forms.Button btnManufacture;
        private System.Windows.Forms.ListBox lbLogger;
        private System.Windows.Forms.ListBox lbFlourUpdates;
        private System.Windows.Forms.ListBox lbPackagingUpdates;
        private System.Windows.Forms.ListBox lbLabelingUpdates;
        private System.Windows.Forms.Button btnStopManufacture;
        private System.Windows.Forms.Label lbNbrOfLoafToBeMade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

