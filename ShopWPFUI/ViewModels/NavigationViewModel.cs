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


        private int _numberOfProductCars;
        public int NumberOfProductCars
        {
            get
            {
                return _numberOfProductCars;
            }

            set
            {
                _numberOfProductCars = value;
                OnPropertyChanged(nameof(NumberOfProductCars));
            }
        }



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
        public ICommand LogoutCommand { get; }


        private void Profil(object obj) => CurrentView = new ProfileViewModel(CurrentCustomerAccount);
        private void Orders(object obj) => CurrentView = new OrdersViewModel(CurrentCustomerAccount);
        private void Catalog(object obj)
        {
            CatalogViewModel catalogViewModel = new CatalogViewModel();
            catalogViewModel.onCount += Products;
            CurrentView = catalogViewModel;
        }
        private void Cart(object obj)
        {
            if (NumberOfProductCars > 0)
            {
                CartViewModel cartViewModel = new CartViewModel(CurrentCustomerAccount);
                CurrentView = cartViewModel;
                cartViewModel.QuantityChange += Cart_QuantityChange;
                cartViewModel.ContinueMakingOrder += Cart_ContinueMakingOrder;
            }
            else
            {
                EmptyCartViewModel emptyCartViewModel = new EmptyCartViewModel();
                CurrentView = emptyCartViewModel;
                emptyCartViewModel.ShowsCatalog += EmptyCartViewModel_ShowsCatalog;
            }

        }

        private void EmptyCartViewModel_ShowsCatalog(object? sender, EventArgs e)
        {
            CartViewModel cartViewModel = new CartViewModel(CurrentCustomerAccount);
            CurrentView = cartViewModel;
            cartViewModel.QuantityChange += Cart_QuantityChange;
            cartViewModel.ContinueMakingOrder += Cart_ContinueMakingOrder;
        }

        private void Cart_ContinueMakingOrder(decimal totalPrice)
        {
            PlaceOrderViewModel placeOrderViewModel = new PlaceOrderViewModel(CurrentCustomerAccount, totalPrice);
            CurrentView = placeOrderViewModel;
            placeOrderViewModel.CartsIsCleared += CartsIsCleared;
        }

        private void CartsIsCleared(object? sender, EventArgs e)
        {
            NumberOfProductCars = 0;
        }

        private void Products(CategoryModel SelectedCatedory)
        {
            ProductsViewModel productsViewModel = new ProductsViewModel(CurrentCustomerAccount, SelectedCatedory);
            CurrentView = productsViewModel;
            productsViewModel.QuantityChange += Cart_QuantityChange;
        }

        private void Cart_QuantityChange(int productQuantityDifference)
        {
            NumberOfProductCars += productQuantityDifference;
        }

        public NavigationViewModel(NavigationStore navigationStore)
        {
            dataRepository = new DataRepository();
            CurrentCustomerAccount = new CustomerModel();

            LoadCurrentUserData();
            NumberOfProductCars = dataRepository.GetCartByCustomer(CurrentCustomerAccount).Sum(x => x.Quntity);

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
