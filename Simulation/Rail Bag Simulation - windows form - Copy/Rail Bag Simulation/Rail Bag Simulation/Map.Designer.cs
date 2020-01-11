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
            this.LblTotalBags = new System.Windows.Forms.Label();
            this.LblCarts = new System.Windows.Forms.Label();
            this.LblFlammables = new System.Windows.Forms.Label();
            this.LblWeapons = new System.Windows.Forms.Label();
            this.LblDrugs = new System.Windows.Forms.Label();
            this.LblOthers = new System.Windows.Forms.Label();
            this.TbTotalBags = new System.Windows.Forms.TextBox();
            this.TbCarts = new System.Windows.Forms.TextBox();
            this.TbFlammables = new System.Windows.Forms.TextBox();
            this.TbWeapons = new System.Windows.Forms.TextBox();
            this.TbDrugs = new System.Windows.Forms.TextBox();
            this.TbOthers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.BtnStart.Location = new System.Drawing.Point(59, 519);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(138, 50);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblTotalBags
            // 
            this.LblTotalBags.AutoSize = true;
            this.LblTotalBags.Location = new System.Drawing.Point(26, 240);
            this.LblTotalBags.Name = "LblTotalBags";
            this.LblTotalBags.Size = new System.Drawing.Size(74, 17);
            this.LblTotalBags.TabIndex = 13;
            this.LblTotalBags.Text = "Nr of bags";
            // 
            // LblCarts
            // 
            this.LblCarts.AutoSize = true;
            this.LblCarts.Location = new System.Drawing.Point(26, 274);
            this.LblCarts.Name = "LblCarts";
            this.LblCarts.Size = new System.Drawing.Size(41, 17);
            this.LblCarts.TabIndex = 14;
            this.LblCarts.Text = "Carts";
            // 
            // LblFlammables
            // 
            this.LblFlammables.AutoSize = true;
            this.LblFlammables.Location = new System.Drawing.Point(26, 360);
            this.LblFlammables.Name = "LblFlammables";
            this.LblFlammables.Size = new System.Drawing.Size(83, 17);
            this.LblFlammables.TabIndex = 15;
            this.LblFlammables.Text = "Flammables";
            // 
            // LblWeapons
            // 
            this.LblWeapons.AutoSize = true;
            this.LblWeapons.Location = new System.Drawing.Point(26, 388);
            this.LblWeapons.Name = "LblWeapons";
            this.LblWeapons.Size = new System.Drawing.Size(68, 17);
            this.LblWeapons.TabIndex = 16;
            this.LblWeapons.Text = "Weapons";
            // 
            // LblDrugs
            // 
            this.LblDrugs.AutoSize = true;
            this.LblDrugs.Location = new System.Drawing.Point(26, 418);
            this.LblDrugs.Name = "LblDrugs";
            this.LblDrugs.Size = new System.Drawing.Size(46, 17);
            this.LblDrugs.TabIndex = 17;
            this.LblDrugs.Text = "Drugs";
            // 
            // LblOthers
            // 
            this.LblOthers.AutoSize = true;
            this.LblOthers.Location = new System.Drawing.Point(26, 449);
            this.LblOthers.Name = "LblOthers";
            this.LblOthers.Size = new System.Drawing.Size(51, 17);
            this.LblOthers.TabIndex = 18;
            this.LblOthers.Text = "Others";
            // 
            // TbTotalBags
            // 
            this.TbTotalBags.Location = new System.Drawing.Point(130, 240);
            this.TbTotalBags.Name = "TbTotalBags";
            this.TbTotalBags.Size = new System.Drawing.Size(100, 22);
            this.TbTotalBags.TabIndex = 19;
            // 
            // TbCarts
            // 
            this.TbCarts.Location = new System.Drawing.Point(130, 274);
            this.TbCarts.Name = "TbCarts";
            this.TbCarts.Size = new System.Drawing.Size(100, 22);
            this.TbCarts.TabIndex = 20;
            // 
            // TbFlammables
            // 
            this.TbFlammables.Location = new System.Drawing.Point(130, 357);
            this.TbFlammables.Name = "TbFlammables";
            this.TbFlammables.Size = new System.Drawing.Size(100, 22);
            this.TbFlammables.TabIndex = 21;
            // 
            // TbWeapons
            // 
            this.TbWeapons.Location = new System.Drawing.Point(130, 388);
            this.TbWeapons.Name = "TbWeapons";
            this.TbWeapons.Size = new System.Drawing.Size(100, 22);
            this.TbWeapons.TabIndex = 22;
            // 
            // TbDrugs
            // 
            this.TbDrugs.Location = new System.Drawing.Point(130, 416);
            this.TbDrugs.Name = "TbDrugs";
            this.TbDrugs.Size = new System.Drawing.Size(100, 22);
            this.TbDrugs.TabIndex = 23;
            // 
            // TbOthers
            // 
            this.TbOthers.Location = new System.Drawing.Point(130, 446);
            this.TbOthers.Name = "TbOthers";
            this.TbOthers.Size = new System.Drawing.Size(100, 22);
            this.TbOthers.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 576);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1550, 609);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbOthers);
            this.Controls.Add(this.TbDrugs);
            this.Controls.Add(this.TbWeapons);
            this.Controls.Add(this.TbFlammables);
            this.Controls.Add(this.TbCarts);
            this.Controls.Add(this.TbTotalBags);
            this.Controls.Add(this.LblOthers);
            this.Controls.Add(this.LblDrugs);
            this.Controls.Add(this.LblWeapons);
            this.Controls.Add(this.LblFlammables);
            this.Controls.Add(this.LblCarts);
            this.Controls.Add(this.LblTotalBags);
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
        private System.Windows.Forms.Label LblTotalBags;
        private System.Windows.Forms.Label LblCarts;
        private System.Windows.Forms.Label LblFlammables;
        private System.Windows.Forms.Label LblWeapons;
        private System.Windows.Forms.Label LblDrugs;
        private System.Windows.Forms.Label LblOthers;
        private System.Windows.Forms.TextBox TbTotalBags;
        private System.Windows.Forms.TextBox TbCarts;
        private System.Windows.Forms.TextBox TbFlammables;
        private System.Windows.Forms.TextBox TbWeapons;
        private System.Windows.Forms.TextBox TbDrugs;
        private System.Windows.Forms.TextBox TbOthers;
        private System.Windows.Forms.Label label1;
    }
}