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
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand AutorizationCommand { get; }
        public ICommand RegistrationCommand { get;}
        public ICommand NovigationCommand { get;}


        private void Autorization(object obj) => CurrentView = new AuthorizationViewModel();
        private void Registration(object obj) => CurrentView = new RegistrationViewModel();
        private void Navigation(object obj) => CurrentView = new NavigationViewModel();

        public MainViewModel()
        {
            RegistrationCommand = new RelayCommand(Registration);
            NovigationCommand = new RelayCommand(Navigation);

            CurrentView = new RelayCommand(Navigation);

            // Startup Page
            CurrentView = new RelayCommand(Autorization);
        }
    }
}
