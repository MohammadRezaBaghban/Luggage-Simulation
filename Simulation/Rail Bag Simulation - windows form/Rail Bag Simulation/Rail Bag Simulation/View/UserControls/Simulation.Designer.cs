﻿namespace Rail_Bag_Simulation.View.UserControls
{
    partial class Simulation
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
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnPowerOutage = new System.Windows.Forms.Button();

            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Cn_Terminal2_To_Gate2 = new Rail_Bag_Simulation.CustomizedControl.ConveyorHorizontal();
            this.Cn_Terminal2_To_Gate1 = new Rail_Bag_Simulation.CustomizedControl.ConveyorHorizontal();
            this.Cn_Terminal1_To_Gate2 = new Rail_Bag_Simulation.CustomizedControl.ConveyorHorizontal();
            this.Cn_Terminal1_To_Gate1 = new Rail_Bag_Simulation.CustomizedControl.ConveyorHorizontal();
            this.Cn_Sorter_To_Terminal2 = new Rail_Bag_Simulation.CustomizedControl.ConveyorVertical();
            this.Cn_Sorter_To_Terminal1 = new Rail_Bag_Simulation.CustomizedControl.ConveyorVertical();
            this.Cn_Security_Sorter = new Rail_Bag_Simulation.CustomizedControl.ConveyorHorizontal();
            this.Cn_CheckIn_To_Security = new Rail_Bag_Simulation.CustomizedControl.ConveyorHorizontal();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::Rail_Bag_Simulation.Properties.Resources.gate;
            this.pictureBox9.Location = new System.Drawing.Point(1076, 5);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(69, 47);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 37;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Rail_Bag_Simulation.Properties.Resources.sorter1;
            this.pictureBox6.Location = new System.Drawing.Point(645, 245);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(65, 65);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 34;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Rail_Bag_Simulation.Properties.Resources.securityCheckHouse;
            this.pictureBox5.Location = new System.Drawing.Point(316, 245);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(69, 65);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Rail_Bag_Simulation.Properties.Resources.storage;
            this.pictureBox4.Location = new System.Drawing.Point(316, 314);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 61);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::Rail_Bag_Simulation.Properties.Resources.terminal;
            this.pictureBox11.Location = new System.Drawing.Point(714, 5);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(118, 111);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 40;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Rail_Bag_Simulation.Properties.Resources.gate;
            this.pictureBox8.Location = new System.Drawing.Point(1076, 69);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(69, 47);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 41;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Rail_Bag_Simulation.Properties.Resources.gate;
            this.pictureBox7.Location = new System.Drawing.Point(1076, 503);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(69, 47);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 46;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::Rail_Bag_Simulation.Properties.Resources.gate;
            this.pictureBox10.Location = new System.Drawing.Point(1076, 439);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(69, 47);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 45;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::Rail_Bag_Simulation.Properties.Resources.terminal;
            this.pictureBox13.Location = new System.Drawing.Point(714, 450);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(118, 100);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 44;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Rail_Bag_Simulation.Properties.Resources.check_in;
            this.pictureBox3.Location = new System.Drawing.Point(2, 245);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // Cn_Terminal2_To_Gate2
            // 
            this.Cn_Terminal2_To_Gate2.Location = new System.Drawing.Point(836, 503);
            this.Cn_Terminal2_To_Gate2.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Terminal2_To_Gate2.Name = "Cn_Terminal2_To_Gate2";
            this.Cn_Terminal2_To_Gate2.Size = new System.Drawing.Size(236, 47);
            this.Cn_Terminal2_To_Gate2.TabIndex = 54;
            // 
            // Cn_Terminal2_To_Gate1
            // 
            this.Cn_Terminal2_To_Gate1.Location = new System.Drawing.Point(836, 439);
            this.Cn_Terminal2_To_Gate1.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Terminal2_To_Gate1.Name = "Cn_Terminal2_To_Gate1";
            this.Cn_Terminal2_To_Gate1.Size = new System.Drawing.Size(236, 47);
            this.Cn_Terminal2_To_Gate1.TabIndex = 53;
            // 
            // Cn_Terminal1_To_Gate2
            // 
            this.Cn_Terminal1_To_Gate2.Location = new System.Drawing.Point(836, 69);
            this.Cn_Terminal1_To_Gate2.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Terminal1_To_Gate2.Name = "Cn_Terminal1_To_Gate2";
            this.Cn_Terminal1_To_Gate2.Size = new System.Drawing.Size(236, 47);
            this.Cn_Terminal1_To_Gate2.TabIndex = 52;
            // 
            // Cn_Terminal1_To_Gate1
            // 
            this.Cn_Terminal1_To_Gate1.Location = new System.Drawing.Point(836, 5);
            this.Cn_Terminal1_To_Gate1.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Terminal1_To_Gate1.Name = "Cn_Terminal1_To_Gate1";
            this.Cn_Terminal1_To_Gate1.Size = new System.Drawing.Size(236, 47);
            this.Cn_Terminal1_To_Gate1.TabIndex = 51;
            // 
            // Cn_Sorter_To_Terminal2
            // 
            this.Cn_Sorter_To_Terminal2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Cn_Sorter_To_Terminal2.Location = new System.Drawing.Point(647, 314);
            this.Cn_Sorter_To_Terminal2.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Sorter_To_Terminal2.Name = "Cn_Sorter_To_Terminal2";
            this.Cn_Sorter_To_Terminal2.Size = new System.Drawing.Size(65, 236);
            this.Cn_Sorter_To_Terminal2.TabIndex = 50;
            // 
            // Cn_Sorter_To_Terminal1
            // 
            this.Cn_Sorter_To_Terminal1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Cn_Sorter_To_Terminal1.Location = new System.Drawing.Point(645, 5);
            this.Cn_Sorter_To_Terminal1.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Sorter_To_Terminal1.Name = "Cn_Sorter_To_Terminal1";
            this.Cn_Sorter_To_Terminal1.Size = new System.Drawing.Size(65, 236);
            this.Cn_Sorter_To_Terminal1.TabIndex = 49;
            // 
            // Cn_Security_Sorter
            // 
            this.Cn_Security_Sorter.Location = new System.Drawing.Point(389, 245);
            this.Cn_Security_Sorter.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_Security_Sorter.Name = "Cn_Security_Sorter";
            this.Cn_Security_Sorter.Size = new System.Drawing.Size(254, 65);
            this.Cn_Security_Sorter.TabIndex = 48;
            // 
            // Cn_CheckIn_To_Security
            // 
            this.Cn_CheckIn_To_Security.Location = new System.Drawing.Point(62, 245);
            this.Cn_CheckIn_To_Security.Margin = new System.Windows.Forms.Padding(2);
            this.Cn_CheckIn_To_Security.Name = "Cn_CheckIn_To_Security";
            this.Cn_CheckIn_To_Security.Size = new System.Drawing.Size(254, 65);
            this.Cn_CheckIn_To_Security.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 55;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Black;
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Miriam Mono CLM", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(447, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(129, 35);
            this.btnPause.TabIndex = 47;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Black;
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Miriam Mono CLM", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(608, 3);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(117, 35);
            this.btnContinue.TabIndex = 48;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            // 
            // btnPowerOutage
            // 
            this.btnPowerOutage.BackColor = System.Drawing.Color.Black;
            this.btnPowerOutage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPowerOutage.FlatAppearance.BorderSize = 0;
            this.btnPowerOutage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPowerOutage.Font = new System.Drawing.Font("Miriam Mono CLM", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPowerOutage.ForeColor = System.Drawing.Color.Red;
            this.btnPowerOutage.Location = new System.Drawing.Point(13, 3);
            this.btnPowerOutage.Name = "btnPowerOutage";
            this.btnPowerOutage.Size = new System.Drawing.Size(163, 35);
            this.btnPowerOutage.TabIndex = 49;
            this.btnPowerOutage.Text = "Power outage";
            this.btnPowerOutage.UseVisualStyleBackColor = false;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;

            this.Controls.Add(this.btnPowerOutage);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Cn_Terminal2_To_Gate2);
            this.Controls.Add(this.Cn_Terminal2_To_Gate1);
            this.Controls.Add(this.Cn_Terminal1_To_Gate2);
            this.Controls.Add(this.Cn_Terminal1_To_Gate1);
            this.Controls.Add(this.Cn_Sorter_To_Terminal2);
            this.Controls.Add(this.Cn_Sorter_To_Terminal1);
            this.Controls.Add(this.Cn_Security_Sorter);
            this.Controls.Add(this.Cn_CheckIn_To_Security);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Simulation";
            this.Size = new System.Drawing.Size(1385, 618);
            this.Load += new System.EventHandler(this.Simulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnPowerOutage;

        private CustomizedControl.ConveyorHorizontal Cn_CheckIn_To_Security;
        private CustomizedControl.ConveyorHorizontal Cn_Security_Sorter;
        private CustomizedControl.ConveyorVertical Cn_Sorter_To_Terminal1;
        private CustomizedControl.ConveyorVertical Cn_Sorter_To_Terminal2;
        private CustomizedControl.ConveyorHorizontal Cn_Terminal1_To_Gate1;
        private CustomizedControl.ConveyorHorizontal Cn_Terminal1_To_Gate2;
        private CustomizedControl.ConveyorHorizontal Cn_Terminal2_To_Gate2;
        private CustomizedControl.ConveyorHorizontal Cn_Terminal2_To_Gate1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button1;
    }
}
