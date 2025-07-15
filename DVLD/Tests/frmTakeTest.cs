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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _AppointmentID;
        private clsTestTypes.enTestType _TestTypeID;

        private clsTest _Test;
        private int _TestID = -1;

        public frmTakeTest(int AppointmentID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadInfo(_AppointmentID);

            button2.Enabled = (ctrlScheduledTest1.TestAppointmentID == -1 ? false : true);

            _TestID = ctrlScheduledTest1.TestID;

            if (_TestID !=- 1)
            {
                _Test = clsTest.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                {
                    rbFail.Checked = true;
                    txtNotes.Text = _Test.Notes;
                }

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            } else
            {
                _Test = new clsTest();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully!");
                button2.Enabled = false;
            } else
                MessageBox.Show("ERROR");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
