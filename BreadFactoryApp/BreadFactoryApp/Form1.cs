using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace BreadFactoryApp
{
    public partial class Form1 : Form
    {
        private GenericBreadFactory _factory = null;
        public Form1()
        {
            InitializeComponent();


        }

        private void btnManufacture_Click(object sender, EventArgs e)
        {
            int nbrOfLoafsToBeManufatured;
            try
            {
                nbrOfLoafsToBeManufatured = Convert.ToInt32(tbToBeManufactured.Text);


                if (rbBrownBread.Checked)
                {
                    _factory = new GenericBreadFactory(new BrownBreadFactory(), nbrOfLoafsToBeManufatured);
                }
                else if (rbWhiteBread.Checked)
                {
                    _factory = new GenericBreadFactory(new WhiteBreadFactory(), nbrOfLoafsToBeManufatured);
                }
                else
                {
                    MessageBox.Show("Please select the type of bread to be manufactured");

                }


                GenericBreadFactory.PackageStatusChanged += packageUpdate;
                GenericBreadFactory.LabelStatusChanged += labelUpdate;
                GenericBreadFactory.FlourStatusChanged += flourUpdate;
                GenericBreadFactory.LoafsUpdated += loafUpdate;

                Thread t = new Thread(() =>
                {
                    _factory.StartManufacturing();
                });
                t.Start();
                btnManufacture.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void packageUpdate(object o, PackagesEventArgs p)
        {
            lbPackagingUpdates.Invoke(new Action(() =>
            {
                lbPackagingUpdates.Items.Add(p.Package.getID() + " " + p.Package.GetStatus());
            }));
        }

        private void labelUpdate(object o, LabelEventArgs l)
        {
            lbLabelingUpdates.Invoke(new Action(() =>
            {
                lbLabelingUpdates.Items.Add(l.Label.getID() + " " + l.Label.PrintCertification() + " " + l.Label.PrintExpiryDate());
            }));
        }

        private void flourUpdate(object o, FlourEventArgs f)
        {
            lbFlourUpdates.Invoke(new Action(() =>
            {
                lbFlourUpdates.Items.Add(f.Flour.getID() + " " + f.Flour.GetStatus());
            }));
        }

        private void loafUpdate(object o, LoafsEventArgs lf)
        {
            lbLogger.Invoke(new Action(() =>
            {
                lbLogger.Items.Add(lf.Loaf.getID() + " " + lf.Loaf.ToString());
            }));
        }

        private void btnStopManufacture_Click(object sender, EventArgs e)
        {
            _factory.StopManufacturing();
            btnStopManufacture.Enabled = false;

        }
    }
}
