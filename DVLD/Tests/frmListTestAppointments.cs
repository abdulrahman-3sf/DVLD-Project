using DVLD.Applications.LocalDrivingLicenseApplications;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LDLApplicationID = -1;

        private static DataTable _dtAllTestAppointments = clsTestAppointments.GetAllTestAppointments();
        private DataTable _dtTestAppointments = _dtAllTestAppointments.DefaultView.ToTable(false, "TestAppointmentID", "AppointmentDate", "PaidFees", "IsLocked");

        public frmListTestAppointments(int LDLApplicationID)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
        }

        private void _RefreashTestAppointments()
        {
            _dtAllTestAppointments = clsTestAppointments.GetAllTestAppointments();
            _dtTestAppointments = _dtAllTestAppointments.DefaultView.ToTable(false, "TestAppointmentID", "AppointmentDate", "PaidFees", "IsLocked");

            _dtAllTestAppointments.DefaultView.RowFilter = string.Format("[LocalDrivingLicenseApplicationID] = {0}", _LDLApplicationID);

            dataGridView1.DataSource = _dtTestAppointments;
            label4.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LDLApplicationID);
            _RefreashTestAppointments();

            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 90;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
