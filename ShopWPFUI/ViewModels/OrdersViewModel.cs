using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    internal class OrdersViewModel : BaseViewModel
    {
        private CustomerModel _currentCustomerAccount;
        private int _widthOrderFulfilledColumn;
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

        public int WidthOrderFulfilledColumn
        {
            get
            {
                return _widthOrderFulfilledColumn;
            }
            set
            {
                _widthOrderFulfilledColumn = value;
                OnPropertyChanged(nameof(WidthOrderFulfilledColumn));
            }
        }

        public OrderModel SelectedOrder { get; set; }

        public ObservableCollection<OrderModel> CurrentListOrders { get; set; }

        public List<OrderModel> ActiveOrders { get; set; }
        public List<OrderModel> CompletedOrders { get; set; }


        private IDataConnection DataRepository { get; set; }
        public ICommand ActiveOrdersCommand { get; }
        public ICommand CompletedOrdersCommand { get; }


        public OrdersViewModel(CustomerModel currentCustomerAccount)
        {
            DataRepository = new DataRepository();
            CurrentCustomerAccount = currentCustomerAccount;

            ActiveOrders = DataRepository.GetActiveOrdersByCustomer(CurrentCustomerAccount);
            CurrentListOrders = new ObservableCollection<OrderModel>(ActiveOrders);
            CompletedOrders = DataRepository.GetCompletedOrdersByCustomer(CurrentCustomerAccount);

            ActiveOrdersCommand = new RelayCommand(ShowActiveOrders);
            CompletedOrdersCommand = new RelayCommand(ShowCompletedOrders);

            WidthOrderFulfilledColumn = 0;
        }

        private void ShowCompletedOrders(object obj)
        {
            WidthOrderFulfilledColumn = 140;
            CurrentListOrders.Clear();
            foreach(var order in CompletedOrders)
                CurrentListOrders.Add(order);
        }

        private void ShowActiveOrders(object obj)
        {
            WidthOrderFulfilledColumn = 0;
            CurrentListOrders.Clear();
            foreach (var order in ActiveOrders)
                CurrentListOrders.Add(order);
        }
    }
}
