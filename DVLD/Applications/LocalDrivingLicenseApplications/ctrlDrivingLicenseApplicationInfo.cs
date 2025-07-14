using DVLD.Applications.Controls;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplications _LDLApplication;
        private int _LDLApplicationID = -1;

        public int LDLApplicationID { get { return _LDLApplicationID; } }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _FillLDLApplicationInfo()
        {
            _LDLApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            lblLocalDrivingLicenseApplicationID.Text = _LDLApplicationID.ToString();
            lblAppliedFor.Text = _LDLApplication.ApplicationTypeInfo.ApplicationTypeTitle;
            lblPassedTests.Text = _LDLApplication.GetPassedTestCount().ToString() + "/3";

            ctrlApplicationInfo1.LoadApplicationInfo(_LDLApplication.ApplicationID);
        }

        public void LoadApplicationInfo(int LDLApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show("No LDLApplicatoin with LDLApplication ID");
                return;
            }

            _FillLDLApplicationInfo();
        }
    }
}
