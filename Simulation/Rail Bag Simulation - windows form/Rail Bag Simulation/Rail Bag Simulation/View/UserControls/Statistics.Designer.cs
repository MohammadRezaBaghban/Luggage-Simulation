namespace Rail_Bag_Simulation.View.UserControls
{
    partial class Statistics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDestinationSuspiciousBagsCategory = new System.Windows.Forms.Button();
            this.dataGridDestinationSuspicousBagsCategory = new System.Windows.Forms.DataGridView();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDestinationSuspicousBagsCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statistics";
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(2, 30);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(467, 264);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Text = "pieChart1";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(767, 440);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(222, 84);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(985, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(352, 327);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnDestinationSuspiciousBagsCategory
            // 
            this.btnDestinationSuspiciousBagsCategory.BackColor = System.Drawing.Color.White;
            this.btnDestinationSuspiciousBagsCategory.Location = new System.Drawing.Point(473, 332);
            this.btnDestinationSuspiciousBagsCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDestinationSuspiciousBagsCategory.Name = "btnDestinationSuspiciousBagsCategory";
            this.btnDestinationSuspiciousBagsCategory.Size = new System.Drawing.Size(82, 25);
            this.btnDestinationSuspiciousBagsCategory.TabIndex = 4;
            this.btnDestinationSuspiciousBagsCategory.Text = "More ...";
            this.btnDestinationSuspiciousBagsCategory.UseVisualStyleBackColor = false;
            this.btnDestinationSuspiciousBagsCategory.Click += new System.EventHandler(this.btnDestinationSuspiciousBagsCategory_Click);
            // 
            // dataGridDestinationSuspicousBagsCategory
            // 
            this.dataGridDestinationSuspicousBagsCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDestinationSuspicousBagsCategory.Location = new System.Drawing.Point(612, 30);
            this.dataGridDestinationSuspicousBagsCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridDestinationSuspicousBagsCategory.Name = "dataGridDestinationSuspicousBagsCategory";
            this.dataGridDestinationSuspicousBagsCategory.RowHeadersWidth = 82;
            this.dataGridDestinationSuspicousBagsCategory.RowTemplate.Height = 33;
            this.dataGridDestinationSuspicousBagsCategory.Size = new System.Drawing.Size(362, 327);
            this.dataGridDestinationSuspicousBagsCategory.TabIndex = 5;
            this.dataGridDestinationSuspicousBagsCategory.Visible = false;
            // 
            // pieChart2
            // 
            this.pieChart2.Location = new System.Drawing.Point(2, 352);
            this.pieChart2.Margin = new System.Windows.Forms.Padding(2);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(467, 264);
            this.pieChart2.TabIndex = 6;
            this.pieChart2.Text = "pieChart2";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pieChart2);
            this.Controls.Add(this.dataGridDestinationSuspicousBagsCategory);
            this.Controls.Add(this.btnDestinationSuspiciousBagsCategory);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Statistics";
            this.Size = new System.Drawing.Size(1385, 618);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDestinationSuspicousBagsCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDestinationSuspiciousBagsCategory;
        private System.Windows.Forms.DataGridView dataGridDestinationSuspicousBagsCategory;
        private LiveCharts.WinForms.PieChart pieChart2;
    }
}
