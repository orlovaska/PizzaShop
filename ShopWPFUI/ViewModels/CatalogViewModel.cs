using PizzaShop.Models;
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

        public CatalogViewModel()
        {

        }
    }
}
