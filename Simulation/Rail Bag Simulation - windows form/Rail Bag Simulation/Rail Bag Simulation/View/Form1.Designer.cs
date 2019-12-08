namespace Rail_Bag_Simulation
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbStatistics = new System.Windows.Forms.PictureBox();
            this.pbSimulation = new System.Windows.Forms.PictureBox();
            this.pbConfigurations = new System.Windows.Forms.PictureBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.btnConfigurations = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_numberOfBags = new System.Windows.Forms.TextBox();
            this.tb_weapons = new System.Windows.Forms.TextBox();
            this.tb_Others = new System.Windows.Forms.TextBox();
            this.tb_flammables = new System.Windows.Forms.TextBox();
            this.tb_drugs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.palenlConfigurations = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnLoadSimulation = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelBorder1 = new System.Windows.Forms.Panel();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simulation1 = new Rail_Bag_Simulation.View.UserControls.Simulation();
            this.statistics1 = new Rail_Bag_Simulation.View.UserControls.Statistics();
            this.btnSaveSimulation = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfigurations)).BeginInit();
            this.palenlConfigurations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 37);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::Rail_Bag_Simulation.Properties.Resources.close;
            this.pictureBox5.Location = new System.Drawing.Point(1448, 4);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.PictureBox5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.panel2.Controls.Add(this.pbStatistics);
            this.panel2.Controls.Add(this.pbSimulation);
            this.panel2.Controls.Add(this.pbConfigurations);
            this.panel2.Controls.Add(this.btnStatistics);
            this.panel2.Controls.Add(this.btnSimulation);
            this.panel2.Controls.Add(this.btnConfigurations);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 566);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1459, 93);
            this.panel2.TabIndex = 1;
            // 
            // pbStatistics
            // 
            this.pbStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStatistics.Image = global::Rail_Bag_Simulation.Properties.Resources.statistics;
            this.pbStatistics.Location = new System.Drawing.Point(1345, 19);
            this.pbStatistics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbStatistics.Name = "pbStatistics";
            this.pbStatistics.Size = new System.Drawing.Size(56, 46);
            this.pbStatistics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatistics.TabIndex = 3;
            this.pbStatistics.TabStop = false;
            this.pbStatistics.Click += new System.EventHandler(this.PbStatistics_Click);
            // 
            // pbSimulation
            // 
            this.pbSimulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSimulation.Image = global::Rail_Bag_Simulation.Properties.Resources.simulation;
            this.pbSimulation.Location = new System.Drawing.Point(737, 19);
            this.pbSimulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbSimulation.Name = "pbSimulation";
            this.pbSimulation.Size = new System.Drawing.Size(48, 46);
            this.pbSimulation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSimulation.TabIndex = 3;
            this.pbSimulation.TabStop = false;
            this.pbSimulation.Click += new System.EventHandler(this.PbSimulation_Click);
            // 
            // pbConfigurations
            // 
            this.pbConfigurations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbConfigurations.Image = global::Rail_Bag_Simulation.Properties.Resources.settings;
            this.pbConfigurations.Location = new System.Drawing.Point(142, 11);
            this.pbConfigurations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbConfigurations.Name = "pbConfigurations";
            this.pbConfigurations.Size = new System.Drawing.Size(52, 54);
            this.pbConfigurations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConfigurations.TabIndex = 3;
            this.pbConfigurations.TabStop = false;
            this.pbConfigurations.Click += new System.EventHandler(this.PbConfigurations_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.btnStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStatistics.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStatistics.Location = new System.Drawing.Point(1162, 0);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(428, 93);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.BtnStatistics_Click);
            // 
            // btnSimulation
            // 
            this.btnSimulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.btnSimulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimulation.FlatAppearance.BorderSize = 0;
            this.btnSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSimulation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSimulation.Location = new System.Drawing.Point(584, 0);
            this.btnSimulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(363, 93);
            this.btnSimulation.TabIndex = 4;
            this.btnSimulation.Text = "Simulation";
            this.btnSimulation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSimulation.UseVisualStyleBackColor = false;
            this.btnSimulation.Click += new System.EventHandler(this.BtnSimulation_Click);
            // 
            // btnConfigurations
            // 
            this.btnConfigurations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.btnConfigurations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigurations.FlatAppearance.BorderSize = 0;
            this.btnConfigurations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurations.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConfigurations.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfigurations.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfigurations.Location = new System.Drawing.Point(0, 2);
            this.btnConfigurations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfigurations.Name = "btnConfigurations";
            this.btnConfigurations.Size = new System.Drawing.Size(335, 90);
            this.btnConfigurations.TabIndex = 3;
            this.btnConfigurations.Text = "Configurations";
            this.btnConfigurations.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfigurations.UseVisualStyleBackColor = false;
            this.btnConfigurations.Click += new System.EventHandler(this.BtnConfigurations_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(490, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please select configurations for the simulation\r\n";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(544, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of bags*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(544, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number of suspicios bags:\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(855, 144);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(93, 28);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(544, 254);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Flammable materials";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(544, 295);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Weapons";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(544, 380);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Others";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(544, 335);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Drugs";
            // 
            // tb_numberOfBags
            // 
            this.tb_numberOfBags.Location = new System.Drawing.Point(855, 98);
            this.tb_numberOfBags.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_numberOfBags.Multiline = true;
            this.tb_numberOfBags.Name = "tb_numberOfBags";
            this.tb_numberOfBags.Size = new System.Drawing.Size(93, 28);
            this.tb_numberOfBags.TabIndex = 14;
            // 
            // tb_weapons
            // 
            this.tb_weapons.Location = new System.Drawing.Point(855, 295);
            this.tb_weapons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_weapons.Multiline = true;
            this.tb_weapons.Name = "tb_weapons";
            this.tb_weapons.Size = new System.Drawing.Size(93, 28);
            this.tb_weapons.TabIndex = 15;
            // 
            // tb_Others
            // 
            this.tb_Others.Location = new System.Drawing.Point(855, 380);
            this.tb_Others.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Others.Multiline = true;
            this.tb_Others.Name = "tb_Others";
            this.tb_Others.Size = new System.Drawing.Size(93, 28);
            this.tb_Others.TabIndex = 16;
            // 
            // tb_flammables
            // 
            this.tb_flammables.Location = new System.Drawing.Point(855, 254);
            this.tb_flammables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_flammables.Multiline = true;
            this.tb_flammables.Name = "tb_flammables";
            this.tb_flammables.Size = new System.Drawing.Size(93, 28);
            this.tb_flammables.TabIndex = 17;
            // 
            // tb_drugs
            // 
            this.tb_drugs.Location = new System.Drawing.Point(855, 337);
            this.tb_drugs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_drugs.Multiline = true;
            this.tb_drugs.Name = "tb_drugs";
            this.tb_drugs.Size = new System.Drawing.Size(93, 28);
            this.tb_drugs.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(544, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Number of carts*";
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.BackColor = System.Drawing.Color.Black;
            this.btnRunSimulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunSimulation.FlatAppearance.BorderSize = 0;
            this.btnRunSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRunSimulation.ForeColor = System.Drawing.Color.White;
            this.btnRunSimulation.Location = new System.Drawing.Point(680, 502);
            this.btnRunSimulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(149, 50);
            this.btnRunSimulation.TabIndex = 25;
            this.btnRunSimulation.Text = "Run simulation";
            this.btnRunSimulation.UseVisualStyleBackColor = false;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // palenlConfigurations
            // 
            this.palenlConfigurations.Controls.Add(this.listBox1);
            this.palenlConfigurations.Controls.Add(this.btnLoadSimulation);
            this.palenlConfigurations.Controls.Add(this.textBox2);
            this.palenlConfigurations.Controls.Add(this.label10);
            this.palenlConfigurations.Controls.Add(this.pictureBox7);
            this.palenlConfigurations.Controls.Add(this.comboBox1);
            this.palenlConfigurations.Controls.Add(this.label9);
            this.palenlConfigurations.Controls.Add(this.btnRunSimulation);
            this.palenlConfigurations.Controls.Add(this.tb_drugs);
            this.palenlConfigurations.Controls.Add(this.tb_Others);
            this.palenlConfigurations.Controls.Add(this.tb_flammables);
            this.palenlConfigurations.Controls.Add(this.label8);
            this.palenlConfigurations.Controls.Add(this.tb_weapons);
            this.palenlConfigurations.Controls.Add(this.pictureBox6);
            this.palenlConfigurations.Controls.Add(this.tb_numberOfBags);
            this.palenlConfigurations.Controls.Add(this.pictureBox4);
            this.palenlConfigurations.Controls.Add(this.pictureBox3);
            this.palenlConfigurations.Controls.Add(this.pictureBox2);
            this.palenlConfigurations.Controls.Add(this.textBox1);
            this.palenlConfigurations.Controls.Add(this.label7);
            this.palenlConfigurations.Controls.Add(this.label1);
            this.palenlConfigurations.Controls.Add(this.label6);
            this.palenlConfigurations.Controls.Add(this.label5);
            this.palenlConfigurations.Controls.Add(this.label4);
            this.palenlConfigurations.Controls.Add(this.label3);
            this.palenlConfigurations.Controls.Add(this.label2);
            this.palenlConfigurations.Location = new System.Drawing.Point(1, 128);
            this.palenlConfigurations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.palenlConfigurations.Name = "palenlConfigurations";
            this.palenlConfigurations.Size = new System.Drawing.Size(1498, 643);
            this.palenlConfigurations.TabIndex = 26;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(39, 212);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 147);
            this.listBox1.TabIndex = 32;
            // 
            // btnLoadSimulation
            // 
            this.btnLoadSimulation.Location = new System.Drawing.Point(38, 171);
            this.btnLoadSimulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadSimulation.Name = "btnLoadSimulation";
            this.btnLoadSimulation.Size = new System.Drawing.Size(244, 27);
            this.btnLoadSimulation.TabIndex = 31;
            this.btnLoadSimulation.Text = "Load Simulation";
            this.btnLoadSimulation.UseVisualStyleBackColor = true;
            this.btnLoadSimulation.Click += new System.EventHandler(this.btnLoadSimulation_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(40, 142);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(244, 20);
            this.textBox2.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(1247, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 48);
            this.label10.TabIndex = 29;
            this.label10.Text = "Previous statistics\r\n\r\n";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Rail_Bag_Simulation.Properties.Resources.stat;
            this.pictureBox7.Location = new System.Drawing.Point(1262, 67);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(184, 548);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 28;
            this.pictureBox7.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Simulation1",
            "Simulation2",
            "Simulation3",
            "Simulation4",
            "Simulation5"});
            this.comboBox1.Location = new System.Drawing.Point(38, 108);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(246, 25);
            this.comboBox1.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(34, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 48);
            this.label9.TabIndex = 26;
            this.label9.Text = "Use previous simulations \r\nconfigurations\r\n";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Rail_Bag_Simulation.Properties.Resources.weapon;
            this.pictureBox6.Location = new System.Drawing.Point(502, 285);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 41);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 21;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Rail_Bag_Simulation.Properties.Resources.drugs;
            this.pictureBox4.Location = new System.Drawing.Point(502, 331);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 41);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Rail_Bag_Simulation.Properties.Resources.others;
            this.pictureBox3.Location = new System.Drawing.Point(502, 376);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Rail_Bag_Simulation.Properties.Resources.flamable;
            this.pictureBox2.Location = new System.Drawing.Point(502, 240);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // panelBorder1
            // 
            this.panelBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.panelBorder1.Location = new System.Drawing.Point(1150, 27);
            this.panelBorder1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(8, 789);
            this.panelBorder1.TabIndex = 28;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(119)))), ((int)(((byte)(155)))));
            this.panelBorder.Location = new System.Drawing.Point(336, 15);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(8, 774);
            this.panelBorder.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rail_Bag_Simulation.Properties.Resources.logomini;
            this.pictureBox1.Location = new System.Drawing.Point(643, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // simulation1
            // 
            this.simulation1.BackColor = System.Drawing.Color.White;
            this.simulation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulation1.Location = new System.Drawing.Point(0, 128);
            this.simulation1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simulation1.Name = "simulation1";
            this.simulation1.Size = new System.Drawing.Size(1448, 643);
            this.simulation1.TabIndex = 4;
            this.simulation1.Visible = false;
            // 
            // statistics1
            // 
            this.statistics1.BackColor = System.Drawing.Color.White;
            this.statistics1.Location = new System.Drawing.Point(0, 128);
            this.statistics1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.statistics1.Name = "statistics1";
            this.statistics1.Size = new System.Drawing.Size(1456, 626);
            this.statistics1.TabIndex = 3;
            this.statistics1.Visible = false;
            // 
            // btnSaveSimulation
            // 
            this.btnSaveSimulation.Location = new System.Drawing.Point(503, 54);
            this.btnSaveSimulation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveSimulation.Name = "btnSaveSimulation";
            this.btnSaveSimulation.Size = new System.Drawing.Size(106, 40);
            this.btnSaveSimulation.TabIndex = 30;
            this.btnSaveSimulation.Text = "Save Simulation";
            this.btnSaveSimulation.UseVisualStyleBackColor = true;
            this.btnSaveSimulation.Click += new System.EventHandler(this.btnSaveSimulation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1459, 659);
            this.Controls.Add(this.btnSaveSimulation);
            this.Controls.Add(this.panelBorder);
            this.Controls.Add(this.panelBorder1);
            this.Controls.Add(this.palenlConfigurations);
            this.Controls.Add(this.simulation1);
            this.Controls.Add(this.statistics1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfigurations)).EndInit();
            this.palenlConfigurations.ResumeLayout(false);
            this.palenlConfigurations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveLog;
        private System.Windows.Forms.OpenFileDialog openLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConfigurations;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.PictureBox pbConfigurations;
        private System.Windows.Forms.PictureBox pbSimulation;
        private System.Windows.Forms.PictureBox pbStatistics;
        private System.Windows.Forms.PictureBox pictureBox5;
        private View.UserControls.Statistics statistics1;
        public View.UserControls.Simulation simulation1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_numberOfBags;
        private System.Windows.Forms.TextBox tb_weapons;
        private System.Windows.Forms.TextBox tb_Others;
        private System.Windows.Forms.TextBox tb_flammables;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox tb_drugs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.Panel palenlConfigurations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Panel panelBorder1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSaveSimulation;
        private System.Windows.Forms.Button btnLoadSimulation;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

