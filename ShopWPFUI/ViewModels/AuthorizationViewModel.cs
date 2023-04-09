using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaShop.DataAccess;
using ShopLibrary;
using ShopWPFUI.Commands;
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
        private string _email;
        private string _password;
        private string _errorMessage;


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
        private IDataConnection DataRepository { get; set; }


        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        //public ICommand ShowPasswordCommand { get; }
        //public ICommand RememberPasswordCommand { get; }
        public ICommand RegistrationCommand { get; }
        public ICommand NavigationationCommand { get; }
        public ICommand AdminNavigationationCommand { get; }




        public AuthorizationViewModel(NavigationStore navigationStore)
        {
            DataRepository = new DataRepository();
            AllRoles = DataRepository.GetAllRoles();
            if (AllRoles.Count != 0)
            {
                SelectedRole = AllRoles[0];
                //SelectedRole = AllRoles[1];
            }

            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            //RecoverPasswordCommand = new RelayCommand(ExecuterecoverPassCommand);
            RegistrationCommand = new NavigateCommand<RegistrationViewModel>(navigationStore,() => new RegistrationViewModel(navigationStore));
            NavigationationCommand = new NavigateCommand<NavigationViewModel>(navigationStore, () => new NavigationViewModel(navigationStore));
            AdminNavigationationCommand = new NavigateCommand<AdminNavigationViewModel>(navigationStore, () => new AdminNavigationViewModel(navigationStore));

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
            var isValidUser = DataRepository.PasswordVerification(Email, Password);

            isValidUser = true; //TODO строка для тестов. удалить
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Email), null);
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
