using DVLD.Global;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueDrivingLicenseApplication : Form
    {
        private clsLocalDrivingLicenseApplications _LDLApplicatoin;
        private int _LDLApplicationID = -1;

        public frmIssueDrivingLicenseApplication(int LDLApplicatoinID)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicatoinID;
        }

        private void frmIssueDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LDLApplicatoin = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);

            if (_LDLApplicatoin == null)
            {
                MessageBox.Show("ERROR");
                return;
            }

            if (!_LDLApplicatoin.PassedAllTests())
            {
                MessageBox.Show("Pass all test first!");
                return;
            }

            int LicenseID = _LDLApplicatoin.GetActiveLicenseID();


            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LDLApplicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LicenseID = _LDLApplicatoin.IssueLicenseForTheFirtTime(textBox1.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
