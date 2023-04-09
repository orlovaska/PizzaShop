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

namespace ShopWPFUI.ViewModels.CustomerViewModels
{
    internal class OrderViewModel : BaseViewModel
    {
        public delegate void AccountHandler(int productQuantityDifference);
        public event AccountHandler QuantityChange;

        public OrderModel SelectedOrder { get; set; }
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
        private IDataConnection dataRepository { get; set; }

        public ICommand RepeatOrderCommand { get; }

        public OrderViewModel(CustomerModel currentCustomerAccount, OrderModel selectedOrder)
        {
            dataRepository = new DataRepository();

            SelectedOrder = selectedOrder;
            foreach (var orderDetail in SelectedOrder.OrderDetails)
            {
                orderDetail.Product = dataRepository.GetProductById(orderDetail.ProductId);
            }
            CurrentCustomerAccount = currentCustomerAccount;
            RepeatOrderCommand = new RelayCommand(RepeatOrder);

        }

        private void RepeatOrder(object obj)
        {
            dataRepository.AddToCartFromSelectedOrderDetails(CurrentCustomerAccount, SelectedOrder.OrderDetails);
            QuantityChange?.Invoke(SelectedOrder.OrderDetails.Sum(p => p.Quntity));

        }
    }
}
