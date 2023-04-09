using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private CustomerModel _currentCustomerAccount;
        private AddressModel _selectedAddress;
        private string _addressForAdding;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;

        private Visibility _firstNameVisibility;
        private Visibility _lastNameVisibility; 
        private Visibility _emailVisibility;
        private Visibility _phoneNumberVisibility;

        private Visibility _firstNameEditVisibility;
        private Visibility _lastNameEditVisibility;
        private Visibility _emailEditVisibility;
        private Visibility _phoneNumberEditVisibility;

        public Visibility FirstNameVisibility
        {
            get { return _firstNameVisibility; }
            set { _firstNameVisibility = value; OnPropertyChanged(nameof(FirstNameVisibility)); }
        }
        public Visibility LastNameVisibility
        {
            get { return _lastNameVisibility; }
            set { _lastNameVisibility = value; OnPropertyChanged(nameof(LastNameVisibility)); }
        }
        public Visibility EmailVisibility
        {
            get { return _emailVisibility; }
            set { _emailVisibility = value; OnPropertyChanged(nameof(EmailVisibility)); }
        }
        public Visibility PhoneNumberVisibility
        {
            get { return _phoneNumberVisibility; }
            set { _phoneNumberVisibility = value; OnPropertyChanged(nameof(PhoneNumberVisibility)); }
        }


        public Visibility FirstNameEditVisibility
        {
            get { return _firstNameEditVisibility; }
            set { _firstNameEditVisibility = value; OnPropertyChanged(nameof(FirstNameEditVisibility)); }
        }
        public Visibility LastNameEditVisibility
        {
            get { return _lastNameEditVisibility; }
            set { _lastNameEditVisibility = value; OnPropertyChanged(nameof(LastNameEditVisibility)); }
        }
        public Visibility EmailEditVisibility
        {
            get { return _emailEditVisibility; }
            set { _emailEditVisibility = value; OnPropertyChanged(nameof(EmailEditVisibility)); }
        }
        public Visibility PhoneNumberEditVisibility
        {
            get { return _phoneNumberEditVisibility; }
            set { _phoneNumberEditVisibility = value; OnPropertyChanged(nameof(PhoneNumberEditVisibility)); }
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

        public string AddressForAdding
        {
            get { return _addressForAdding; }
            set { _addressForAdding = value; OnPropertyChanged(nameof(AddressForAdding)); }
        }
        public AddressModel SelectedAddress
        {
            get { return _selectedAddress; }
            set { _selectedAddress = value; }
        }

        public ObservableCollection<AddressModel> Addresses { get; set; }

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

        private IDataConnection DataRepository { get; set; }
        public ICommand ChangeCurrentAddressCommand { get;}
        public ICommand DeleteAddressCommand { get;}
        public ICommand AddAddressCommand { get;}

        public ICommand EditFirstNameCommand { get;}
        public ICommand EditLastNameCommand { get; }
        public ICommand EditEmailCommand { get; }
        public ICommand EditPhoneNumberCommand { get; }

        public ICommand SaveFirstNameCommand { get;}
        public ICommand SaveLastNameCommand { get;}
        public ICommand SaveEmailCommand { get;}
        public ICommand SavePhoneNumberCommand { get;}

        public ProfileViewModel(CustomerModel currentCustomerAccount)
        {
            DataRepository = new DataRepository();
            ChangeCurrentAddressCommand = new RelayCommand(ChangeCurrentAddress);
            DeleteAddressCommand = new RelayCommand(DeleteAddress);
            AddAddressCommand = new RelayCommand(AddAddress, CanAddAddress);

            SaveFirstNameCommand = new RelayCommand(SaveFirstName);
            SaveLastNameCommand = new RelayCommand(SaveLastName);
            SaveEmailCommand = new RelayCommand(SaveEmail);
            SavePhoneNumberCommand = new RelayCommand(SavePhoneNumber);


            EditFirstNameCommand = new RelayCommand(EditFirstName);
            EditLastNameCommand = new RelayCommand(EditLastName);
            EditEmailCommand = new RelayCommand(EditEmail);
            EditPhoneNumberCommand = new RelayCommand(EditPhoneNumber);

            CurrentCustomerAccount = currentCustomerAccount;
            Addresses = new ObservableCollection<AddressModel>(DataRepository.GetAddressesByCustomer(currentCustomerAccount));

            FirstName = currentCustomerAccount.FirstName;
            LastName = currentCustomerAccount.LastName;
            Email = currentCustomerAccount.Email;
            PhoneNumber = currentCustomerAccount.Phone;

            FirstNameVisibility = Visibility.Visible;
            LastNameVisibility = Visibility.Visible;
            EmailVisibility = Visibility.Visible;
            PhoneNumberVisibility = Visibility.Visible;

            FirstNameEditVisibility = Visibility.Hidden;
            LastNameEditVisibility = Visibility.Hidden;
            EmailEditVisibility = Visibility.Hidden;
            PhoneNumberEditVisibility = Visibility.Hidden;



        }

        private bool CanAddAddress(object obj)
        {
            bool validData = true;
            if (string.IsNullOrEmpty(AddressForAdding) || AddressForAdding.Length < 5)
            {
                validData = false;
            }
            return validData;
        }

        private void SaveFirstName(object obj)
        {
            FirstNameVisibility = Visibility.Visible;
            FirstNameEditVisibility = Visibility.Hidden;
            CurrentCustomerAccount.FirstName = FirstName;
            DataRepository.EditCustomer(CurrentCustomerAccount);
        }
        private void SaveLastName(object obj)
        {
            LastNameVisibility = Visibility.Visible;
            LastNameEditVisibility = Visibility.Hidden;
            CurrentCustomerAccount.LastName = LastName;
            DataRepository.EditCustomer(CurrentCustomerAccount);
        }
        private void SaveEmail(object obj)
        {
            EmailVisibility = Visibility.Visible;
            EmailEditVisibility = Visibility.Hidden;
            CurrentCustomerAccount.Email = Email;
            DataRepository.EditCustomer(CurrentCustomerAccount);
        }
        private void SavePhoneNumber(object obj)
        {
            PhoneNumberVisibility = Visibility.Visible;
            PhoneNumberEditVisibility = Visibility.Hidden;
            CurrentCustomerAccount.Phone = PhoneNumber;
            DataRepository.EditCustomer(CurrentCustomerAccount);
        }

        private void EditFirstName(object obj)
        {
            FirstNameVisibility = Visibility.Hidden;
            FirstNameEditVisibility = Visibility.Visible;
        }
        private void EditLastName(object obj)
        {
            LastNameVisibility = Visibility.Hidden;
            LastNameEditVisibility = Visibility.Visible;
        }
        private void EditEmail(object obj)
        {
            EmailVisibility = Visibility.Hidden;
            EmailEditVisibility = Visibility.Visible;
        }
        private void EditPhoneNumber(object obj)
        {
            PhoneNumberVisibility = Visibility.Hidden;
            PhoneNumberEditVisibility = Visibility.Visible;
        }


        private void AddAddress(object obj)
        {
            AddressModel addedAddress = new AddressModel();
            addedAddress.Address = AddressForAdding;

            if (Addresses.Count == 0)
            {
                addedAddress.IsSelected = true;
            }
            else addedAddress.IsSelected = false;

            addedAddress = DataRepository.AddAddressesByCustomer(addedAddress, CurrentCustomerAccount);
            Addresses.Add(addedAddress);
            AddressForAdding = null;
        }

        private void DeleteAddress(object obj)
        {
            DataRepository.DeleteAddress(SelectedAddress);
            Addresses.Remove(SelectedAddress);
        }

        private void ChangeCurrentAddress(object obj)
        {
            DataRepository.ChangeCurrentAddressByCustomer(DataRepository.GetCurrentAddressByCustomer(CurrentCustomerAccount), SelectedAddress);
        }
    }
}
