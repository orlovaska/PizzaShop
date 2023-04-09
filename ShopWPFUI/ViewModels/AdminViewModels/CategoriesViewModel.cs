using Microsoft.VisualBasic;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace ShopWPFUI.ViewModels.AdminViewModels
{
    internal class CategoriesViewModel: BaseViewModel
    {
        public ObservableCollection<CategoryModel> AllCategories { get; set; }

        public CategoryModel _selectedCatedory;
        public CategoryModel _selectedForEditCatedory;
        private string _addButtonText;
        private string _errorMessage;

        private string _categoryName;
        private byte[] _categoryImage;
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


        public byte[] CategoryImage
        {
            get 
            { 
                return _categoryImage;
            }
            set 
            { 
                _categoryImage = value;
                OnPropertyChanged(nameof(CategoryImage));
            }
        }

        public string CategoryName
        {
            get 
            { 
                return _categoryName;
            }
            set 
            { 
                _categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
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

        public CategoryModel SelectedCatedory
        {
            get
            {
                return _selectedCatedory;
            }
            set
            {
                _selectedCatedory = value;
                OnPropertyChanged(nameof(SelectedCatedory));

            }
        }

        public CategoryModel SelectedForEditCatedory
        {
            get
            {
                return _selectedForEditCatedory;
            }

            set
            {
                _selectedForEditCatedory = value;
                OnPropertyChanged(nameof(SelectedForEditCatedory));

            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }


        private IDataConnection DataRepository { get; set; }


        public ICommand DeteleCategoryCommand { get; }
        public ICommand UpdateOrAddCategoryCommand { get; }
        public ICommand EditCategoryCommand { get; }
        public ICommand ClearCategoryCommand { get; }
        public ICommand OpenFileDialogCommand { get; }



        public CategoriesViewModel()
        {
            DataRepository = new DataRepository();
            AllCategories = new ObservableCollection<CategoryModel>(DataRepository.GetCategories_All());

            ClearCategoryCommand = new RelayCommand(ClearCategory);
            DeteleCategoryCommand = new RelayCommand(DeleteCategory);
            EditCategoryCommand = new RelayCommand(EditCategory);
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            UpdateOrAddCategoryCommand = new RelayCommand(UpdateOrAddCategory, CanUpdateOrAddCategory);

            AddButtonText = "Добавить";
        }

        private bool CanUpdateOrAddCategory(object arg)
        {
            if (CategoryImage == null && String.IsNullOrEmpty(CategoryName))
            {
                ErrorMessage = "";
                return false;
            }

            if (String.IsNullOrEmpty(CategoryName) && CategoryImage == null)
            {
                ErrorMessage = "* Добавьте фото и название категории";
                return false;
            }
            if (String.IsNullOrEmpty(CategoryName))
            {
                ErrorMessage = "* Введите название категории";
                return false;
            }

            if (CategoryImage == null)
            {
                ErrorMessage = "* Добавьте фото категории";
                return false;
            }
            if (!String.IsNullOrEmpty(CategoryName) && CategoryImage != null)
            {
                ErrorMessage = "";
            }

            return true;
        }


        private void UpdateOrAddCategory(object obj)
        {
            if (SelectedForEditCatedory == null)
            {
                //add category
                SelectedForEditCatedory = new CategoryModel();
                SelectedForEditCatedory.Name = CategoryName;
                SelectedForEditCatedory.Image = CategoryImage;
                SelectedForEditCatedory = DataRepository.AddCategory(SelectedForEditCatedory);
                AllCategories.Add(SelectedForEditCatedory);
            }
            else
            {
                //update category
                int index = AllCategories.IndexOf(SelectedForEditCatedory);
                AllCategories.Remove(SelectedForEditCatedory);

                SelectedForEditCatedory.Name = CategoryName;
                SelectedForEditCatedory.Image = CategoryImage;
                SelectedForEditCatedory = DataRepository.EditCategory(SelectedForEditCatedory);

                AllCategories.Insert(index, SelectedForEditCatedory);
            }

            ClearCategory(obj);
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
                    CategoryImage = ms.ToArray();
                }
            }
        }


        private void ClearCategory(object obj)
        {
            FileName = null;
            SelectedCatedory = null;
            SelectedForEditCatedory = null;
            CategoryImage = null;
            CategoryName = null;
            ErrorMessage = null;
            AddButtonText = "Добавить";
        }

        private void EditCategory(object obj)
        {
            FileName = "";
            ErrorMessage = "";
            SelectedForEditCatedory = SelectedCatedory;
            CategoryImage = SelectedForEditCatedory.Image;
            CategoryName = SelectedForEditCatedory.Name;
            AddButtonText = "Обновить";
        }

        private void DeleteCategory(object obj)
        {
            var itemToRemove = AllCategories.SingleOrDefault(r => r.Id == SelectedCatedory.Id);
            if (itemToRemove != null)
            {
                DataRepository.DeleteCategory(SelectedCatedory);
                AllCategories.Remove(itemToRemove);
                SelectedCatedory = null;
                AddButtonText = "Добавить";
                ClearCategory(obj);
            }
        }
    }
}
