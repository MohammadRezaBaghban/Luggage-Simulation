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
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridDestinationSuspicousBagsCategory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDestinationSuspicousBagsCategory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(12, 34);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(700, 406);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Text = "pieChart1";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(1165, 771);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(408, 68);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1506, 175);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(528, 503);
            this.dataGridView1.TabIndex = 3;
            // 
            // dataGridDestinationSuspicousBagsCategory
            // 
            this.dataGridDestinationSuspicousBagsCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDestinationSuspicousBagsCategory.Location = new System.Drawing.Point(812, 175);
            this.dataGridDestinationSuspicousBagsCategory.Name = "dataGridDestinationSuspicousBagsCategory";
            this.dataGridDestinationSuspicousBagsCategory.RowHeadersWidth = 82;
            this.dataGridDestinationSuspicousBagsCategory.RowTemplate.Height = 33;
            this.dataGridDestinationSuspicousBagsCategory.Size = new System.Drawing.Size(543, 503);
            this.dataGridDestinationSuspicousBagsCategory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(806, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Suspicious Bags Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1500, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(420, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time Taken To Reach Gate Per Second";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pieChart2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 605);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 457);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distribution of Bag Per Destination";
            // 
            // pieChart2
            // 
            this.pieChart2.Location = new System.Drawing.Point(-9, 25);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(700, 406);
            this.pieChart2.TabIndex = 9;
            this.pieChart2.Text = "pieChart2";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridDestinationSuspicousBagsCategory);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.pieChart1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Statistics";
            this.Size = new System.Drawing.Size(2052, 951);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDestinationSuspicousBagsCategory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridDestinationSuspicousBagsCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private LiveCharts.WinForms.PieChart pieChart2;
    }
}
