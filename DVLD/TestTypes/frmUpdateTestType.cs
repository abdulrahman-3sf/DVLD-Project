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
    public partial class frmUpdateTestType : Form
    {
        private int _ID;
        private clsTestTypes _TestType;

        public frmUpdateTestType(int ID)
        {
            InitializeComponent();

            _ID = ID;
        }

        private void _Load()
        {
            _TestType = clsTestTypes.Find(_ID);

            label6.Text = _TestType.TestTypeID.ToString();
            textBox1.Text = _TestType.TestTypeTitle;
            textBox2.Text = _TestType.TestTypeDescription;
            textBox3.Text = _TestType.TestTypeFees.ToString();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeTitle = textBox1.Text.Trim();
            _TestType.TestTypeDescription = textBox2.Text.Trim();
            _TestType.TestTypeFees = (float)Convert.ToDouble(textBox3.Text);

            if (_TestType.Save())
                MessageBox.Show("Saved Seccessfully!");
            else
                MessageBox.Show("ERROR!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
