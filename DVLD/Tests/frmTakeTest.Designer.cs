namespace DVLD.Tests
{
    partial class frmTakeTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakeTest));
            this.ctrlScheduledTest1 = new DVLD.Tests.Controls.ctrlScheduledTest();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlScheduledTest1
            // 
            this.ctrlScheduledTest1.Location = new System.Drawing.Point(2, 2);
            this.ctrlScheduledTest1.Name = "ctrlScheduledTest1";
            this.ctrlScheduledTest1.Size = new System.Drawing.Size(511, 399);
            this.ctrlScheduledTest1.TabIndex = 0;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.Location = new System.Drawing.Point(247, 404);
            this.lblUserMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(255, 20);
            this.lblUserMessage.TabIndex = 207;
            this.lblUserMessage.Text = "You cannot change the results";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUserMessage.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(129, 438);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(373, 70);
            this.txtNotes.TabIndex = 206;
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Location = new System.Drawing.Point(182, 403);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(41, 17);
            this.rbFail.TabIndex = 205;
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Checked = true;
            this.rbPass.Location = new System.Drawing.Point(129, 404);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(47, 17);
            this.rbPass.TabIndex = 204;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.Properties.Resources.Notes_32;
            this.pictureBox7.Location = new System.Drawing.Point(81, 436);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(17, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 203;
            this.pictureBox7.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 436);
            this.label10.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 202;
            this.label10.Text = "Notes:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(81, 400);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(17, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 201;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 400);
            this.label8.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 200;
            this.label8.Text = "Result:";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(457, 519);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 36);
            this.button2.TabIndex = 208;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(406, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 36);
            this.button1.TabIndex = 209;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 567);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.rbFail);
            this.Controls.Add(this.rbPass);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrlScheduledTest1);
            this.Name = "frmTakeTest";
            this.Text = "frmTakeTest";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlScheduledTest ctrlScheduledTest1;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}