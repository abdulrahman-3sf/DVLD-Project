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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD.Global;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmAddEditNewLocalDrivingLicenseApplication : Form
    {
        private clsLocalDrivingLicenseApplications _LDLApplicatoin;
        private int _LDLApplicationID = -1;
        private int _PersonID = -1;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private bool alloTabChange = false;

        public frmAddEditNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditNewLocalDrivingLicenseApplication(int LDLApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LDLApplicationID = LDLApplicationID;
        }

        private void _ResetDefaultData()
        {
            if (_Mode == enMode.AddNew)
            {
                _LDLApplicatoin = new clsLocalDrivingLicenseApplications();

                label13.Text = "New Local Driving License Application";
                alloTabChange = false;
                button3.Visible = false;
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                label13.Text = "Update Local Driving License Application";
                alloTabChange = true;
                button3.Visible = true;
            }

            label6.Text = "N/A";
            label7.Text = DateTime.Now.ToString();
            comboBox1.SelectedIndex = 2;
            label8.Text = clsApplicationTypes.Find(1).ApplicationTypeFees.ToString();
            label9.Text = clsGlobal.CurrentUser.UserName;
        }

        private void _LoadData()
        {
            _LDLApplicatoin = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);

            if (_LDLApplicatoin == null)
            {
                MessageBox.Show("This Application does not Exist!");
                return;
            }

            label6.Text = _LDLApplicatoin.LocalDrivingLicenseApplicationID.ToString();
            label7.Text = _LDLApplicatoin.ApplicationDate.ToString();
            comboBox1.SelectedIndex = _LDLApplicatoin.LicenseClassID - 1;
            label8.Text = clsApplicationTypes.Find(1).ApplicationTypeFees.ToString();
            label9.Text = _LDLApplicatoin.UserInfo.UserName;

            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnable = false;
        }

        private void frmAddEditNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                MessageBox.Show("Select Person First!");
                return;
            }

            alloTabChange = true;
            button3.Visible = true;
            tabControl1.SelectedIndex = 1;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = (!alloTabChange);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                MessageBox.Show("Select Person First!");
                return;
            }

            _LDLApplicatoin.LicenseClassID = comboBox1.SelectedIndex + 1;
            _LDLApplicatoin.ApplicationPersonID = _PersonID;
            _LDLApplicatoin.ApplicationDate = DateTime.Now;
            _LDLApplicatoin.ApplicationTypeID = 1;
            _LDLApplicatoin.ApplicationStatus = (clsLocalDrivingLicenseApplications.enApplicationStatus)1;
            _LDLApplicatoin.LastStatusDate = DateTime.Now;
            _LDLApplicatoin.PaidFees = clsApplicationTypes.Find(_LDLApplicatoin.ApplicationTypeID).ApplicationTypeFees;
            _LDLApplicatoin.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_LDLApplicatoin.Save())
            {
                _LDLApplicationID = _LDLApplicatoin.LocalDrivingLicenseApplicationID;
                label6.Text = _LDLApplicationID.ToString();
                label13.Text = "Update Local Driving License Application";

                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.FilterEnable = false;

                MessageBox.Show("Added Seccessfully!" + _LDLApplicationID);
            } else
                MessageBox.Show("Added Faild!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
