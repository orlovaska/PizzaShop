using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
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

        private void buttonEnter_Click(object sender, EventArgs e)
        {

            Catalog catalog = new Catalog();
            //catalog.AddCategory_All();
            catalog.Show();
            this.Hide();
        }

        public bool AvailabilityEmailInDb(string email)
        {
            List<string> customer = new List<string>();

            foreach (IDataConnection db in GlobalConfig.Connections)
            {
                customer = db.GetCustomersEmail_All();
            }
            return customer.Contains(email);
        }

        public bool PasswordVerification(string email, string password)
        {
            bool output = false;
            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (IDataConnection db in GlobalConfig.Connections)
            {
                customers = db.GetCustomers_All();
            }

            foreach (CustomerModel customer in customers)
            {
                if (customer.Email == email && customer.HashPassword == HashingUntil.HashingPassword(password))
                    output = true;
            }
            return output;
        }
    }
}
