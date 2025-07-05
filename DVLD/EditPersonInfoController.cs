using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Shared;

namespace DVLD
{
    public partial class EditPersonInfoController : UserControl
    {
        public EditPersonInfoController()
        {
            InitializeComponent();
        }

        public int PersonID;

        private void EditPersonInfoController_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            // Set maximum date to 18 years ago from today
            dateTimePicker2.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker2.Value = dateTimePicker2.MaxDate;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox9.Image = Properties.Resources.Male_512;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox9.Image = Properties.Resources.Female_512;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (radioButton1.Checked)
                pictureBox9.Image = Properties.Resources.Male_512;
            else
                pictureBox9.Image = Properties.Resources.Female_512;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Get the parent form that hosts this control
            if (parentForm != null)
            {
                parentForm.Close(); // Close the form
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DVLD_Buisness.clsPeople person = new clsPeople();
            person.NationalNo = textBox2.Text;
            person.FirstName = textBox1.Text;
            person.SecondName = textBox6.Text;
            person.ThirdName = textBox7.Text;
            person.LastName = textBox8.Text;
            person.DateOfBirth = dateTimePicker2.Value;
            if (radioButton1.Checked)
                person.Gender = (DVLD_Buisness.clsPeople.enGender)Convert.ToInt32(radioButton1.Tag);
            else
                person.Gender = (DVLD_Buisness.clsPeople.enGender)Convert.ToInt32(radioButton2.Tag);
            person.Address = textBox5.Text;
            person.Phone = textBox10.Text;
            person.Email = textBox4.Text;
            person.Nationality = Convert.ToInt32(textBox3.Text);
            person.ImagePath = "";

            if (person.Save())
                MessageBox.Show("Added Seccessfully!" + person.PersonID);
            else
                MessageBox.Show("Added Faild!");

            PersonID = person.PersonID;
        }
    }
}
