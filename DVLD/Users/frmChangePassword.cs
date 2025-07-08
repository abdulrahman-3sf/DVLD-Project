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
    public partial class frmChangePassword : Form
    {
        private int _UserID;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfoByUserID(_UserID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUserID(_UserID);

            if (User.Password != textBox1.Text)
            {
                MessageBox.Show("The Current Password Incorrect!");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("The Password must be the same!");
                return;
            }

            User.Password = textBox2.Text;

            if (User.Save())
                MessageBox.Show("Password Updated Seccessfully!");
            else
                MessageBox.Show("ERROR");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
