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

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        private int _UserID = -1;

        public clsUser UserInfo { get { return _User; } }
        public int UserID { get { return _UserID; } }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            label4.Text = _User.UserID.ToString();
            label5.Text = _User.UserName.ToString();
            label6.Text = _User.IsActive ? "Yes" : "No";
        }

        public void LoadUserInfoByUserID(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);

            if (_User == null)
            {
                MessageBox.Show("Not Found!");
                return;
            }

            _FillUserInfo();
        }

        public void LoadUserInfoByPersonID(int PersonID)
        {
            _User = clsUser.FindByUserID(PersonID);

            if (_User == null)
            {
                MessageBox.Show("Not Found!");
                return;
            }

            _FillUserInfo();
        }
    }
}
