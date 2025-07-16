namespace DVLD.Licenses.International_Licenses
{
    partial class frmShowInternationalLicenseInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlDriverInternationalLicenseInfo1 = new DVLD.Licenses.International_Licenses.ctrlDriverInternationalLicenseInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(192, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 39);
            this.lblTitle.TabIndex = 139;
            this.lblTitle.Text = "Driver International License Info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverInternationalLicenseInfo1
            // 
            this.ctrlDriverInternationalLicenseInfo1.Location = new System.Drawing.Point(12, 84);
            this.ctrlDriverInternationalLicenseInfo1.Name = "ctrlDriverInternationalLicenseInfo1";
            this.ctrlDriverInternationalLicenseInfo1.Size = new System.Drawing.Size(865, 270);
            this.ctrlDriverInternationalLicenseInfo1.TabIndex = 140;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(741, 362);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 141;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 408);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDriverInternationalLicenseInfo1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmShowInternationalLicenseInfo";
            this.Text = "frmShowInternationalLicenseInfo";
            this.Load += new System.EventHandler(this.frmShowInternationalLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ctrlDriverInternationalLicenseInfo ctrlDriverInternationalLicenseInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}