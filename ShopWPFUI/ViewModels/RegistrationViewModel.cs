using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ShopWPFUI.ViewModels
{

    internal class RegistrationViewModel : BaseViewModel
    {

        private string _phoneNumber;
        private string _firstName;
        private string _lastName;
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
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private IDataConnection dataRepository { get; set; }

        public ICommand RegistrationCommand { get; }
        public ICommand NavigateAuthorizationCommand { get; }
        public ICommand NavigateNavigationationCommand { get; }

        public RegistrationViewModel(NavigationStore navigationStore)
        {
            dataRepository = new DataRepository();

            RegistrationCommand = new RelayCommand(ExecuteRegistrationCommand, CanExecuteRegistrationCommand);
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore, () => new AuthorizationViewModel(navigationStore));
            NavigateNavigationationCommand = new NavigateCommand<NavigationViewModel>(navigationStore, () => new NavigationViewModel(navigationStore));
        }

        private bool CanExecuteRegistrationCommand(object arg)
        {
            bool validData = true;

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                validData = false;
                ErrorMessage = "*Введите имя";
                return validData;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                validData = false;
                ErrorMessage = "*Введите фамилию";
                return validData;
            }

            var phone = new PhoneAttribute();
            bool zaeb = phone.IsValid(PhoneNumber);
            if (string.IsNullOrWhiteSpace(PhoneNumber) || !(PhoneNumber.Length == 10) || !phone.IsValid(PhoneNumber))
            {
                validData = false;
                ErrorMessage = "*Введите корректный номер";
                return validData;
            }

            var email = new EmailAddressAttribute();
            if (string.IsNullOrWhiteSpace(Email) || !email.IsValid(Email))
            {
                validData = false;
                ErrorMessage = "*Введите корректную почту";
                return validData;
            }

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 3)
            {
                validData = false;
                ErrorMessage = "*Придумайте пароль более 3 символов";
                return validData;
            }
            if (validData)
            {
                if (!(ErrorMessage == "* Пользователь с данной почтой уже зарегистрирован"))
                    ErrorMessage = "";
            }
            return validData;

        }

        private void ExecuteRegistrationCommand(object obj)
        {
            bool isValidUser = dataRepository.EmailIsUnique(Email);

            if (isValidUser)
            {
                CustomerModel customer = new CustomerModel();
                customer.Email = Email;
                customer.Phone = PhoneNumber;
                customer.FirstName = FirstName;
                customer.LastName = LastName;
                dataRepository.AddCustomer(customer, dataRepository.GetAllRoles()[0], Password);

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
