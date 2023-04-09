using ShopLibrary;
using PizzaShop.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using PizzaShop.Models;

namespace ShopWinFormsUI
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LabelRegistration_Load(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '•';
            pictureBoxOpenEye.Visible = false;
            textBoxEmail.MaxLength = 100;
            textBoxPassword.MaxLength = 100;
        }

        private void pictureBoxCloseEye_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxCloseEye.Visible = false;
            pictureBoxOpenEye.Visible = true;
        }


        private void pictureBoxOpenEye_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxCloseEye.Visible = true;
            pictureBoxOpenEye.Visible = false;
        }

        public bool ValidForm()
        {
            
            bool output = true;
            if (textBoxFirstName.Text.Length == 0)
            {
                output = false;
            }
            if (textBoxLastName.Text.Length == 0)
            {
                output = false;
            }

            if (textBoxPassword.Text.Length == 0)
            {
                output = false;
            }
            if (!IsValidEmail(textBoxEmail.Text))
            {
                output = false;
            }
            return output;
        }

        public static bool IsValidEmail(string email)
        {
            var emailAddressAtr = new EmailAddressAttribute();
            return emailAddressAtr.IsValid(email);
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (ValidForm())
            {
                CustomerModel customer = new CustomerModel(
                    textBoxFirstName.Text,
                    textBoxLastName.Text,
                    HashingUtility.HashingPassword(textBoxPassword.Text),
                    textBoxEmail.Text);

                //foreach (IDataConnection db in GlobalConfig.Connections)
                //{
                //    db.CreateCustomer(customer);
                //}

                Catalog catalog = new Catalog();
                catalog.AddCategory_All();
                catalog.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Форма содержит неверную информацию. Пожалуйста, проверьте данные и попробуйте ещё раз");
            }
        }
    }
}
