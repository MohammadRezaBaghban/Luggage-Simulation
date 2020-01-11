namespace Rail_Bag_Simulation
{
    partial class Map
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
            this.RbConveyor = new System.Windows.Forms.RadioButton();
            this.RbGate = new System.Windows.Forms.RadioButton();
            this.RbTerminal = new System.Windows.Forms.RadioButton();
            this.RbSorter = new System.Windows.Forms.RadioButton();
            this.RbSecurity = new System.Windows.Forms.RadioButton();
            this.RbCheckIn = new System.Windows.Forms.RadioButton();
            this.BtnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RbConveyor
            // 
            this.RbConveyor.AutoSize = true;
            this.RbConveyor.Location = new System.Drawing.Point(12, 168);
            this.RbConveyor.Name = "RbConveyor";
            this.RbConveyor.Size = new System.Drawing.Size(89, 21);
            this.RbConveyor.TabIndex = 11;
            this.RbConveyor.TabStop = true;
            this.RbConveyor.Text = "Conveyor";
            this.RbConveyor.UseVisualStyleBackColor = true;
            // 
            // RbGate
            // 
            this.RbGate.AutoSize = true;
            this.RbGate.Location = new System.Drawing.Point(12, 141);
            this.RbGate.Name = "RbGate";
            this.RbGate.Size = new System.Drawing.Size(60, 21);
            this.RbGate.TabIndex = 10;
            this.RbGate.TabStop = true;
            this.RbGate.Text = "Gate";
            this.RbGate.UseVisualStyleBackColor = true;
            // 
            // RbTerminal
            // 
            this.RbTerminal.AutoSize = true;
            this.RbTerminal.Location = new System.Drawing.Point(12, 114);
            this.RbTerminal.Name = "RbTerminal";
            this.RbTerminal.Size = new System.Drawing.Size(84, 21);
            this.RbTerminal.TabIndex = 9;
            this.RbTerminal.TabStop = true;
            this.RbTerminal.Text = "Terminal";
            this.RbTerminal.UseVisualStyleBackColor = true;
            // 
            // RbSorter
            // 
            this.RbSorter.AutoSize = true;
            this.RbSorter.Location = new System.Drawing.Point(12, 87);
            this.RbSorter.Name = "RbSorter";
            this.RbSorter.Size = new System.Drawing.Size(68, 21);
            this.RbSorter.TabIndex = 8;
            this.RbSorter.TabStop = true;
            this.RbSorter.Text = "Sorter";
            this.RbSorter.UseVisualStyleBackColor = true;
            // 
            // RbSecurity
            // 
            this.RbSecurity.AutoSize = true;
            this.RbSecurity.Location = new System.Drawing.Point(12, 60);
            this.RbSecurity.Name = "RbSecurity";
            this.RbSecurity.Size = new System.Drawing.Size(80, 21);
            this.RbSecurity.TabIndex = 7;
            this.RbSecurity.TabStop = true;
            this.RbSecurity.Text = "Security";
            this.RbSecurity.UseVisualStyleBackColor = true;
            // 
            // RbCheckIn
            // 
            this.RbCheckIn.AutoSize = true;
            this.RbCheckIn.Location = new System.Drawing.Point(12, 33);
            this.RbCheckIn.Name = "RbCheckIn";
            this.RbCheckIn.Size = new System.Drawing.Size(83, 21);
            this.RbCheckIn.TabIndex = 6;
            this.RbCheckIn.TabStop = true;
            this.RbCheckIn.Text = "Check in";
            this.RbCheckIn.UseVisualStyleBackColor = true;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(30, 516);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(138, 50);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 609);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.RbConveyor);
            this.Controls.Add(this.RbGate);
            this.Controls.Add(this.RbTerminal);
            this.Controls.Add(this.RbSorter);
            this.Controls.Add(this.RbSecurity);
            this.Controls.Add(this.RbCheckIn);
            this.Name = "Map";
            this.Text = "Map";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Map_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbConveyor;
        private System.Windows.Forms.RadioButton RbGate;
        private System.Windows.Forms.RadioButton RbTerminal;
        private System.Windows.Forms.RadioButton RbSorter;
        private System.Windows.Forms.RadioButton RbSecurity;
        private System.Windows.Forms.RadioButton RbCheckIn;
        private System.Windows.Forms.Button BtnStart;
    }
}