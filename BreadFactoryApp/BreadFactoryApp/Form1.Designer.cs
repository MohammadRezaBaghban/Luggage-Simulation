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
            // tbToBeManufactured
            // 
            this.tbToBeManufactured.Location = new System.Drawing.Point(45, 296);
            this.tbToBeManufactured.Name = "tbToBeManufactured";
            this.tbToBeManufactured.Size = new System.Drawing.Size(356, 31);
            this.tbToBeManufactured.TabIndex = 2;
            // 
            // btnManufacture
            // 
            this.btnManufacture.Location = new System.Drawing.Point(45, 376);
            this.btnManufacture.Name = "btnManufacture";
            this.btnManufacture.Size = new System.Drawing.Size(175, 62);
            this.btnManufacture.TabIndex = 3;
            this.btnManufacture.Text = "Manufacture";
            this.btnManufacture.UseVisualStyleBackColor = true;
            this.btnManufacture.Click += new System.EventHandler(this.btnManufacture_Click);
            // 
            // lbLogger
            // 
            this.lbLogger.FormattingEnabled = true;
            this.lbLogger.ItemHeight = 25;
            this.lbLogger.Location = new System.Drawing.Point(433, 12);
            this.lbLogger.Name = "lbLogger";
            this.lbLogger.Size = new System.Drawing.Size(456, 879);
            this.lbLogger.TabIndex = 4;
            // 
            // lbFlourUpdates
            // 
            this.lbFlourUpdates.FormattingEnabled = true;
            this.lbFlourUpdates.ItemHeight = 25;
            this.lbFlourUpdates.Location = new System.Drawing.Point(905, 12);
            this.lbFlourUpdates.Name = "lbFlourUpdates";
            this.lbFlourUpdates.Size = new System.Drawing.Size(474, 279);
            this.lbFlourUpdates.TabIndex = 5;
            // 
            // lbPackagingUpdates
            // 
            this.lbPackagingUpdates.FormattingEnabled = true;
            this.lbPackagingUpdates.ItemHeight = 25;
            this.lbPackagingUpdates.Location = new System.Drawing.Point(905, 315);
            this.lbPackagingUpdates.Name = "lbPackagingUpdates";
            this.lbPackagingUpdates.Size = new System.Drawing.Size(474, 279);
            this.lbPackagingUpdates.TabIndex = 6;
            // 
            // lbLabelingUpdates
            // 
            this.lbLabelingUpdates.FormattingEnabled = true;
            this.lbLabelingUpdates.ItemHeight = 25;
            this.lbLabelingUpdates.Location = new System.Drawing.Point(905, 612);
            this.lbLabelingUpdates.Name = "lbLabelingUpdates";
            this.lbLabelingUpdates.Size = new System.Drawing.Size(474, 279);
            this.lbLabelingUpdates.TabIndex = 7;
            // 
            // btnStopManufacture
            // 
            this.btnStopManufacture.Location = new System.Drawing.Point(226, 376);
            this.btnStopManufacture.Name = "btnStopManufacture";
            this.btnStopManufacture.Size = new System.Drawing.Size(175, 62);
            this.btnStopManufacture.TabIndex = 8;
            this.btnStopManufacture.Text = "Stop Manufacture";
            this.btnStopManufacture.UseVisualStyleBackColor = true;
            // 
            // lbNbrOfLoafToBeMade
            // 
            this.lbNbrOfLoafToBeMade.AutoSize = true;
            this.lbNbrOfLoafToBeMade.Location = new System.Drawing.Point(40, 266);
            this.lbNbrOfLoafToBeMade.Name = "lbNbrOfLoafToBeMade";
            this.lbNbrOfLoafToBeMade.Size = new System.Drawing.Size(235, 25);
            this.lbNbrOfLoafToBeMade.TabIndex = 9;
            this.lbNbrOfLoafToBeMade.Text = "Nbr of loafs to be made";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 908);
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
    }
}

