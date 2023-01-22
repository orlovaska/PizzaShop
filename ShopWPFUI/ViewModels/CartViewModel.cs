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
    internal class CartViewModel : BaseViewModel
    {
        private CartsModel _selectedCart;
        private CustomerModel _currentCustomerAccount;

        public List<CartsModel> Carts { get; set; }
        int numberOfProducts => Carts.Sum(x => x.Quntity);


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

        private IDataConnection DataRepository { get; set; }

        public CartViewModel(CustomerModel _currentCustomerAccount)
        {
            CurrentCustomerAccount = _currentCustomerAccount;
            DataRepository = new DataRepository();
            Carts = DataRepository.GetCartByCustomer(CurrentCustomerAccount);
        }

    }
}
