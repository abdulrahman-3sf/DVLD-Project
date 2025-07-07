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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private clsPeople _Person;
        private int _PersonID = -1;

        public clsPeople PersonInfo
        {
            get { return ctrlPersonCard1.PersonInfo; }
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        private bool _ShowAddPerson = true;
        private bool _FilterEnable = true;

        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                button2.Visible = _ShowAddPerson;
            }
        }

        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set
            {
                _FilterEnable = value;
                groupBox1.Enabled = _FilterEnable;
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Focus();
        }

        public void FindNow()
        {
            switch (comboBox1.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(textBox1.Text));
                    break;

                case "National No":
                    ctrlPersonCard1.LoadPersonInfo(textBox1.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnable)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            comboBox1.SelectedIndex = 1;
            textBox1.Text = PersonID.ToString();
            FindNow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo form = new frmAddEditPersonInfo();
            form.DataBack += DataBackEvent;
            form.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            comboBox1.SelectedIndex = 1;
            textBox1.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
