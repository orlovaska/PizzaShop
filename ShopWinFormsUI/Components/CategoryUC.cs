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
using Newtonsoft.Json.Linq;

namespace ShopWinFormsUI
{
    public partial class CategoryUC : UserControl
    {
        public event EventHandler<CategoryModel> ChoosingСategoryEvent;
        public CategoryModel Category { get; set; }

        public CategoryUC(CategoryModel category)
        {
            Category = category;
            InitializeComponent();
            labelName.Text = category.Name;
            pictureBoxImage.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxImage.BackgroundImage = ImageFromByteArr(category.Image);
        }

        [Category("Custom Props")]
        public PictureBox Image 
        {
            get { return pictureBoxImage; }
            set { pictureBoxImage = value; }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChoosingСategoryEvent?.Invoke(this, Category);         
        }

        public Image ImageFromByteArr(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Bitmap bitmap = new Bitmap(memoryStream);
            return bitmap;
        }

    }
}
