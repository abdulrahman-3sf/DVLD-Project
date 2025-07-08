using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddEditUserInfo : Form
    {
        private int _PersonID = -1;
        private int _UserID = -1;
        private bool alloTabChange = false;
        private clsUser _User;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public frmAddEditUserInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
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

            if (clsUser.IsUserExistByPersonID(_PersonID))
            {
                MessageBox.Show("This Person has User in the System! Select Another Person.");
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

            if (clsUser.IsUserExistByPersonID(_PersonID))
            {
                MessageBox.Show("This Person has User in the System! Select Another Person.");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("The Password must be the same!");
                return;
            }

            _User = new clsUser();

            _User.PersonID = _PersonID;
            _User.UserName = textBox1.Text.Trim();
            _User.Password = textBox2.Text.Trim();
            _User.IsActive = (bool)checkBox1.Checked;

            if (_User.Save())
            {
                _UserID = _User.UserID;

                MessageBox.Show("Added Seccessfully!" + _User.UserID);

                _Mode = enMode.Update;
                label13.Text = "Update User";
                label6.Text = _UserID.ToString();

                ctrlPersonCardWithFilter1.FilterEnable = false;
            }
            else
                MessageBox.Show("Added Faild!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
