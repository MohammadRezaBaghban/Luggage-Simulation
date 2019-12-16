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
            tbUserDOB.Enabled = false;
            tbUserName.Enabled = false;
            btnRegister.Enabled = false;
        }

        private void btnChangeInsurance_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            users.ForEach(user => listBox1.Items.Add(user));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            users.Remove((User)listBox1.SelectedItem);
        }
    }
}
