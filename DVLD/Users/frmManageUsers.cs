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

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        private static DataTable _dtAllUsers = clsUser.ListUsers();
        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _RefreashUsers()
        {
            _dtAllUsers = clsUser.ListUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

            dataGridView1.DataSource = _dtUsers;
            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreashUsers();
            comboBox1.SelectedIndex = 0;

            if (_dtUsers.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 200;

                dataGridView1.Columns[3].HeaderText = "User Name";
                dataGridView1.Columns[3].Width = 90;

                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 90;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            
            switch (comboBox1.Text)
            {
                case "UserID":
                    FilterColumn = "UserID";
                    break;

                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "FullName":
                    FilterColumn = "FullName";
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "IsActive":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "None" || textBox1.Text.Trim() == "")
            {
                _dtUsers.DefaultView.RowFilter = "";
                label3.Text = (dataGridView1.Rows.Count).ToString();
                return;
            }

            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());
            
            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (comboBox1.SelectedIndex != 0 && comboBox1.SelectedIndex != 5);
            comboBox2.Visible = (comboBox1.SelectedIndex == 5);

            if (textBox1.Visible)
                textBox1.Text = "";

            if (comboBox2.Visible)
                comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtUsers == null)
                return;

            string FilterColumn = "IsActive";

            if (comboBox2.SelectedIndex == 0)
                _dtUsers.DefaultView.RowFilter = "";
            else if (comboBox2.SelectedIndex == 1)
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = 1", FilterColumn);
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = 0", FilterColumn);

            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form form = new frmUserInfo(UserID);
            form.ShowDialog();

            _RefreashUsers();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditUserInfo();
            form.ShowDialog();

            _RefreashUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form form = new frmAddEditUserInfo(UserID);
            form.ShowDialog();

            _RefreashUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("Person Deleted Successfully.");
                _RefreashUsers();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form form = new frmChangePassword(UserID);
            form.ShowDialog();

            _RefreashUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditUserInfo();
            form.ShowDialog();

            _RefreashUsers();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
