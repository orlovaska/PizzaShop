using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public OrderModel SelectedOrder { get; set; }

        public List<OrderModel> CurrentListOrders { get; set; }

        public List<OrderModel> ActiveOrders { get; set; }
        public List<OrderModel> CompletedOrders { get; set; }


        private IDataConnection DataRepository { get; set; }
        public ICommand ActiveOrdersCommand { get; }
        public ICommand CompletedOrdersCommand { get; }


        public OrdersViewModel(CustomerModel currentCustomerAccount)
        {
            DataRepository = new DataRepository();
            CurrentCustomerAccount = currentCustomerAccount;

            ActiveOrders = DataRepository.GetActiveOrders(CurrentCustomerAccount);
            CompletedOrders = DataRepository.GetCompletedOrders(CurrentCustomerAccount);

            ActiveOrdersCommand = new RelayCommand(ShowActiveOrders);
            CompletedOrdersCommand = new RelayCommand(ShowCompletedOrders);


        }

        private void ShowCompletedOrders(object obj)
        {
            CurrentListOrders = CompletedOrders;
        }

        private void ShowActiveOrders(object obj)
        {
            CurrentListOrders = ActiveOrders;
        }
    }
}
