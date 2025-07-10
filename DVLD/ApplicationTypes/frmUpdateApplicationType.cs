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
    public partial class frmUpdateApplicationType : Form
    {
        private int _ID;
        private clsApplicationTypes _ApplicationType;

        public frmUpdateApplicationType(int ID)
        {
            InitializeComponent();

            _ID = ID;
        }

        private void _Load()
        {
            _ApplicationType = clsApplicationTypes.Find(_ID);

            label6.Text = _ApplicationType.ApplicationTypeID.ToString();
            textBox1.Text = _ApplicationType.ApplicationTypeTitle;
            textBox2.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _ApplicationType.ApplicationTypeTitle = textBox1.Text.Trim();
            _ApplicationType.ApplicationTypeFees = (float)Convert.ToDouble(textBox2.Text);

            if (_ApplicationType.Save())
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
