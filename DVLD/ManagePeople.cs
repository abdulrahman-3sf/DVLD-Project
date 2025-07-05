using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD
{
    public partial class ManagePeople : Form
    {
        private DataTable dt;
        private DataTable PeopleDT;

        public ManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshComboBoxData()
        {
            dt = DVLD_Buisness.clsPeople.ListPeople();
            PeopleDT = dt.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth", "Gendor", "Address", "Phone", "Email", "NationalityCountryID");

            dataGridView1.DataSource = PeopleDT;
            label3.Text = (PeopleDT.Rows.Count).ToString();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "None";
            _RefreshComboBoxData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo form = new AddEditPersonInfo();
            form.ShowDialog();

            _RefreshComboBoxData();
        }
    }
}
