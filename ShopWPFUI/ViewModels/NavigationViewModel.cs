using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;


namespace ShopWPFUI.ViewModels
{
    internal class NavigationViewModel: BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ProfilCommand { get;  }
        public ICommand OrdersCommand { get;  }
        public ICommand CatalogCommand { get; }
        public ICommand CartCommand { get; }


        private void Profil(object obj) => CurrentView = new ProfileViewModel();
        private void Orders(object obj) => CurrentView = new OrdersViewModel();
        private void Catalog(object obj) => CurrentView = new CatalogViewModel();
        private void Cart(object obj) => CurrentView = new CartViewModel();

        public NavigationViewModel(NavigationStore navigationStore)
        {
            ProfilCommand = new RelayCommand(Profil);
            OrdersCommand = new RelayCommand(Orders);
            CatalogCommand = new RelayCommand(Catalog);
            CartCommand = new RelayCommand(Cart);

            // Startup Page
            CurrentView = new ProfileViewModel();

        }
    }
}
