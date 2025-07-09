using DVLD.Global;
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

namespace DVLD.LogIn
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredUsers(ref UserName, ref Password))
            {
                textBox1.Text = UserName;
                textBox2.Text = Password;
                checkBox1.Checked = true;
            }
            else
                checkBox1.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text.Trim();
            string Password = textBox2.Text.Trim();

            clsUser _User = clsUser.FindByUsernameAndUserID(UserName, Password);

            if (_User == null)
            {
                MessageBox.Show("Username/Password Incorrect!");
                return;
            }

            if (!_User.IsActive)
            {
                MessageBox.Show("User is not Active! Talk with Your Admin.");
                return;
            }

            if (checkBox1.Checked)
            {
                clsGlobal.StoreRememberUsers(UserName, Password);
            }

            clsGlobal.CurrentUser = _User;

            this.Hide();
            Form form = new Main(this);
            form.ShowDialog();
        }
    }
}
