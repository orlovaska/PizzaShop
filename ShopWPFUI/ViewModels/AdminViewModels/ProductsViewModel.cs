using Microsoft.Win32;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ShopWPFUI.ViewModels.AdminViewModels
{
    internal class ProductsViewModel: BaseViewModel
    {
        public ProductsViewModel()
        {
            DataRepository = new DataRepository();
            AllProducts = new ObservableCollection<ProductModel>(DataRepository.GetProducts_All());
            AllCategories = new ObservableCollection<CategoryModel>(DataRepository.GetCategories_All());


            ClearProductCommand = new RelayCommand(ClearProduct);
            DeteleProductCommand = new RelayCommand(DeleteProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            UpdateOrAddProductCommand = new RelayCommand(UpdateOrAddProduct, CanUpdateOrAddProduct);

            AddButtonText = "Добавить";
        }
        public ObservableCollection<CategoryModel> AllCategories { get; set; }
        public ObservableCollection<ProductModel> AllProducts { get; set; }

        public ProductModel _selectedProduct;
        public ProductModel _selectedForEditProduct;
        private string _addButtonText;
        private string _errorMessage;

        private string _productName;
        private string _productCurrentPrice;
        private CategoryModel _productSelectedCategory;
        private byte[] _productImage;
        private string _fileName;

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        public CategoryModel ProductSelectedCategory
        {
            get
            {
                return _productSelectedCategory;
            }
            set
            {
                _productSelectedCategory = value;
                OnPropertyChanged(nameof(ProductSelectedCategory));
            }
        }

        public string ProductCurrentPrice
        {
            get
            {
                return _productCurrentPrice;
            }
            set
            {
                _productCurrentPrice = value;
                OnPropertyChanged(nameof(ProductCurrentPrice));
            }
        }

        public byte[] ProductImage
        {
            get
            {
                return _productImage;
            }
            set
            {
                _productImage = value;
                OnPropertyChanged(nameof(ProductImage));
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public string AddButtonText
        {
            get
            {
                return _addButtonText;
            }
            set
            {
                _addButtonText = value;
                OnPropertyChanged(nameof(AddButtonText));
            }
        }

        public ProductModel SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

            }
        }

        public ProductModel SelectedForEditProduct
        {
            get
            {
                return _selectedForEditProduct;
            }

            set
            {
                _selectedForEditProduct = value;
                OnPropertyChanged(nameof(SelectedForEditProduct));

            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }


        private IDataConnection DataRepository { get; set; }


        public ICommand DeteleProductCommand { get; }
        public ICommand UpdateOrAddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand ClearProductCommand { get; }
        public ICommand OpenFileDialogCommand { get; }



        private bool CanUpdateOrAddProduct(object arg)
        {
            if (ProductImage == null && String.IsNullOrEmpty(ProductName) && ProductSelectedCategory == null && ProductCurrentPrice == null)
            {
                ErrorMessage = "";
                return false;
            }

            if (String.IsNullOrEmpty(ProductName) && ProductImage == null)
            {
                ErrorMessage = "* Добавьте фото и название продукта";
                return false;
            }
            if (String.IsNullOrEmpty(ProductName))
            {
                ErrorMessage = "* Введите название продукта";
                return false;
            }

            if (!String.IsNullOrEmpty(ProductCurrentPrice))
            {
                if (!decimal.TryParse(ProductCurrentPrice, out decimal result) || result == 0)
                {
                    ErrorMessage = "* Введите цену продукта";
                    return false;
                }
            }
            else
            {
                ErrorMessage = "* Введите цену продукта";
                return false;
            }

            if (ProductImage == null)
            {
                ErrorMessage = "* Добавьте фото продукта";
                return false;
            }
            if (ProductSelectedCategory == null)
            {
                ErrorMessage = "* Выберите категорию продукта";
                return false;
            }
            if (!String.IsNullOrEmpty(ProductName) && ProductImage != null)
            {
                ErrorMessage = "";
            }

            return true;
        }


        private void UpdateOrAddProduct(object obj)
        {
            if (SelectedForEditProduct == null)
            {
                //add product
                SelectedForEditProduct = new ProductModel();
                SelectedForEditProduct.Name = ProductName;
                SelectedForEditProduct.Image = ProductImage;
                SelectedForEditProduct.CurrentPrice = Math.Round(decimal.Parse(ProductCurrentPrice), 2);

                SelectedForEditProduct = DataRepository.AddProduct(SelectedForEditProduct, ProductSelectedCategory);
                AllProducts.Add(SelectedForEditProduct);
            }
            else
            {
                //update product
                int index = AllProducts.IndexOf(SelectedForEditProduct);
                AllProducts.Remove(SelectedForEditProduct);

                SelectedForEditProduct.Name = ProductName;
                SelectedForEditProduct.Image = ProductImage;
                SelectedForEditProduct.CurrentPrice = Math.Round(decimal.Parse(ProductCurrentPrice), 2);
                SelectedForEditProduct = DataRepository.EditProduct(SelectedForEditProduct, ProductSelectedCategory);

                AllProducts.Insert(index, SelectedForEditProduct);
            }

            ClearProduct(obj);
        }

        private void OpenFileDialog(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName.Split('\\').Last(); ;

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(openFileDialog.FileName))));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    ProductImage = ms.ToArray();
                }
            }
        }


        private void ClearProduct(object obj)
        {
            FileName = null;
            SelectedProduct = null;
            SelectedForEditProduct = null;

            ProductImage = null;
            ProductName = null;
            ProductSelectedCategory = null;
            ProductCurrentPrice = null;
            ErrorMessage = null;
            AddButtonText = "Добавить";
        }

        private void EditProduct(object obj)
        {
            FileName = "";
            ErrorMessage = "";
            SelectedForEditProduct = SelectedProduct;
            ProductName = SelectedForEditProduct.Name;
            ProductCurrentPrice = SelectedForEditProduct.CurrentPrice.ToString();
            ProductSelectedCategory = SelectedProduct.Category;
            ProductImage = SelectedForEditProduct.Image;
            AddButtonText = "Обновить";
        }

        private void DeleteProduct(object obj)
        {
            var itemToRemove = AllProducts.SingleOrDefault(r => r.Id == SelectedProduct.Id);
            if (itemToRemove != null)
            {
                DataRepository.DeleteProduct(SelectedProduct);
                AllProducts.Remove(itemToRemove);
                SelectedProduct = null;
                AddButtonText = "Добавить";
                ClearProduct(obj);
            }
        }
    }
}
