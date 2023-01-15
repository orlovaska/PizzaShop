using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;


namespace ShopWPFUI.ViewModels
{
    internal class MainViewModel: BaseViewModel
    {
        public NavigationStore _navigationStore { get; set; }
        private BaseViewModel _currentViewModel => _navigationStore.CurrentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            //set { _currentView = value; OnPropertyChanged(); }
        }

        //public ICommand AutorizationCommand { get; }
        //public ICommand RegistrationCommand { get; }
        //public ICommand NovigationCommand { get;  }


        //private void Autorization(object obj) => CurrentView = new AuthorizationViewModel();
        //private void Registration(object obj) => CurrentView = new RegistrationViewModel();
        //private void Navigation(object obj) => CurrentView = new NavigationViewModel();

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            //RegistrationCommand = new RelayCommand(Registration);
            //NovigationCommand = new RelayCommand(Navigation);
            //AutorizationCommand = new RelayCommand(Autorization);

            // Startup Page
            //CurrentView = new AuthorizationViewModel(_navigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
