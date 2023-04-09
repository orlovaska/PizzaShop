using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels.CustomerViewModels
{
    public class ProfileViewModel : BaseViewModel
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

        private IDataConnection dataRepository { get; set; }

        public ProfileViewModel(CustomerModel currentCustomerAccount)
        {
            CurrentCustomerAccount = currentCustomerAccount;
        }
    }
}
