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

namespace DVLD.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        private static DataTable _dtAllApplicationTypes = clsApplicationTypes.ListApplicationTypes();
        
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreashApplicationTypes()
        {
            _dtAllApplicationTypes = clsApplicationTypes.ListApplicationTypes();

            dataGridView1.DataSource = _dtAllApplicationTypes;
            label2.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreashApplicationTypes();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 250;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 90;
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form form = new frmUpdateApplicationType(ApplicationTypeID);
            form.ShowDialog();

            _RefreashApplicationTypes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
