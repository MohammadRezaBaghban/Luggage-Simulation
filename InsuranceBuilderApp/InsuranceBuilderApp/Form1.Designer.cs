namespace InsuranceBuilderApp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.tbUserDOB = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChangeInsurance = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rbBasic = new System.Windows.Forms.RadioButton();
            this.rbBasicDental = new System.Windows.Forms.RadioButton();
            this.rbBasicPhysio = new System.Windows.Forms.RadioButton();
            this.rbBasicDentalPhysio = new System.Windows.Forms.RadioButton();
            this.rbPremium = new System.Windows.Forms.RadioButton();
            this.rbPremiumPlus = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.tbUserName);
            this.panel1.Controls.Add(this.tbUserDOB);
            this.panel1.Controls.Add(this.lblDateOfBirth);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 140);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Register";
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(97, 97);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(109, 26);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.Location = new System.Drawing.Point(3, 73);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(106, 18);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "Date Of Birth";
            // 
            // tbUserDOB
            // 
            this.tbUserDOB.Location = new System.Drawing.Point(112, 71);
            this.tbUserDOB.Name = "tbUserDOB";
            this.tbUserDOB.Size = new System.Drawing.Size(199, 20);
            this.tbUserDOB.TabIndex = 6;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(112, 45);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(199, 20);
            this.tbUserName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(115, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Admin Panel";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(200, 323);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(109, 26);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(332, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 498);
            this.panel2.TabIndex = 8;
            // 
            // btnChangeInsurance
            // 
            this.btnChangeInsurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeInsurance.Location = new System.Drawing.Point(104, 111);
            this.btnChangeInsurance.Name = "btnChangeInsurance";
            this.btnChangeInsurance.Size = new System.Drawing.Size(119, 26);
            this.btnChangeInsurance.TabIndex = 2;
            this.btnChangeInsurance.Text = "Assign";
            this.btnChangeInsurance.UseVisualStyleBackColor = true;
            this.btnChangeInsurance.Click += new System.EventHandler(this.btnChangeInsurance_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.rbPremiumPlus);
            this.panel3.Controls.Add(this.rbPremium);
            this.panel3.Controls.Add(this.rbBasicDentalPhysio);
            this.panel3.Controls.Add(this.rbBasicPhysio);
            this.panel3.Controls.Add(this.rbBasicDental);
            this.panel3.Controls.Add(this.rbBasic);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnChangeInsurance);
            this.panel3.Location = new System.Drawing.Point(3, 355);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 140);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Change Insurance";
            // 
            // rbBasic
            // 
            this.rbBasic.AutoSize = true;
            this.rbBasic.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBasic.Location = new System.Drawing.Point(14, 31);
            this.rbBasic.Name = "rbBasic";
            this.rbBasic.Size = new System.Drawing.Size(65, 23);
            this.rbBasic.TabIndex = 4;
            this.rbBasic.TabStop = true;
            this.rbBasic.Text = "Basic";
            this.rbBasic.UseVisualStyleBackColor = true;
            // 
            // rbBasicDental
            // 
            this.rbBasicDental.AutoSize = true;
            this.rbBasicDental.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBasicDental.Location = new System.Drawing.Point(14, 54);
            this.rbBasicDental.Name = "rbBasicDental";
            this.rbBasicDental.Size = new System.Drawing.Size(130, 23);
            this.rbBasicDental.TabIndex = 5;
            this.rbBasicDental.TabStop = true;
            this.rbBasicDental.Text = "Basic - Dental";
            this.rbBasicDental.UseVisualStyleBackColor = true;
            // 
            // rbBasicPhysio
            // 
            this.rbBasicPhysio.AutoSize = true;
            this.rbBasicPhysio.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBasicPhysio.Location = new System.Drawing.Point(14, 77);
            this.rbBasicPhysio.Name = "rbBasicPhysio";
            this.rbBasicPhysio.Size = new System.Drawing.Size(130, 23);
            this.rbBasicPhysio.TabIndex = 6;
            this.rbBasicPhysio.TabStop = true;
            this.rbBasicPhysio.Text = "Basic - Physio";
            this.rbBasicPhysio.UseVisualStyleBackColor = true;
            // 
            // rbBasicDentalPhysio
            // 
            this.rbBasicDentalPhysio.AutoSize = true;
            this.rbBasicDentalPhysio.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBasicDentalPhysio.Location = new System.Drawing.Point(129, 29);
            this.rbBasicDentalPhysio.Name = "rbBasicDentalPhysio";
            this.rbBasicDentalPhysio.Size = new System.Drawing.Size(179, 23);
            this.rbBasicDentalPhysio.TabIndex = 7;
            this.rbBasicDentalPhysio.TabStop = true;
            this.rbBasicDentalPhysio.Text = "Basic-Dental-Physio";
            this.rbBasicDentalPhysio.UseVisualStyleBackColor = true;
            // 
            // rbPremium
            // 
            this.rbPremium.AutoSize = true;
            this.rbPremium.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPremium.Location = new System.Drawing.Point(150, 54);
            this.rbPremium.Name = "rbPremium";
            this.rbPremium.Size = new System.Drawing.Size(96, 23);
            this.rbPremium.TabIndex = 8;
            this.rbPremium.TabStop = true;
            this.rbPremium.Text = "Premium";
            this.rbPremium.UseVisualStyleBackColor = true;
            // 
            // rbPremiumPlus
            // 
            this.rbPremiumPlus.AutoSize = true;
            this.rbPremiumPlus.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPremiumPlus.Location = new System.Drawing.Point(150, 77);
            this.rbPremiumPlus.Name = "rbPremiumPlus";
            this.rbPremiumPlus.Size = new System.Drawing.Size(127, 23);
            this.rbPremiumPlus.TabIndex = 9;
            this.rbPremiumPlus.TabStop = true;
            this.rbPremiumPlus.Text = "PremiumPlus";
            this.rbPremiumPlus.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(312, 290);
            this.listBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 512);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbUserDOB;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbPremiumPlus;
        private System.Windows.Forms.RadioButton rbPremium;
        private System.Windows.Forms.RadioButton rbBasicDentalPhysio;
        private System.Windows.Forms.RadioButton rbBasicPhysio;
        private System.Windows.Forms.RadioButton rbBasicDental;
        private System.Windows.Forms.RadioButton rbBasic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeInsurance;
    }
}

