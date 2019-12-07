namespace Rail_Bag_Simulation.View
{
    partial class Configurations
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
            this.btnSaveSimulation = new System.Windows.Forms.Button();
            this.tbSimulation = new System.Windows.Forms.TextBox();
            this.btnLoadSimulation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveSimulation
            // 
            this.btnSaveSimulation.Location = new System.Drawing.Point(31, 132);
            this.btnSaveSimulation.Name = "btnSaveSimulation";
            this.btnSaveSimulation.Size = new System.Drawing.Size(321, 65);
            this.btnSaveSimulation.TabIndex = 0;
            this.btnSaveSimulation.Text = "Save simulation";
            this.btnSaveSimulation.UseVisualStyleBackColor = true;
            this.btnSaveSimulation.Click += new System.EventHandler(this.btnSaveSimulation_Click);
            // 
            // tbSimulation
            // 
            this.tbSimulation.Location = new System.Drawing.Point(31, 62);
            this.tbSimulation.Name = "tbSimulation";
            this.tbSimulation.Size = new System.Drawing.Size(700, 31);
            this.tbSimulation.TabIndex = 1;
            // 
            // btnLoadSimulation
            // 
            this.btnLoadSimulation.Location = new System.Drawing.Point(410, 132);
            this.btnLoadSimulation.Name = "btnLoadSimulation";
            this.btnLoadSimulation.Size = new System.Drawing.Size(321, 65);
            this.btnLoadSimulation.TabIndex = 2;
            this.btnLoadSimulation.Text = "Load Simulation";
            this.btnLoadSimulation.UseVisualStyleBackColor = true;
            this.btnLoadSimulation.Click += new System.EventHandler(this.btnLoadSimulation_Click);
            // 
            // Configurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 522);
            this.Controls.Add(this.btnLoadSimulation);
            this.Controls.Add(this.tbSimulation);
            this.Controls.Add(this.btnSaveSimulation);
            this.Name = "Configurations";
            this.Text = "Configurations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveSimulation;
        private System.Windows.Forms.TextBox tbSimulation;
        private System.Windows.Forms.Button btnLoadSimulation;
    }
}