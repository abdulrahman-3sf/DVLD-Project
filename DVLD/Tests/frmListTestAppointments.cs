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
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;

        private DataTable _dtTestAppointments;

        public frmListTestAppointments(int LDLApplicationID)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
        }

        private void _LoadTestTypeTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    label1.Text = "Vision Test Appointments";
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    label1.Text = "Written Test Appointments";
                    break;

                case clsTestTypes.enTestType.StreetTest:
                    label1.Text = "Street Test Appointments";
                    break;
            }
        }

        private void _RefreashTestAppointments()
        {
            _dtTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LDLApplicationID, _TestTypeID);

            dataGridView1.DataSource = _dtTestAppointments;
            label4.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeTitle();
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LDLApplicationID);
            _RefreashTestAppointments();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 150;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 100;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications LDLApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);
            
            if (LDLApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment");
                return;
            }

            clsTest LastTest = LDLApplication.GetLastTestPerTestType(_TestTypeID);

            if (LastTest == null)
            {
                Form form1 = new frmScheduleTest(_LDLApplicationID, _TestTypeID);
                form1.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test!");
                return;
            }

            Form form2 = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestTypeID);
            form2.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
