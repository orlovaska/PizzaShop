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
    public partial class ProductUC : UserControl
    {
        public ProductUC()
        {
            InitializeComponent();
        }

        private string nameProduct;
        private string nameCategory;
        private PictureBox imageProduct;


        [Category("Custom Props")]
        public string NameProduct
        {
            get { return nameProduct; }
            set { nameProduct = value; labelName.Text = value; }
        }
        [Category("Custom Props")]
        public PictureBox ImageProduct
        {
            get { return pictureBoxImage; }
            set { pictureBoxImage = value; }
        }
        [Category("Custom Props")]
        public string NameCategory
        {
            get { return nameCategory; }
            set { nameCategory = value; }
        }
    }
}
