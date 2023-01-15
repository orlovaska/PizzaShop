using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaShop.DataAccess;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        private object _currentView;
        private string _email;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value;  OnPropertyChanged(nameof(Email)); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand NavigateRegistrationCommand { get; }
        public ICommand NavigateNavigationationCommand { get;}




        public AuthorizationViewModel(NavigationStore navigationStore)
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new RelayCommand(ExecuterecoverPassCommand);
            NavigateRegistrationCommand = new NavigateCommand<RegistrationViewModel>(navigationStore,() => new RegistrationViewModel(navigationStore));
            NavigateNavigationationCommand = new NavigateCommand<NavigationViewModel>(navigationStore, () => new NavigationViewModel(navigationStore));

        }

        

        private bool CanExecuteLoginCommand(object arg)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3 || string.IsNullOrWhiteSpace(Password) || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = false;
            foreach (IDataConnection db in GlobalConfig.Connections)
            {
                isValidUser = db.PasswordVerification(Email, Password);
            }
            isValidUser = true; //TODO строка для тестов. удалить
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Email), null);
                IsViewVisible = false;
                NavigateNavigationationCommand.Execute(null);

            }
            else
            {
                ErrorMessage = "* Неверный пароль или почта";
            }
        }
        private void ExecuterecoverPassCommand(object obj)
        {
            throw new NotImplementedException();
        }


    }
}
