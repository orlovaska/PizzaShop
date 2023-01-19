using PizzaShop.DataAccess;
using PizzaShop.Migrations;
using PizzaShop.Models;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels
{
    internal class CatalogViewModel : BaseViewModel
    {
        public List<CategoryModel> Categories { get; set; }
        public List<ProductModel> Products { get; set; }

        private IDataConnection dataRepository { get; set; }

        public CatalogViewModel()
        {
            dataRepository = new DataRepository();
            Categories = dataRepository.GetCategories_All();
        }
    }
}
