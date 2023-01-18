using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels
{
    internal class OrdersViewModel : BaseViewModel
    {
        public List<OrderModel> ActiveOrders { get; set; }
        public List<OrderModel> CompletedOrders { get; set; }


        public OrdersViewModel()
        {
            //foreach (IDataConnection db in GlobalConfig.Connections)
            //{
            //    ActiveOrders = db.GetCategories_All();
            //}

            //foreach (IDataConnection db in GlobalConfig.Connections)
            //{
            //    CompletedOrders = db.GetCategories_All();
            //}

        }
    }
}
