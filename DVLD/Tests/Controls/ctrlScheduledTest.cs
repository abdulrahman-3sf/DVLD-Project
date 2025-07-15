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

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private clsLocalDrivingLicenseApplications _LDLApplication;
        private int _LDLApplicationID = -1;

        private clsTestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;

        private clsTestTypes.enTestType _TestTypeID;
        private int _TestID = -1;
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        lblTitle.Text = "Vision Test";
                        break;

                    case clsTestTypes.enTestType.WrittenTest:
                        lblTitle.Text = "Written Test";
                        break;

                    case clsTestTypes.enTestType.StreetTest:
                        lblTitle.Text = "Street Test";
                        break;
                }
            }
        }

        public int TestAppointmentID { get { return _TestAppointmentID; } }
        public int TestID { get { return _TestID; } }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("ERROR");
                return;
            }

            _TestID = _TestAppointment.TestID;
            _LDLApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show("ERROR");
                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LDLApplication.PersonInfo.FullName;
            lblTrial.Text = _LDLApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1 ? "Not Taken Yet" : _TestAppointment.TestID.ToString());
        }
    }
}
