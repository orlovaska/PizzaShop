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

namespace ShopWPFUI.ViewModels
{
    internal class CartViewModel : BaseViewModel
    {
        public delegate void AccountHandler(int productQuantityDifference);
        public event AccountHandler QuantityChange;


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

        public ICommand DeleteProductFromCart { get; set; }
        public ICommand IncreaseQuntityOfProductInCart { get; }
        public ICommand ReduceQuntityOfProductInCart { get; }

        public ICommand ContinueMakingOrderCommand { get; set; }
        private IDataConnection DataRepository { get; set; }

        public CartViewModel(CustomerModel _currentCustomerAccount)
        {
            CurrentCustomerAccount = _currentCustomerAccount;
            DataRepository = new DataRepository();
            Carts = new ObservableCollection<CartsModel>((DataRepository.GetCartByCustomer(CurrentCustomerAccount)));
            TotalPrice = Carts.Sum(p => p.Price);

            DeleteProductFromCart = new RelayCommand(DeleteProduct);
            IncreaseQuntityOfProductInCart = new RelayCommand(IncreaseQuntityOfProduct);
            ReduceQuntityOfProductInCart = new RelayCommand(ReduceQuntityOfProduct);

            ContinueMakingOrderCommand = new RelayCommand(ContinueMakingOrder);
        }

        private void RecalculateTotaPrice()
        {
            TotalPrice = Carts.Sum(p => p.Price);
        }

        private void ContinueMakingOrder(object obj)
        {
            throw new NotImplementedException();//TODO
        }

        private void DeleteProduct(object obj)
        {
            var itemToRemove = Carts.SingleOrDefault(r => r.Id == SelectedCart.Id);
            if (itemToRemove != null)
            {
                DataRepository.DeleteFromCart(CurrentCustomerAccount, SelectedCart.Product);
                Carts.Remove(itemToRemove);

                QuantityChange.Invoke(-itemToRemove.Quntity);
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

                QuantityChange.Invoke(-1);
                RecalculateTotaPrice();
            }
            else DeleteProductFromCart.Execute(obj);

        }

        public void IncreaseQuntityOfProduct(object obj)
        {
            DataRepository.AddToCart(CurrentCustomerAccount, SelectedCart.Product);

            CartsModel cartsModel = SelectedCart;
            int index = Carts.IndexOf(SelectedCart);
            Carts.RemoveAt(index);
            cartsModel.Quntity++;
            Carts.Insert(index, cartsModel);

            QuantityChange.Invoke(1);
            RecalculateTotaPrice();
        }
    }
}
