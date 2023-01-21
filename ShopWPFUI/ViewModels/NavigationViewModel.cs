using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    internal class NavigationViewModel: BaseViewModel
    {

        private object _currentView;
        private CustomerModel _currentCustomerAccount;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
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

        private IDataConnection dataRepository { get; set; }

        public ICommand ProfilCommand { get;  }
        public ICommand OrdersCommand { get;  }
        public ICommand CatalogCommand { get; }
        public ICommand CartCommand { get; }
        public ICommand NavigateAuthorizationCommand { get; }
        public ICommand ProductsCommand { get; }


        private void Profil(object obj) => CurrentView = new ProfileViewModel(CurrentCustomerAccount);
        private void Orders(object obj) => CurrentView = new OrdersViewModel(CurrentCustomerAccount);
        private void Catalog(object obj)
        {
            CatalogViewModel catalogViewModel = new CatalogViewModel();
            catalogViewModel.onCount += Products;
            CurrentView = catalogViewModel;
        }
        private void Cart(object obj) => CurrentView = new CartViewModel(CurrentCustomerAccount);
        private void Products(CategoryModel SelectedCatedory)
        {
            CurrentView = new ProductsViewModel(CurrentCustomerAccount, SelectedCatedory);
        }

        public NavigationViewModel(NavigationStore navigationStore)
        {
            dataRepository = new DataRepository();
            CurrentCustomerAccount = new CustomerModel();

            LoadCurrentUserData();

            ProfilCommand = new RelayCommand(Profil);
            OrdersCommand = new RelayCommand(Orders);
            CatalogCommand = new RelayCommand(Catalog);
            CartCommand = new RelayCommand(Cart);
            //ProductsCommand = new RelayCommand(Products);
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore, () => new AuthorizationViewModel(navigationStore));


            // Startup Page
            CurrentView = new ProfileViewModel(CurrentCustomerAccount);

        }

        private void LoadCurrentUserData()
        {
            var customer = dataRepository.GetByEmail(Thread.CurrentPrincipal.Identity.Name);
            if (customer != null)
            {
                CurrentCustomerAccount.Id = customer.Id;
                CurrentCustomerAccount.Email = customer.Email;
                CurrentCustomerAccount.FirstName = customer.FirstName;
                CurrentCustomerAccount.LastName = customer.LastName;
                CurrentCustomerAccount.Phone = customer.Phone;
            }
        }
    }
}
