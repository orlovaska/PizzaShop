using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopWinFormsUI
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void EnterLabel_Load(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '•';
            pictureBoxOpenEye.Visible = false;
            textBoxLogin.MaxLength = 100;
            textBoxPassword.MaxLength = 100;
        }

        private void EnterLabel_Click(object sender, EventArgs e)
        {
            var loginUser = textBoxLogin.Text;
            var passwordUser = textBoxPassword.Text;

            if (true)
            {
                MessageBox.Show("Авторизация успешна");
            }
            else
            {
                MessageBox.Show("Аккаунт не найден!");
            }
        }
    }
}
