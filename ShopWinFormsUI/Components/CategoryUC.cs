using System;
using System.Collections.Generic;
using ShopWinFormsUI;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzaShop.Models;
using PizzaShop.DataAccess;
using System.IO;
using ShopLibrary;

namespace ShopWinFormsUI
{
    public partial class CategoryUC : UserControl
    {
        public event EventHandler<string> ChoosingСategoryEvent;

        public CategoryUC()
        {
            InitializeComponent();
        }
        private string name;
        private PictureBox image;

        [Category("Custom Props")]
        public string Name
        {
            get { return name; }
            set { labelName.Text = value; }
        }
        [Category("Custom Props")]
        public PictureBox Image 
        {
            get { return pictureBoxImage; }
            set { pictureBoxImage = value; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChoosingСategoryEvent?.Invoke(this, labelName.Text);         
        }

    }
}
