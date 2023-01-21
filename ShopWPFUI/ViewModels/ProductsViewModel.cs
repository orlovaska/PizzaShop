using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    internal class ProductsViewModel
    {
        public CategoryModel SelectedCatedory { get; set; }
        public List<ProductModel> Products { get; set; }

        public ICommand AddToCartCommand { get; }
        private IDataConnection DataRepository { get; set; }

        public ProductsViewModel(CategoryModel SelectedCatedory)
        {
            DataRepository = new DataRepository();
            Products = DataRepository.GetProductsFromCategory(SelectedCatedory);
            //Products = DataRepository.GetProducts_All();
        }
    }
}
