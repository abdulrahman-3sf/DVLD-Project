using DVLD.ApplicationTypes;
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

namespace DVLD.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        private static DataTable _dtAllTestTypes = clsApplicationTypes.ListApplicationTypes();

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreashTestTypes()
        {
            _dtAllTestTypes = clsTestTypes.ListTestTypes();

            dataGridView1.DataSource = _dtAllTestTypes;
            label2.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreashTestTypes();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Description";
                dataGridView1.Columns[2].Width = 250;

                dataGridView1.Columns[3].HeaderText = "Fees";
                dataGridView1.Columns[3].Width = 90;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
