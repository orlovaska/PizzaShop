using PizzaShop.Models;
using System;
using PizzaShop.DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopLibrary;

namespace ShopWinFormsUI
{
    public partial class Catalog : Form
    {
        public Catalog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            AddCategory_All();
            ButtonBackActive(false);
        }

        private void ButtonBackActive(bool active)
        {
            button6.Visible = active;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            ButtonBackActive(false);
            AddCategory_All();
        }

        public void AddCategory_All()
        {

            List<CategoryModel> categories = new List<CategoryModel>();
            //foreach (IDataConnection db in GlobalConfig.Connections)
            //{
            //    categories = db.GetCategories_All();
            //}

            foreach (var category in categories)
            {
                AddCategory(category);
            }
        }
        public void AddProducts_All()
        {
            List<ProductModel> products = new List<ProductModel>();
            //foreach (IDataConnection db in GlobalConfig.Connections)
            //{
            //    products = db.GetProducts_All();
            //}

            foreach (var product in products)
            {
                AddProduct(product.Name, ImageFromByteArr(product.Image));
            }
        }
        public void AddProducts_FromCategory(CategoryModel category)
        {
            List<ProductModel> products = new List<ProductModel>();
            //foreach (IDataConnection db in GlobalConfig.Connections)
            //{
            //    products = db.GetProductsFromCategory(category);
            //}

            foreach (var product in products)
            {
                AddProduct(product.Name, ImageFromByteArr(product.Image));
            }
        }

        public void AddProduct(string nameProduct, Image imageProduct)
        {
            ProductUC userControlProduct = new ProductUC();
            userControlProduct.ImageProduct.BackgroundImageLayout = ImageLayout.Stretch;
            userControlProduct.ImageProduct.BackgroundImage = imageProduct;

            userControlProduct.NameProduct = nameProduct;
            flowLayoutPanel2.Controls.Add(userControlProduct);
        }

        public void AddCategory(CategoryModel category)
        {
            CategoryUC userControlProduct = new CategoryUC(category);

            userControlProduct.ChoosingСategoryEvent += UserControlProduct_ChoosingСategoryEvent;

            flowLayoutPanel2.Controls.Add(userControlProduct);
        }

        private void UserControlProduct_ChoosingСategoryEvent(object sender, CategoryModel e)
        {
            flowLayoutPanel2.Controls.Clear();
            ButtonBackActive(true);
            AddProducts_FromCategory(e);
        }
        public Image ImageFromByteArr(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Bitmap bitmap = new Bitmap(memoryStream);
            return bitmap;
        }

        
    }

}
