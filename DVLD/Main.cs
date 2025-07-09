using DVLD.Global;
using DVLD.LogIn;
using DVLD.Users;
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

namespace DVLD
{
    public partial class Main : Form
    {
        private frmLogin _frmLogin;

        private frmManagePeople managePeopleForm;
        private frmManageUsers mangeUsersForm;
        private frmUserInfo userInfo;
        private frmChangePassword userChangePassword;

        public Main(frmLogin Login)
        {
            InitializeComponent();

            _frmLogin = Login;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (managePeopleForm == null || managePeopleForm.IsDisposed)
            {
                managePeopleForm = new frmManagePeople();
                managePeopleForm.MdiParent = this;

                managePeopleForm.Show();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mangeUsersForm == null || mangeUsersForm.IsDisposed)
            {
                mangeUsersForm = new frmManageUsers();
                mangeUsersForm.MdiParent = this;

                mangeUsersForm.Show();
            }
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userInfo == null || userInfo.IsDisposed)
            {
                userInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
                userInfo.MdiParent = this;

                userInfo.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userChangePassword == null || userChangePassword.IsDisposed)
            {
                userChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
                userChangePassword.MdiParent = this;

                userChangePassword.Show();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }
    }
}
