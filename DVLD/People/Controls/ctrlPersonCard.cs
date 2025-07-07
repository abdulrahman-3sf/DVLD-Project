using DVLD.Properties;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPeople _Person;
        private int _PersonID;

        public clsPeople PersonInfo
        {
            get { return _Person; }
        }

        public int PersonID
        {
            get { return _PersonID; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                pictureBox9.Image = Resources.Male_512;
            else
                pictureBox9.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox9.ImageLocation = ImagePath;
        }

        private void _FillPersonInfo()
        {
            linkLabel1.Enabled = true;
            _PersonID = _Person.PersonID;
            label7.Text = _Person.PersonID.ToString();
            label8.Text = _Person.FullName.ToString();
            label9.Text = _Person.NationalNo.ToString();
            label13.Text = _Person.Gender == 0 ? "Male" : "Female";
            label14.Text = _Person.Email.ToString();
            label15.Text = _Person.Address.ToString();
            label16.Text = _Person.DateOfBirth.ToString();
            label17.Text = _Person.Phone.ToString();
            label18.Text = _Person.CountryInfo.CountryName.ToString();
            _LoadPersonImage();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPeople.Find(PersonID);

            if (_Person == null)
            {
                MessageBox.Show("Not Found!");
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeople.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show("Not Found!");
                return;
            }

            _FillPersonInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo form = new frmAddEditPersonInfo(_PersonID);
            form.ShowDialog();

            LoadPersonInfo(_PersonID);
        }
    }
}
