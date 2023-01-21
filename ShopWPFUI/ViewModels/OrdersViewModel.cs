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
        private CustomerModel _currentCustomerAccount;
        public CustomerModel CurrentCustomerAccount
        {
            get
            {
                return _currentCustomerAccount;
            }

            set
            {
                _currentCustomerAccount = value;
                OnPropertyChanged(nameof(CurrentCustomerAccount));
            }
        }

        public List<OrderModel> ActiveOrders { get; set; }
        public List<OrderModel> CompletedOrders { get; set; }


        private IDataConnection DataRepository { get; set; }


        public OrdersViewModel(CustomerModel currentCustomerAccount)
        {
            DataRepository = new DataRepository();
            CurrentCustomerAccount = currentCustomerAccount;

            ActiveOrders = DataRepository.GetActiveOrders();
            CompletedOrders = DataRepository.GetCompletedOrders();
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
