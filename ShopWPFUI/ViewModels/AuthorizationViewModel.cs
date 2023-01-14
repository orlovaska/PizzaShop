using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible;

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


        public AuthorizationViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteCommand);
            RecoverPasswordCommand = new RelayCommand(ExecuterecoverPassCommand);
        }

        

        private bool CanExecuteCommand(object arg)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Email) || Email.Length < 3 || Password.Length < 3 || string.IsNullOrWhiteSpace(Password))
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
            throw new NotImplementedException();
        }
        private void ExecuterecoverPassCommand(object obj)
        {
            throw new NotImplementedException();
        }


    }
}
