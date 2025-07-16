using DVLD.Applications.InternationalLicenses;
using DVLD.Applications.LocalDrivingLicenseApplications;
using DVLD.Applications.RenewLocalLicense;
using DVLD.Applications.ReplaceLostOrDamagedLicense;
using DVLD.Applications.RleaseDetanedLicense;
using DVLD.ApplicationTypes;
using DVLD.Drivers;
using DVLD.Global;
using DVLD.Licenses.Detain_License;
using DVLD.LocalDrivingLicenseApplications;
using DVLD.LogIn;
using DVLD.TestTypes;
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
        private frmManageApplicationTypes manageApplicationTypes;
        private frmManageTestTypes manageTestTypes;
        private frmManageLocalDrivingLicenseApplications manageLocalDrivingLicenseApplications;
        private frmAddEditNewLocalDrivingLicenseApplication addEditNewLocalDrivingLicenseApplication;
        private frmListDrivers manageDrivers;
        private frmListInternationalLicenseApplications manageInternationalLicenses;
        private frmNewInternationalLicenseApplication addNewInternationalLicenseApplication;
        private frmRenwLocalDrivingLicenseApplicatoin renwLocalDrivingLicenseApplicatoin;
        private frmReplaceLostOrDamagedLicense replaceLostOrDamagedLicense;
        private frmReleaseDetainedLicenseApplication releaseDetainedLicenseApplication;
        private frmListDetainedLicenses manageDetainedLicenses;
        private frmDetainLicenseApplication detainLicenseApplication;

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

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageApplicationTypes == null || manageApplicationTypes.IsDisposed)
            {
                manageApplicationTypes = new frmManageApplicationTypes();
                manageApplicationTypes.MdiParent = this;

                manageApplicationTypes.Show();
            }
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageTestTypes == null || manageTestTypes.IsDisposed)
            {
                manageTestTypes = new frmManageTestTypes();
                manageTestTypes.MdiParent = this;

                manageTestTypes.Show();
            }
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageLocalDrivingLicenseApplications == null || manageLocalDrivingLicenseApplications.IsDisposed)
            {
                manageLocalDrivingLicenseApplications = new frmManageLocalDrivingLicenseApplications();
                manageLocalDrivingLicenseApplications.MdiParent = this;

                manageLocalDrivingLicenseApplications.Show();
            }
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEditNewLocalDrivingLicenseApplication == null || addEditNewLocalDrivingLicenseApplication.IsDisposed)
            {
                addEditNewLocalDrivingLicenseApplication = new frmAddEditNewLocalDrivingLicenseApplication();
                addEditNewLocalDrivingLicenseApplication.MdiParent = this;

                addEditNewLocalDrivingLicenseApplication.Show();
            }
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageDrivers == null || manageDrivers.IsDisposed)
            {
                manageDrivers = new frmListDrivers();
                manageDrivers.MdiParent = this;

                manageDrivers.Show();
            }
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageInternationalLicenses == null || manageInternationalLicenses.IsDisposed)
            {
                manageInternationalLicenses = new frmListInternationalLicenseApplications();
                manageInternationalLicenses.MdiParent = this;

                manageInternationalLicenses.Show();
            }
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addNewInternationalLicenseApplication == null || addNewInternationalLicenseApplication.IsDisposed)
            {
                addNewInternationalLicenseApplication = new frmNewInternationalLicenseApplication();
                addNewInternationalLicenseApplication.MdiParent = this;

                addNewInternationalLicenseApplication.Show();
            }
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (renwLocalDrivingLicenseApplicatoin == null || renwLocalDrivingLicenseApplicatoin.IsDisposed)
            {
                renwLocalDrivingLicenseApplicatoin = new frmRenwLocalDrivingLicenseApplicatoin();
                renwLocalDrivingLicenseApplicatoin.MdiParent = this;

                renwLocalDrivingLicenseApplicatoin.Show();
            }
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replaceLostOrDamagedLicense == null || replaceLostOrDamagedLicense.IsDisposed)
            {
                replaceLostOrDamagedLicense = new frmReplaceLostOrDamagedLicense();
                replaceLostOrDamagedLicense.MdiParent = this;

                replaceLostOrDamagedLicense.Show();
            }
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (releaseDetainedLicenseApplication == null || releaseDetainedLicenseApplication.IsDisposed)
            {
                releaseDetainedLicenseApplication = new frmReleaseDetainedLicenseApplication();
                releaseDetainedLicenseApplication.MdiParent = this;

                releaseDetainedLicenseApplication.Show();
            }
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageDetainedLicenses == null || manageDetainedLicenses.IsDisposed)
            {
                manageDetainedLicenses = new frmListDetainedLicenses();
                manageDetainedLicenses.MdiParent = this;

                manageDetainedLicenses.Show();
            }
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detainLicenseApplication == null || detainLicenseApplication.IsDisposed)
            {
                detainLicenseApplication = new frmDetainLicenseApplication();
                detainLicenseApplication.MdiParent = this;

                detainLicenseApplication.Show();
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (releaseDetainedLicenseApplication == null || releaseDetainedLicenseApplication.IsDisposed)
            {
                releaseDetainedLicenseApplication = new frmReleaseDetainedLicenseApplication();
                releaseDetainedLicenseApplication.MdiParent = this;

                releaseDetainedLicenseApplication.Show();
            }
        }
    }
}
