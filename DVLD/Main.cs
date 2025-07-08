using DVLD.Users;
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
        private frmManagePeople managePeopleForm;
        private frmManageUsers mangeUsersForm;

        public Main()
        {
            InitializeComponent();
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
    }
}
