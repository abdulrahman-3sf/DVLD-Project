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
        private clsUser _User;
        private int _UserID;

        private frmManagePeople managePeopleForm;
        private frmManageUsers mangeUsersForm;
        private frmUserInfo userInfo;
        private frmChangePassword userChangePassword;

        public Main()
        {
            InitializeComponent();
        }

        public Main(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
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
                userInfo = new frmUserInfo(_UserID);
                userInfo.MdiParent = this;

                userInfo.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userChangePassword == null || userChangePassword.IsDisposed)
            {
                userChangePassword = new frmChangePassword(_UserID);
                userChangePassword.MdiParent = this;

                userChangePassword.Show();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UserID = -1;
            this.Close();
        }

    }
}
