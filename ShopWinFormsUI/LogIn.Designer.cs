
namespace ShopWinFormsUI
{
    partial class LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.loginText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelEnter = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBoxOpenEye = new System.Windows.Forms.PictureBox();
            this.pictureBoxCloseEye = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseEye)).BeginInit();
            this.SuspendLayout();
            // 
            // loginText
            // 
            this.loginText.AutoSize = true;
            this.loginText.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginText.Location = new System.Drawing.Point(53, 100);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(101, 38);
            this.loginText.TabIndex = 0;
            this.loginText.Text = "Логин:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLogin.Location = new System.Drawing.Point(191, 111);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(179, 38);
            this.textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(191, 182);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(179, 38);
            this.textBoxPassword.TabIndex = 3;
            // 
            // LabelEnter
            // 
            this.LabelEnter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LabelEnter.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelEnter.Location = new System.Drawing.Point(208, 236);
            this.LabelEnter.Name = "LabelEnter";
            this.LabelEnter.Size = new System.Drawing.Size(146, 62);
            this.LabelEnter.TabIndex = 4;
            this.LabelEnter.Text = "Войти";
            this.LabelEnter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelEnter.Click += new System.EventHandler(this.EnterLabel_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(218, 311);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 20);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ещё нет аккаута?";
            // 
            // pictureBoxOpenEye
            // 
            this.pictureBoxOpenEye.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxOpenEye.Image")));
            this.pictureBoxOpenEye.InitialImage = null;
            this.pictureBoxOpenEye.Location = new System.Drawing.Point(390, 182);
            this.pictureBoxOpenEye.Name = "pictureBoxOpenEye";
            this.pictureBoxOpenEye.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxOpenEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOpenEye.TabIndex = 6;
            this.pictureBoxOpenEye.TabStop = false;
            // 
            // pictureBoxCloseEye
            // 
            this.pictureBoxCloseEye.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCloseEye.Image")));
            this.pictureBoxCloseEye.Location = new System.Drawing.Point(390, 182);
            this.pictureBoxCloseEye.Name = "pictureBoxCloseEye";
            this.pictureBoxCloseEye.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxCloseEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCloseEye.TabIndex = 7;
            this.pictureBoxCloseEye.TabStop = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 374);
            this.Controls.Add(this.pictureBoxCloseEye);
            this.Controls.Add(this.pictureBoxOpenEye);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.LabelEnter);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginText);
            this.Name = "LogIn";
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label LabelEnter;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBoxOpenEye;
        private System.Windows.Forms.PictureBox pictureBoxCloseEye;
    }
}

