using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;

namespace ShopWPFUI.ViewModels.CustomerViewModels
{
    internal class CartViewModel : BaseViewModel
    {
        public delegate void AccountHandler(int productQuantityDifference);
        public event AccountHandler QuantityChange;

        public delegate void MakingOrderHandler(decimal totalPrice);
        public event MakingOrderHandler ContinueMakingOrder;


        private CartsModel _selectedCart;
        private CustomerModel _currentCustomerAccount;

        public ObservableCollection<CartsModel> Carts { get; set; }

        private decimal _totalPrice;
        public decimal TotalPrice {
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
        public CartsModel SelectedCart 
        {
            get
            {
                return _selectedCart;
            }

            set
            {
                _selectedCart = value;
                OnPropertyChanged(nameof(SelectedCart));
            }
        }

        public ICommand DeleteProductFromCartCommand { get;}
        public ICommand IncreaseQuntityOfProductInCartCommand { get; }
        public ICommand ReduceQuntityOfProductInCartCommand { get; }
        public ICommand ContinueMakingOrderCommand { get;  }
        private IDataConnection DataRepository { get;}

        public CartViewModel(CustomerModel currentCustomerAccount)
        {
            CurrentCustomerAccount = currentCustomerAccount;
            DataRepository = new DataRepository();
            Carts = new ObservableCollection<CartsModel>(DataRepository.GetCartByCustomer(CurrentCustomerAccount));
            TotalPrice = Carts.Sum(p => p.Price);

            DeleteProductFromCartCommand = new RelayCommand(DeleteProduct);
            IncreaseQuntityOfProductInCartCommand = new RelayCommand(IncreaseQuntityOfProduct);
            ReduceQuntityOfProductInCartCommand = new RelayCommand(ReduceQuntityOfProduct);

            ContinueMakingOrderCommand = new RelayCommand(OnContinueMakingOrder);
        }

        private void RecalculateTotaPrice()
        {
            TotalPrice = Carts.Sum(p => p.Price);
        }

        private void OnContinueMakingOrder(object obj)
        {
            ContinueMakingOrder?.Invoke(TotalPrice);
        }

        private void DeleteProduct(object obj)
        {
            var itemToRemove = Carts.SingleOrDefault(r => r.Id == SelectedCart.Id);
            if (itemToRemove != null)
            {
                DataRepository.DeleteFromCart(CurrentCustomerAccount, SelectedCart.Product);
                Carts.Remove(itemToRemove);

                QuantityChange?.Invoke(-itemToRemove.Quntity);
                RecalculateTotaPrice();
            }
        }

        public void ReduceQuntityOfProduct(object obj)
        {
            if (SelectedCart.Quntity > 1)
            {
                DataRepository.ReduceQuntityOfProductFromCart(CurrentCustomerAccount, SelectedCart.Product);

                CartsModel cartsModel = SelectedCart;
                int index = Carts.IndexOf(SelectedCart);
                Carts.RemoveAt(index);
                cartsModel.Quntity--;
                Carts.Insert(index, cartsModel);

                QuantityChange?.Invoke(-1);
                RecalculateTotaPrice();
            }
            else DeleteProductFromCartCommand.Execute(obj);

        }

        public void IncreaseQuntityOfProduct(object obj)
        {
            DataRepository.AddToCart(CurrentCustomerAccount, SelectedCart.Product);

            CartsModel cartsModel = SelectedCart;
            int index = Carts.IndexOf(SelectedCart);
            Carts.RemoveAt(index);
            cartsModel.Quntity++;
            Carts.Insert(index, cartsModel);

            QuantityChange?.Invoke(1);
            RecalculateTotaPrice();
        }
    }
}
