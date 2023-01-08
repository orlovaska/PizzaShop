
namespace ShopWinFormsUI
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.pictureBoxCloseEye = new System.Windows.Forms.PictureBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.pictureBoxOpenEye = new System.Windows.Forms.PictureBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirsName = new System.Windows.Forms.Label();
            this.buttonRegistration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenEye)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCloseEye
            // 
            this.pictureBoxCloseEye.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCloseEye.Image")));
            this.pictureBoxCloseEye.Location = new System.Drawing.Point(420, 198);
            this.pictureBoxCloseEye.Name = "pictureBoxCloseEye";
            this.pictureBoxCloseEye.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxCloseEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCloseEye.TabIndex = 13;
            this.pictureBoxCloseEye.TabStop = false;
            this.pictureBoxCloseEye.Click += new System.EventHandler(this.pictureBoxCloseEye_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(221, 198);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(179, 38);
            this.textBoxPassword.TabIndex = 11;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxEmail.Location = new System.Drawing.Point(221, 154);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(179, 38);
            this.textBoxEmail.TabIndex = 10;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(66, 196);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(118, 38);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Пароль:";
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelEmail.Location = new System.Drawing.Point(83, 152);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(89, 38);
            this.LabelEmail.TabIndex = 8;
            this.LabelEmail.Text = "Email:";
            // 
            // pictureBoxOpenEye
            // 
            this.pictureBoxOpenEye.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxOpenEye.Image")));
            this.pictureBoxOpenEye.InitialImage = null;
            this.pictureBoxOpenEye.Location = new System.Drawing.Point(420, 198);
            this.pictureBoxOpenEye.Name = "pictureBoxOpenEye";
            this.pictureBoxOpenEye.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxOpenEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOpenEye.TabIndex = 14;
            this.pictureBoxOpenEye.TabStop = false;
            this.pictureBoxOpenEye.Click += new System.EventHandler(this.pictureBoxOpenEye_Click);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLastName.Location = new System.Drawing.Point(221, 110);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(179, 38);
            this.textBoxLastName.TabIndex = 16;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLastName.Location = new System.Drawing.Point(46, 108);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(138, 38);
            this.labelLastName.TabIndex = 15;
            this.labelLastName.Text = "Фамилия:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxFirstName.Location = new System.Drawing.Point(221, 66);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(179, 38);
            this.textBoxFirstName.TabIndex = 18;
            // 
            // labelFirsName
            // 
            this.labelFirsName.AutoSize = true;
            this.labelFirsName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFirsName.Location = new System.Drawing.Point(106, 64);
            this.labelFirsName.Name = "labelFirsName";
            this.labelFirsName.Size = new System.Drawing.Size(78, 38);
            this.labelFirsName.TabIndex = 17;
            this.labelFirsName.Text = "Имя:";
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRegistration.Location = new System.Drawing.Point(155, 283);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(288, 62);
            this.buttonRegistration.TabIndex = 19;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 423);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirsName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.LabelEmail);
            this.Controls.Add(this.pictureBoxOpenEye);
            this.Controls.Add(this.pictureBoxCloseEye);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCloseEye;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.PictureBox pictureBoxOpenEye;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirsName;
        private System.Windows.Forms.Button buttonRegistration;
    }
}