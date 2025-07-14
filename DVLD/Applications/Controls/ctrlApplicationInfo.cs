using DVLD.People;
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

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationInfo : UserControl
    {
        private clsApplications _Application;
        private int _ApplicationID = -1;

        public int ApplicationID { get { return _ApplicationID; } }

        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.PersonInfo.FullName;
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedByUser.Text = _Application.UserInfo.UserName;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplications.FindByApplicationID(ApplicationID);

            if (_Application == null)
            {
                MessageBox.Show("No Applicatoin with Application ID");
                return;
            }

            _FillApplicationInfo();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowPersonInfo(_Application.ApplicationPersonID);
            form.ShowDialog();

            LoadApplicationInfo(_ApplicationID);
        }
    }
}
