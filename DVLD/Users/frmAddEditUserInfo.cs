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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Users
{
    public partial class frmAddEditUserInfo : Form
    {
        private clsUser _User;
        private int _UserID = -1;
        private int _PersonID = -1;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private bool alloTabChange = false;

        public frmAddEditUserInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditUserInfo(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefaultData()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();

                label13.Text = "Add New Person";
                alloTabChange = false;
                button3.Visible = false;
                tabControl1.SelectedIndex = 0;
            } else
            {
                label13.Text = "Update User";
                alloTabChange = true;
                button3.Visible = true;
            }

            label6.Text = "N/A";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox1.Checked = true;
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("This User does not Exist!");
                return;
            }

            label6.Text = _User.UserID.ToString();
            textBox1.Text = _User.UserName;
            textBox2.Text = _User.Password;
            textBox3.Text = _User.Password;
            checkBox1.Checked = _User.IsActive;
            
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            ctrlPersonCardWithFilter1.FilterEnable = false;

            _PersonID = _User.PersonID;
        }

        private void frmAddEditUserInfo_Load(object sender, EventArgs e)
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

            if (clsUser.IsUserExistByPersonID(_PersonID) && _Mode == enMode.AddNew)
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

            if (clsUser.IsUserExistByPersonID(_PersonID) && _Mode == enMode.AddNew)
            {
                MessageBox.Show("This Person has User in the System! Select Another Person.");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("The Password must be the same!");
                return;
            }

            _User.PersonID = _PersonID;
            _User.UserName = textBox1.Text.Trim();
            _User.Password = textBox2.Text.Trim();
            _User.IsActive = (bool)checkBox1.Checked;

            if (_User.Save())
            {
                _UserID = _User.UserID;
                _Mode = enMode.Update;
                label13.Text = "Update User";
                label6.Text = _UserID.ToString();

                ctrlPersonCardWithFilter1.FilterEnable = false;

                MessageBox.Show("Added Seccessfully!" + _User.UserID);
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
