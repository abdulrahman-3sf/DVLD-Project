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
        private ManagePeople managePeopleForm;

        public Main()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (managePeopleForm == null || managePeopleForm.IsDisposed)
            {
                managePeopleForm = new ManagePeople();
                managePeopleForm.MdiParent = this;

                // Center the form inside the MDI parent
                managePeopleForm.StartPosition = FormStartPosition.Manual;
                managePeopleForm.Location = new Point(
                    (this.ClientSize.Width - managePeopleForm.Width) / 2,
                    (this.ClientSize.Height - managePeopleForm.Height) / 2 - 40);

                managePeopleForm.Show();
            }
        }
    }
}
