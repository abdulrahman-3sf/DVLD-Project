using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.People;
using DVLD_Buisness;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        private static DataTable _dtAllPeople = clsPeople.ListPeople();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth", "GendorCaption", "CountryName", "Phone", "Email");

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeople()
        {
            _dtAllPeople = clsPeople.ListPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth", "GendorCaption", "CountryName", "Phone", "Email");

            dataGridView1.DataSource = _dtPeople;
            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeople();
            comboBox1.SelectedItem = 0;

            if (_dtPeople.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "National No";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 120;

                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Date Of Birth";
                dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Gender";
                dataGridView1.Columns[7].Width = 60;

                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 120;

                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 120;

                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 150;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPersonInfo();
            form.ShowDialog();

            _RefreshPeople();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (comboBox1.SelectedIndex != 0);

            if (textBox1.Visible)
                textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "None" || textBox1.Text.Trim() == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                label3.Text = (dataGridView1.Rows.Count).ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            label3.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form form = new frmShowPersonInfo(PersonID);
            form.ShowDialog();

            _RefreshPeople();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddEditPersonInfo();
            form.ShowDialog();

            _RefreshPeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            Form form = new frmAddEditPersonInfo(PersonID);
            form.ShowDialog();

            _RefreshPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            
            if (clsPeople.DeletePerson(PersonID))
            {
                MessageBox.Show("Person Deleted Successfully.");
                _RefreshPeople();
            } else
            {
                MessageBox.Show("Error");
            }    
        }
    }
}
