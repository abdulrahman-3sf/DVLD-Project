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
    public partial class frmAddEditPersonInfo : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        private int _PersonID;
        private clsPeople _Person;
        private string SelectedImagePath = "";

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public frmAddEditPersonInfo()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPeople();
                label13.Text = "Add New Person";
            } else
            {
                label13.Text = "Update Person";
            }

            radioButton1.Checked = true;
            linkLabel2.Visible = false;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            // Set maximum date to 18 years ago from today
            dateTimePicker2.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker2.Value = dateTimePicker2.MaxDate;

            comboBox1.SelectedIndex = comboBox1.FindString("Saudi Arabia");
        }

        private void _FillCountriesInComboBox()
        {
            DataTable CountresDT = clsCountry.ListCountries();

            foreach (DataRow row in CountresDT.Rows)
                comboBox1.Items.Add(row["CountryName"]);

        }

        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Get the parent form that hosts this control
            if (parentForm != null)
            {
                parentForm.Close(); // Close the form
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Person.NationalNo = textBox2.Text.Trim();
            _Person.FirstName = textBox1.Text.Trim();
            _Person.SecondName = textBox6.Text.Trim();
            _Person.ThirdName = textBox7.Text.Trim();
            _Person.LastName = textBox8.Text.Trim();
            _Person.DateOfBirth = dateTimePicker2.Value;
            _Person.Address = textBox5.Text.Trim();
            _Person.Phone = textBox10.Text.Trim();
            _Person.Email = textBox4.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(comboBox1.Text).CountryID;

            if (radioButton1.Checked)
                _Person.Gender = (clsPeople.enGender)Convert.ToInt32(radioButton1.Tag);
            else
                _Person.Gender = (clsPeople.enGender)Convert.ToInt32(radioButton2.Tag);

            if (SelectedImagePath != "")
            {
                // Define target folder in C:\
                string projectFolder = @"C:\DVLD_ProjectImages";
                if (!Directory.Exists(projectFolder))
                {
                    Directory.CreateDirectory(projectFolder);
                }

                // Generate new file name with same extension
                string fileExtension = Path.GetExtension(SelectedImagePath);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;
                string newFilePath = Path.Combine(projectFolder, newFileName);

                File.Copy(SelectedImagePath, newFilePath, true);

                // Replace the old path with the new one
                SelectedImagePath = newFilePath;
            }

            _Person.ImagePath = SelectedImagePath; 

            if (_Person.Save())
            {
                _PersonID = _Person.PersonID;

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);

                MessageBox.Show("Added Seccessfully!" + _Person.PersonID);
            }
            else
                MessageBox.Show("Added Faild!");
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedImagePath = openFileDialog.FileName;

                pictureBox9.Image = Image.FromFile(SelectedImagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Optional: scale the image
            }

            linkLabel2.Visible = true;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (radioButton1.Checked)
                pictureBox9.Image = Properties.Resources.Male_512;
            else
                pictureBox9.Image = Properties.Resources.Female_512;

            SelectedImagePath = "";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (SelectedImagePath == "")
                pictureBox9.Image = Properties.Resources.Male_512;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (SelectedImagePath == "")
                pictureBox9.Image = Properties.Resources.Female_512;
        }
    }
}
