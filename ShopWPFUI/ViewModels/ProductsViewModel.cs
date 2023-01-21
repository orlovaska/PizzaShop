using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    internal class ProductsViewModel: BaseViewModel
    {
        private ProductModel _selectedProduct;
        private CustomerModel _currentCustomerAccount;

        public ProductModel SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }

            set
            {
                _selectedProduct = value;
                AddToCartCommand.Execute(this);
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
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
        public string SelectedCategory { get; set; }

        public List<ProductModel> Products { get; set; }

        public ICommand AddToCartCommand { get; }
        private IDataConnection DataRepository { get; set; }

        public ProductsViewModel(CustomerModel currentCustomerAccount, CategoryModel selectedCatedory)
        {
            CurrentCustomerAccount = currentCustomerAccount;
            DataRepository = new DataRepository();

            SelectedCategory = selectedCatedory.Name;
            Products = DataRepository.GetProductsFromCategory(selectedCatedory);

            AddToCartCommand = new RelayCommand(AddToCart);
            //Products = DataRepository.GetProducts_All();
        }

        public void AddToCart(object obj)
        {
            DataRepository.AddToCart(CurrentCustomerAccount, SelectedProduct);
        }
    }
}
