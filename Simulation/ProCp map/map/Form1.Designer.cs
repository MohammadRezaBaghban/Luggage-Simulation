namespace map
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
            this.BtnGenerateMap = new System.Windows.Forms.Button();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.RbCheckIn = new System.Windows.Forms.RadioButton();
            this.RbConveyor = new System.Windows.Forms.RadioButton();
            this.RbSecurity = new System.Windows.Forms.RadioButton();
            this.RbTerminal = new System.Windows.Forms.RadioButton();
            this.RbGate = new System.Windows.Forms.RadioButton();
            this.NudGridSize = new System.Windows.Forms.NumericUpDown();
            this.RbEmpty = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGridSize)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGenerateMap
            // 
            this.BtnGenerateMap.Location = new System.Drawing.Point(12, 12);
            this.BtnGenerateMap.Name = "BtnGenerateMap";
            this.BtnGenerateMap.Size = new System.Drawing.Size(117, 39);
            this.BtnGenerateMap.TabIndex = 0;
            this.BtnGenerateMap.Text = "Generate map";
            this.BtnGenerateMap.UseVisualStyleBackColor = true;
            this.BtnGenerateMap.Click += new System.EventHandler(this.BtnGenerateMap_Click);
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AllowUserToResizeColumns = false;
            this.gridView.AllowUserToResizeRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.ColumnHeadersVisible = false;
            this.gridView.Location = new System.Drawing.Point(177, 12);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowHeadersWidth = 51;
            this.gridView.RowTemplate.Height = 24;
            this.gridView.Size = new System.Drawing.Size(588, 588);
            this.gridView.TabIndex = 1;
            this.gridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellClick);
            // 
            // RbCheckIn
            // 
            this.RbCheckIn.AutoSize = true;
            this.RbCheckIn.Location = new System.Drawing.Point(19, 208);
            this.RbCheckIn.Name = "RbCheckIn";
            this.RbCheckIn.Size = new System.Drawing.Size(83, 21);
            this.RbCheckIn.TabIndex = 2;
            this.RbCheckIn.TabStop = true;
            this.RbCheckIn.Text = "Check in";
            this.RbCheckIn.UseVisualStyleBackColor = true;
            this.RbCheckIn.CheckedChanged += new System.EventHandler(this.RbCheckIn_CheckedChanged);
            // 
            // RbConveyor
            // 
            this.RbConveyor.AutoSize = true;
            this.RbConveyor.Location = new System.Drawing.Point(19, 316);
            this.RbConveyor.Name = "RbConveyor";
            this.RbConveyor.Size = new System.Drawing.Size(89, 21);
            this.RbConveyor.TabIndex = 3;
            this.RbConveyor.TabStop = true;
            this.RbConveyor.Text = "Conveyor";
            this.RbConveyor.UseVisualStyleBackColor = true;
            this.RbConveyor.CheckedChanged += new System.EventHandler(this.RbConveyor_CheckedChanged);
            // 
            // RbSecurity
            // 
            this.RbSecurity.AutoSize = true;
            this.RbSecurity.Location = new System.Drawing.Point(19, 235);
            this.RbSecurity.Name = "RbSecurity";
            this.RbSecurity.Size = new System.Drawing.Size(80, 21);
            this.RbSecurity.TabIndex = 4;
            this.RbSecurity.TabStop = true;
            this.RbSecurity.Text = "Security";
            this.RbSecurity.UseVisualStyleBackColor = true;
            this.RbSecurity.CheckedChanged += new System.EventHandler(this.RbSecurity_CheckedChanged);
            // 
            // RbTerminal
            // 
            this.RbTerminal.AutoSize = true;
            this.RbTerminal.Location = new System.Drawing.Point(19, 262);
            this.RbTerminal.Name = "RbTerminal";
            this.RbTerminal.Size = new System.Drawing.Size(84, 21);
            this.RbTerminal.TabIndex = 5;
            this.RbTerminal.TabStop = true;
            this.RbTerminal.Text = "Terminal";
            this.RbTerminal.UseVisualStyleBackColor = true;
            this.RbTerminal.CheckedChanged += new System.EventHandler(this.RbTerminal_CheckedChanged);
            // 
            // RbGate
            // 
            this.RbGate.AutoSize = true;
            this.RbGate.Location = new System.Drawing.Point(19, 289);
            this.RbGate.Name = "RbGate";
            this.RbGate.Size = new System.Drawing.Size(60, 21);
            this.RbGate.TabIndex = 6;
            this.RbGate.TabStop = true;
            this.RbGate.Text = "Gate";
            this.RbGate.UseVisualStyleBackColor = true;
            this.RbGate.CheckedChanged += new System.EventHandler(this.RbGate_CheckedChanged);
            // 
            // NudGridSize
            // 
            this.NudGridSize.Location = new System.Drawing.Point(12, 71);
            this.NudGridSize.Name = "NudGridSize";
            this.NudGridSize.Size = new System.Drawing.Size(120, 22);
            this.NudGridSize.TabIndex = 7;
            // 
            // RbEmpty
            // 
            this.RbEmpty.AutoSize = true;
            this.RbEmpty.Location = new System.Drawing.Point(19, 343);
            this.RbEmpty.Name = "RbEmpty";
            this.RbEmpty.Size = new System.Drawing.Size(68, 21);
            this.RbEmpty.TabIndex = 8;
            this.RbEmpty.TabStop = true;
            this.RbEmpty.Text = "Empty";
            this.RbEmpty.UseVisualStyleBackColor = true;
            this.RbEmpty.CheckedChanged += new System.EventHandler(this.RbEmpty_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 612);
            this.Controls.Add(this.RbEmpty);
            this.Controls.Add(this.NudGridSize);
            this.Controls.Add(this.RbGate);
            this.Controls.Add(this.RbTerminal);
            this.Controls.Add(this.RbSecurity);
            this.Controls.Add(this.RbConveyor);
            this.Controls.Add(this.RbCheckIn);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.BtnGenerateMap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGridSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGenerateMap;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.RadioButton RbCheckIn;
        private System.Windows.Forms.RadioButton RbConveyor;
        private System.Windows.Forms.RadioButton RbSecurity;
        private System.Windows.Forms.RadioButton RbTerminal;
        private System.Windows.Forms.RadioButton RbGate;
        private System.Windows.Forms.NumericUpDown NudGridSize;
        private System.Windows.Forms.RadioButton RbEmpty;
    }
}

