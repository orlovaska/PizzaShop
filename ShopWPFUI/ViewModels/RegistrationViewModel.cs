using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels
{

    internal class RegistrationViewModel : BaseViewModel
    {



        private readonly NavigationStore _navigationStore;
        private string _fullName;
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
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        public RegistrationViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
