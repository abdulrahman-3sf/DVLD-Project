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

namespace DVLD.LocalDrivingLicenseApplications
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        private static DataTable _dtAllLDLApplications = clsLocalDrivingLicenseApplications.ListLocalDrivingLicenseApplications();

        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _RefreashLocalDrivingLicenseApplications()
        {
            _dtAllLDLApplications = clsLocalDrivingLicenseApplications.ListLocalDrivingLicenseApplications();

            dataGridView1.DataSource = _dtAllLDLApplications;
            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreashLocalDrivingLicenseApplications();
            comboBox1.SelectedIndex = 0;

            if (_dtAllLDLApplications.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "L.D.L AppID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "National No";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 200;

                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 130;

                dataGridView1.Columns[5].HeaderText = "Passed Test";
                dataGridView1.Columns[5].Width = 80;

                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 80;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (comboBox1.Text)
            {
                case "L.D.L AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "None" || textBox1.Text.Trim() == "")
            {
                _dtAllLDLApplications.DefaultView.RowFilter = "";
                label3.Text = (dataGridView1.Rows.Count).ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text);
            else
                _dtAllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Visible = (comboBox1.SelectedIndex != 0);

            if (textBox1.Visible)
                textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
