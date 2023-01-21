using PizzaShop.DataAccess;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{

    internal class RegistrationViewModel : BaseViewModel
    {



        private string _phoneNumber;
        private string _fullName;
        private string _email;
        private string _password;
        private string _errorMessage;


        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        private IDataConnection dataRepository { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand NavigateAuthorizationCommand { get; }
        public ICommand NavigateNavigationationCommand { get; }

        public RegistrationViewModel(NavigationStore navigationStore)
        {
            dataRepository = new DataRepository();

            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore, () => new AuthorizationViewModel(navigationStore));
            NavigateNavigationationCommand = new NavigateCommand<NavigationViewModel>(navigationStore, () => new NavigationViewModel(navigationStore));
        }

        private bool CanExecuteLoginCommand(object arg)
        {
            bool validData = true;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3)
            {
                validData = false;
            }
            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length < 10)
            {
                validData = false;
            }
            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 3)
            {
                validData = false;
            }
            return validData;

        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = dataRepository.EmailIsUnique(Email);

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Email), null);
                NavigateNavigationationCommand.Execute(null);
            }
            else
            {
                ErrorMessage = "* Пользователь с данной почтой уже зарегистрирован";
            }
        }
    }
}
