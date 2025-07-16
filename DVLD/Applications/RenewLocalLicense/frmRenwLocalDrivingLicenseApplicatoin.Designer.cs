namespace DVLD.Applications.RenewLocalLicense
{
    partial class frmRenwLocalDrivingLicenseApplicatoin
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
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD.Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.ctrlApplicationInfo1 = new DVLD.Applications.Controls.ctrlApplicationInfo();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRenewLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(875, 39);
            this.lblTitle.TabIndex = 177;
            this.lblTitle.Text = "Renew License Application";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 51);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(872, 414);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 178;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(19, 462);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(896, 220);
            this.ctrlApplicationInfo1.TabIndex = 179;
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(210, 695);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(123, 13);
            this.llShowLicenseInfo.TabIndex = 186;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show New Licenses Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Location = new System.Drawing.Point(27, 695);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(113, 13);
            this.llShowLicenseHistory.TabIndex = 185;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show Licenses History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnRenewLicense
            // 
            this.btnRenewLicense.Enabled = false;
            this.btnRenewLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenewLicense.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.btnRenewLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenewLicense.Location = new System.Drawing.Point(782, 688);
            this.btnRenewLicense.Name = "btnRenewLicense";
            this.btnRenewLicense.Size = new System.Drawing.Size(126, 37);
            this.btnRenewLicense.TabIndex = 184;
            this.btnRenewLicense.Text = " Renew";
            this.btnRenewLicense.UseVisualStyleBackColor = true;
            this.btnRenewLicense.Click += new System.EventHandler(this.btnRenewLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(648, 688);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 183;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRenwLocalDrivingLicenseApplicatoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 734);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnRenewLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmRenwLocalDrivingLicenseApplicatoin";
            this.Text = "frmRenwLocalDrivingLicenseApplicatoin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private Controls.ctrlApplicationInfo ctrlApplicationInfo1;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnRenewLicense;
        private System.Windows.Forms.Button btnClose;
    }
}