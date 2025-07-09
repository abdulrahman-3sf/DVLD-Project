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
        private clsUser _User;
        private int _UserID = -1;
        private bool _RememberUser = true;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text.Trim();
            string Password = textBox2.Text.Trim();

            _User = clsUser.FindByUsernameAndUserID(UserName, Password);
            _RememberUser = checkBox1.Checked;

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

            _UserID = _User.UserID;

            Form form = new Main(_UserID);
            form.ShowDialog();
        }
    }
}
