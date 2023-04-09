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
using static ShopWPFUI.ViewModels.CustomerViewModels.CartViewModel;

namespace ShopWPFUI.ViewModels.CustomerViewModels
{
    internal class PlaceOrderViewModel : BaseViewModel
    {
        public event EventHandler CartsIsCleared;

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

        public int NumberOfProducts { get; set; }
        public string Comment { get; set; }

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }

            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ICommand PlaceOrderCommand { get; }
        private IDataConnection DataRepository { get; }

        public PlaceOrderViewModel(CustomerModel currentCustomerAccount, decimal totalPrice, int numberOfProduct)
        {
<<<<<<< HEAD:ShopWPFUI/ViewModels/CustomerViewModels/PlaceOrderViewModel.cs
            NumberOfProducts = numberOfProduct;
=======
>>>>>>> parent of 2bed7ef (Убрал конфликты и соединил ветки):ShopWPFUI/ViewModels/PlaceOrderViewModel.cs
            CurrentCustomerAccount = currentCustomerAccount;
            TotalPrice = totalPrice;
            DataRepository = new DataRepository();

            PlaceOrderCommand = new RelayCommand(PlaceOrder);
        }

        private void PlaceOrder(object obj)
        {
            OrderModel order = new OrderModel
            {
                OrderPlaced = DateTime.Now,
                StatusId = 1,
                Customer = CurrentCustomerAccount,
                Comment = Comment
            };

            OrderModel orderInDB = DataRepository.AddOrder(CurrentCustomerAccount, order);
            DataRepository.AddOrderDetailsFromCarts(orderInDB, DataRepository.GetCartByCustomer(CurrentCustomerAccount));

            DataRepository.DeleteAllCartsByCustomer(CurrentCustomerAccount);
            CartsIsCleared?.Invoke(this, EventArgs.Empty);


        }

    }
}
