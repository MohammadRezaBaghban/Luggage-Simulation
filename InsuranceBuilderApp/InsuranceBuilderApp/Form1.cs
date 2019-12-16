using InsuranceBuilderApp.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsuranceBuilderApp
{
    public partial class Form1 : Form
    {
        InsuranceBuilder insuranceBuilder;
        private List<User> users;
        public Form1()
        {
            InitializeComponent();
            insuranceBuilder = new InsuranceBuilder();
            users = new List<User>();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbUserName.Text)||string.IsNullOrWhiteSpace(tbUserDOB.Text)) return;

            var item = new User(tbUserName.Text, tbUserDOB.Text);
            users.Add(item);
            listBox1.Items.Add(item);
            tbUserDOB.Clear();
            tbUserName.Clear(); 
        }

        private void btnChangeInsurance_Click(object sender, EventArgs e)
        {
            var user = (User)listBox1.SelectedItem;
            if(user == null) {
                MessageBox.Show(@"Select Client!"); return;}
            if (rbBasic.Checked)
            {
                Insurance insurance =  insuranceBuilder.makeBasicPackage();
                user.SetInsurance(insurance);
            }
            else if(rbBasicDental.Checked)
            {
                Insurance insurance = insuranceBuilder.makeBasicWithDental();
                user.SetInsurance(insurance);
            }
            else if (rbBasicDentalPhysio.Checked)
            {
                Insurance insurance = insuranceBuilder.makeBasicWithPhysioAndDental();
                user.SetInsurance(insurance);
            }
            else if (rbBasicPhysio.Checked)
            {
                Insurance insurance = insuranceBuilder.makeBasicWithPhysio();
                user.SetInsurance(insurance);
            }
            else if (rbPremium.Checked)
            {
                Insurance insurance = insuranceBuilder.makeBasicPremium();
                user.SetInsurance(insurance);
            }
            else if (rbPremiumPlus.Checked)
            {
                Insurance insurance = insuranceBuilder.makePremiumPlus();
                user.SetInsurance(insurance);
            }

            btnRefresh.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            users.ForEach(user => listBox1.Items.Add(user));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var user = (User)listBox1.SelectedItem;
            if (user == null)
            {
                MessageBox.Show(@"Select Client!"); return;
            }
            users.Remove(user);
        }
    }
}
