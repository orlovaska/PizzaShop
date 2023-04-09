using PizzaShop.DataAccess;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using PizzaShop.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using ShopWPFUI.Commands;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;

namespace ShopWPFUI.ViewModels.AdminViewModels
{
    internal class DashboardViewModel: BaseViewModel
    {
        //public ObservableCollection<CategoryModel> AllCategories { get; set; }


        //private static object _selectedObject;

        //private Visibility _visibilityGroupBorder;
        //private Visibility _visibilityStudentBorder;

        //#region Поля для работы с категорией
        //public CategoryModel _selectedCatedory;
        //public CategoryModel _selectedForEditCatedory;
        //private string _categoryAddButtonText;
        //private string _categoryErrorMessage;

        //private string _categoryName;
        //private byte[] _categoryImage;
        //private string _categoryFileName;
        //#endregion

        //#region Поля для работы с продуктом
        //public ProductModel _selectedProduct;
        //public ProductModel _selectedForEditProduct;
        //private string _addButtonText;
        //private string _errorMessage;

        //private string _productName;
        //private string _productCurrentPrice;
        //private CategoryModel _productSelectedCategory;
        //private byte[] _productImage;
        //private string _fileName;
        //#endregion

        //#region Свойства для работы с продуктом
        //public string FileName
        //{
        //    get
        //    {
        //        return _fileName;
        //    }
        //    set
        //    {
        //        _fileName = value;
        //        OnPropertyChanged(nameof(FileName));
        //    }
        //}

        //public CategoryModel ProductSelectedCategory
        //{
        //    get
        //    {
        //        return _productSelectedCategory;
        //    }
        //    set
        //    {
        //        _productSelectedCategory = value;
        //        OnPropertyChanged(nameof(ProductSelectedCategory));
        //    }
        //}

        //public string ProductCurrentPrice
        //{
        //    get
        //    {
        //        return _productCurrentPrice;
        //    }
        //    set
        //    {
        //        _productCurrentPrice = value;
        //        OnPropertyChanged(nameof(ProductCurrentPrice));
        //    }
        //}

        //public byte[] ProductImage
        //{
        //    get
        //    {
        //        return _productImage;
        //    }
        //    set
        //    {
        //        _productImage = value;
        //        OnPropertyChanged(nameof(ProductImage));
        //    }
        //}

        //public string ProductName
        //{
        //    get
        //    {
        //        return _productName;
        //    }
        //    set
        //    {
        //        _productName = value;
        //        OnPropertyChanged(nameof(ProductName));
        //    }
        //}

        //public string AddButtonText
        //{
        //    get
        //    {
        //        return _addButtonText;
        //    }
        //    set
        //    {
        //        _addButtonText = value;
        //        OnPropertyChanged(nameof(AddButtonText));
        //    }
        //}

        //public ProductModel SelectedProduct
        //{
        //    get
        //    {
        //        return _selectedProduct;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            _selectedProduct = value;
        //            //ShowEditProductBorder(null);
        //            //ShowProductPanel();
        //            ProductSelectedCategory = DataRepository.GetCategoriesById(_selectedProduct.CategoryId);
        //            OnPropertyChanged(nameof(SelectedProduct));
        //        }

        //    }
        //}

        //public ProductModel SelectedForEditProduct
        //{
        //    get
        //    {
        //        return _selectedForEditProduct;
        //    }

        //    set
        //    {
        //        _selectedForEditProduct = value;
        //        OnPropertyChanged(nameof(SelectedForEditProduct));

        //    }
        //}

        //public string ErrorMessage
        //{
        //    get { return _errorMessage; }
        //    set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        //} 
        //#endregion

        //#region Свойства для работы с категорией

        //public string CategoryFileName
        //{
        //    get
        //    {
        //        return _categoryFileName;
        //    }
        //    set
        //    {
        //        _categoryFileName = value;
        //        OnPropertyChanged(nameof(CategoryFileName));
        //    }
        //}


        //public byte[] CategoryImage
        //{
        //    get
        //    {
        //        return _categoryImage;
        //    }
        //    set
        //    {
        //        _categoryImage = value;
        //        OnPropertyChanged(nameof(CategoryImage));
        //    }
        //}

        //public string CategoryName
        //{
        //    get
        //    {
        //        return _categoryName;
        //    }
        //    set
        //    {
        //        _categoryName = value;
        //        OnPropertyChanged(nameof(CategoryName));
        //    }
        //}

        //public CategoryModel SelectedCatedory
        //{
        //    get
        //    {
        //        return _selectedCatedory;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            _selectedCatedory = value;
        //            //ShowEditCategoryBorder(null);
        //            OnPropertyChanged(nameof(SelectedCatedory));
        //        }

        //    }
        //}

        //public CategoryModel SelectedForEditCatedory
        //{
        //    get
        //    {
        //        return _selectedForEditCatedory;
        //    }

        //    set
        //    {
        //        _selectedForEditCatedory = value;
        //        OnPropertyChanged(nameof(SelectedForEditCatedory));

        //    }
        //}


        //public string CategoryAddButtonText
        //{
        //    get
        //    {
        //        return _categoryAddButtonText;
        //    }
        //    set
        //    {
        //        _categoryAddButtonText = value;
        //        OnPropertyChanged(nameof(CategoryAddButtonText));
        //    }
        //}
        //public string CategoryErrorMessage
        //{
        //    get { return _categoryErrorMessage; }
        //    set { _categoryErrorMessage = value; OnPropertyChanged(nameof(CategoryErrorMessage)); }
        //} 
        //#endregion

        //public object SelectedObject
        //{
        //    get
        //    {
        //        return _selectedObject;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            _selectedObject = (object)value;
        //            if (_selectedObject is CategoryModel)
        //            {
        //                CategoryModel category = (CategoryModel)_selectedObject;
        //                SelectedCatedory = (CategoryModel)category.Clone();
        //            }
        //            if (_selectedObject is ProductModel)
        //            {
        //                ProductModel product = (ProductModel)_selectedObject;
        //                SelectedProduct = (ProductModel)product.Clone();
        //            }
        //        }
        //    }
        //}
        //public Visibility VisibilityProductBorder
        //{
        //    get { return _visibilityGroupBorder; }
        //    set { _visibilityGroupBorder = value; OnPropertyChanged(nameof(VisibilityProductBorder)); }
        //}
        //public Visibility VisibilityCategoryBorder
        //{
        //    get { return _visibilityStudentBorder; }
        //    set
        //    {
        //        _visibilityStudentBorder = value;
        //        OnPropertyChanged(nameof(VisibilityCategoryBorder));
        //    }
        //}

        //private IDataConnection DataRepository { get; set; }
        //public ICommand ShowGroupPanelCommand { get; }
        //public ICommand ShowStudentPanelCommand { get; }

        //public ICommand DeleteCategoryCommand { get; }
        //public ICommand UpdateOrAddCategoryCommand { get; }
        //public ICommand ShowEditCategoryBorderCommand { get; }
        //public ICommand ShowAddCategoryBorderCommand { get; }
        //public ICommand ClearCategoryCommand { get; }
        //public ICommand OpenCategoryFileDialogCommand { get; }

        //public ICommand DeleteProductCommand { get; }
        //public ICommand UpdateOrAddProductCommand { get; }
        //public ICommand ShowEditProductBorderCommand { get; }
        //public ICommand ShowAddProductBorderCommand { get; }
        //public ICommand ClearProductCommand { get; }
        //public ICommand OpenProductFileDialogCommand { get; }


        //public DashboardViewModel()
        //{
        //    DataRepository = new DataRepository();
        //    AllCategories = new ObservableCollection<CategoryModel>(DataRepository.GetCategories_All());

        //    ClearCategoryCommand = new RelayCommand(ClearCategory);
        //    DeleteCategoryCommand = new RelayCommand(DeleteCategory);
        //    ShowEditCategoryBorderCommand = new RelayCommand(ShowEditCategoryBorder);
        //    ShowAddCategoryBorderCommand = new RelayCommand(ShowAddCategoryBorder);
        //    UpdateOrAddCategoryCommand = new RelayCommand(UpdateOrAddCategory, CanUpdateOrAddCategory);
        //    OpenCategoryFileDialogCommand = new RelayCommand(OpenCategoryFileDialog);

        //    UpdateOrAddProductCommand = new RelayCommand(UpdateOrAddProduct, CanUpdateOrAddProduct);
        //    DeleteProductCommand = new RelayCommand(DeleteProduct);
        //    ClearProductCommand = new RelayCommand(ClearProduct);
        //    ShowEditProductBorderCommand = new RelayCommand(ShowEditProductBorder);
        //    ShowAddProductBorderCommand = new RelayCommand(ShowAddProductBorder);
        //    OpenProductFileDialogCommand = new RelayCommand(OpenProductFileDialog);

        //    VisibilityCategoryBorder = Visibility.Hidden;
        //    VisibilityProductBorder = Visibility.Hidden;
        //}


        //#region Методы для работы с категориями

        //private void ShowAddCategoryBorder(object obj)
        //{
        //    ShowCategoryPanel();
        //    //VisibilityProductBorder = Visibility.Hidden;
        //    //VisibilityCategoryBorder = Visibility.Visible;
        //    ClearCategory(obj);

        //    //CategoryFileName = null;
        //    //SelectedCatedory = null;
        //    //SelectedForEditCatedory = null;
        //    //CategoryImage = null;
        //    //CategoryName = "Gjxtve";
        //    //CategoryErrorMessage = null;
        //    //CategoryAddButtonText = "Добавить";
        //}

        //private bool CanUpdateOrAddCategory(object arg)
        //{
        //    if (CategoryImage == null && String.IsNullOrEmpty(CategoryName))
        //    {
        //        CategoryErrorMessage = "";
        //        return false;
        //    }

        //    if (String.IsNullOrEmpty(CategoryName) && CategoryImage == null)
        //    {
        //        CategoryErrorMessage = "* Добавьте фото и название категории";
        //        return false;
        //    }
        //    if (String.IsNullOrEmpty(CategoryName))
        //    {
        //        CategoryErrorMessage = "* Введите название категории";
        //        return false;
        //    }

        //    if (CategoryImage == null)
        //    {
        //        CategoryErrorMessage = "* Добавьте фото категории";
        //        return false;
        //    }
        //    if (!String.IsNullOrEmpty(CategoryName) && CategoryImage != null)
        //    {
        //        CategoryErrorMessage = "";
        //    }

        //    return true;
        //}


        //private void UpdateOrAddCategory(object obj)
        //{
        //    if (SelectedForEditCatedory == null)
        //    {
        //        //add category
        //        SelectedForEditCatedory = new CategoryModel();
        //        SelectedForEditCatedory.Name = CategoryName;
        //        SelectedForEditCatedory.Image = CategoryImage;
        //        SelectedForEditCatedory = DataRepository.AddCategory(SelectedForEditCatedory);
        //        SelectedForEditCatedory.Products = new List<ProductModel>();
        //        AllCategories.Add(SelectedForEditCatedory);
        //    }
        //    else
        //    {
        //        //update category
        //        int index = AllCategories.IndexOf(AllCategories.Where(p =>p.Id == SelectedForEditCatedory.Id).Single());
        //        AllCategories.Remove(AllCategories.Where(p => p.Id == SelectedForEditCatedory.Id).Single());

        //        SelectedForEditCatedory.Name = CategoryName;
        //        SelectedForEditCatedory.Image = CategoryImage;
        //        SelectedForEditCatedory = DataRepository.EditCategory(SelectedForEditCatedory);

        //        AllCategories.Insert(index, SelectedForEditCatedory);
        //    }

        //    ClearCategory(obj);
        //}

        //private void OpenCategoryFileDialog(object obj)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();

        //    openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        //      "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        //      "Portable Network Graphic (*.png)|*.png";

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        CategoryFileName = openFileDialog.FileName.Split('\\').Last(); ;

        //        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //        encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(openFileDialog.FileName))));
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            encoder.Save(ms);
        //            CategoryImage = ms.ToArray();
        //        }
        //    }
        //}


        //private void ClearCategory(object obj)
        //{
        //    CategoryFileName = null;
        //    SelectedCatedory = null;
        //    SelectedForEditCatedory = null;
        //    CategoryImage = null;
        //    CategoryName = null;
        //    CategoryErrorMessage = null;
        //    CategoryAddButtonText = "Добавить";
        //}

        //private void ShowEditCategoryBorder(object obj)
        //{
        //    CategoryFileName = "";
        //    CategoryErrorMessage = "";
        //    SelectedForEditCatedory = SelectedCatedory;
        //    CategoryImage = SelectedForEditCatedory.Image;
        //    CategoryName = SelectedForEditCatedory.Name;
        //    CategoryAddButtonText = "Обновить";

        //    ShowCategoryPanel();
        //}

        //private void DeleteCategory(object obj)
        //{
        //    var itemToRemove = AllCategories.SingleOrDefault(r => r.Id == SelectedCatedory.Id);
        //    if (itemToRemove != null)
        //    {
        //        DataRepository.DeleteCategory(SelectedCatedory);
        //        AllCategories.Remove(itemToRemove);
        //        SelectedCatedory = null;
        //        CategoryAddButtonText = "Добавить";
        //        ClearCategory(obj);
        //    }
        //}
        //#endregion

        //#region Методы для работы с продуктами
        //private void OpenProductFileDialog(object obj)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();

        //    openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        //      "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        //      "Portable Network Graphic (*.png)|*.png";

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        FileName = openFileDialog.FileName.Split('\\').Last(); ;

        //        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //        encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(openFileDialog.FileName))));
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            encoder.Save(ms);
        //            ProductImage = ms.ToArray();
        //        }
        //    }
        //}

        //private bool CanUpdateOrAddProduct(object arg)
        //{
        //    if (ProductImage == null && String.IsNullOrEmpty(ProductName) && ProductSelectedCategory == null && ProductCurrentPrice == null)
        //    {
        //        ErrorMessage = "";
        //        return false;
        //    }

        //    if (String.IsNullOrEmpty(ProductName) && ProductImage == null)
        //    {
        //        ErrorMessage = "* Добавьте фото и название продукта";
        //        return false;
        //    }
        //    if (String.IsNullOrEmpty(ProductName))
        //    {
        //        ErrorMessage = "* Введите название продукта";
        //        return false;
        //    }

        //    if (!String.IsNullOrEmpty(ProductCurrentPrice))
        //    {
        //        if (!decimal.TryParse(ProductCurrentPrice, out decimal result) || result == 0)
        //        {
        //            ErrorMessage = "* Введите цену продукта";
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        ErrorMessage = "* Введите цену продукта";
        //        return false;
        //    }

        //    if (ProductImage == null)
        //    {
        //        ErrorMessage = "* Добавьте фото продукта";
        //        return false;
        //    }
        //    if (ProductSelectedCategory == null)
        //    {
        //        ErrorMessage = "* Выберите категорию продукта";
        //        return false;
        //    }
        //    if (!String.IsNullOrEmpty(ProductName) && ProductImage != null)
        //    {
        //        ErrorMessage = "";
        //    }

        //    return true;
        //}

        //private void ShowAddProductBorder(object obj)
        //{
        //    FileName = null;
        //    SelectedProduct = null;
        //    SelectedForEditProduct = null;

        //    ProductImage = null;
        //    ProductName = null;
        //    ProductCurrentPrice = null;
        //    ErrorMessage = null;
        //    AddButtonText = "Добавить";

        //    ShowProductPanel();
        //}

        //private void UpdateOrAddProduct(object obj)
        //{
        //    if (SelectedForEditProduct == null)
        //    {
        //        //add product
        //        SelectedForEditProduct = new ProductModel();
        //        SelectedForEditProduct.Name = ProductName;
        //        SelectedForEditProduct.Image = ProductImage;
        //        SelectedForEditProduct.CurrentPrice = Math.Round(decimal.Parse(ProductCurrentPrice), 2);

        //        SelectedForEditProduct = DataRepository.AddProduct(SelectedForEditProduct, ProductSelectedCategory);
        //    }
        //    else
        //    {
        //        //update product
        //        SelectedForEditProduct.Name = ProductName;
        //        SelectedForEditProduct.Image = ProductImage;
        //        SelectedForEditProduct.CurrentPrice = Math.Round(decimal.Parse(ProductCurrentPrice), 2);
        //        SelectedForEditProduct = DataRepository.EditProduct(SelectedForEditProduct, ProductSelectedCategory);
        //    }

        //    int index = AllCategories.IndexOf(AllCategories.Where(p => p.Id == SelectedForEditProduct.CategoryId).Single());
        //        AllCategories.Remove(AllCategories.Where(p => p.Id == SelectedForEditProduct.CategoryId).Single());
        //        SelectedForEditProduct.Category.Products = DataRepository.GetProductsFromCategory(SelectedForEditProduct.Category);
        //        AllCategories.Insert(index, SelectedForEditProduct.Category);

        //    ClearProduct(obj);
        //}

        //private void ClearProduct(object obj)
        //{
        //    FileName = null;
        //    SelectedProduct = null;
        //    SelectedForEditProduct = null;

        //    ProductImage = null;
        //    ProductName = null;
        //    ProductSelectedCategory = null;
        //    ProductCurrentPrice = null;
        //    ErrorMessage = null;
        //    AddButtonText = "Добавить";
        //}

        //private void ShowEditProductBorder(object obj)
        //{
        //    FileName = "";
        //    ErrorMessage = "";

        //    SelectedForEditProduct = SelectedProduct;
        //    ProductName = SelectedForEditProduct.Name;
        //    ProductCurrentPrice = SelectedForEditProduct.CurrentPrice.ToString();
        //    ProductSelectedCategory = DataRepository.GetCategoriesById(SelectedForEditProduct.CategoryId);
        //    ProductImage = SelectedForEditProduct.Image;
        //    AddButtonText = "Обновить";
        //    ShowProductPanel();
        //}

        //private void DeleteProduct(object obj)
        //{
        //    DataRepository.DeleteProduct(SelectedProduct);
        //    AllCategories.Where(p => p.Id == SelectedProduct.CategoryId).Single().Products.Remove(SelectedProduct);

        //    CategoryModel deletedCategory = AllCategories.Where(p => p.Id == SelectedProduct.CategoryId).Single();
        //    int index = AllCategories.IndexOf(deletedCategory);
        //    AllCategories.Remove(deletedCategory);
        //    SelectedProduct.Category = deletedCategory;
        //    SelectedProduct.Category.Products = DataRepository.GetProductsFromCategory(DataRepository.GetCategoriesById(SelectedProduct.CategoryId));
        //    AllCategories.Insert(index, SelectedProduct.Category);

        //    ClearProduct(obj);
        //}
        //#endregion

        //private void ShowCategoryPanel()
        //{
        //    VisibilityProductBorder = Visibility.Hidden;
        //    VisibilityCategoryBorder = Visibility.Visible;
        //}

        //private void ShowProductPanel()
        //{
        //    VisibilityProductBorder = Visibility.Visible;
        //    VisibilityCategoryBorder = Visibility.Hidden;
        //}
        public delegate void ChangeViewHandler(BaseViewModel viewmodel);
        public event ChangeViewHandler ViewChanged;

        public string CountOfProducts { get; set; }
        public string CountOfCategories { get; set; }
        public string CountOfActiveOrders { get; set; }
        public string CountOfUsers { get; set; }
        public string SummOfOrders { get; set; }
        public string AverageTimeOrders { get; set; }


        private IDataConnection DataRepository { get; set; }
        public ICommand CategoriesCommand { get; }
        public ICommand ProductsCommand { get; }
        public ICommand CustomersCommand { get; }
        public ICommand DashboardCommand { get; }
        //public ICommand SellingReportCommand { get; }
        public ICommand UpdateStatusCommand { get; }

        public DashboardViewModel()
        {
            DataRepository = new DataRepository();
            List<OrderModel> CompletedOrders = DataRepository.GetCompletedOrders();
            if (CompletedOrders.Count > 0)
            {
                AverageTimeOrders = ((int)DataRepository.GetCompletedOrders().Average(p => (p.OrderFulfilled - p.OrderPlaced).TotalMinutes)).ToString();
            }
            else AverageTimeOrders = "0";
            CategoriesCommand = new RelayCommand(ShowCategories);
            ProductsCommand = new RelayCommand(ShowProducts);
            CustomersCommand = new RelayCommand(ShowCustomers);
            DashboardCommand = new RelayCommand(ShowDashboard);
            //SellingReportCommand = new RelayCommand(ShowSellingReport);
            UpdateStatusCommand = new RelayCommand(ShowUpdateStatus);

            CountOfProducts = DataRepository.GetProducts_All().Count.ToString();
            CountOfActiveOrders = DataRepository.GetActiveOrders_All().Count.ToString();
            CountOfCategories = DataRepository.GetCategories_All().Count.ToString(); 
            CountOfUsers = (DataRepository.GetCustomers_Customers().Count + DataRepository.GetCustomers_Managers().Count).ToString();
            SummOfOrders = DataRepository.GetCompletedOrders().Sum(p => p.Price).ToString();
        }

        private void ShowCategories(object obj) => ViewChanged?.Invoke(new CategoriesViewModel());
        private void ShowProducts(object obj) => ViewChanged?.Invoke(new ProductsViewModel()); 
        private void ShowCustomers(object obj) => ViewChanged?.Invoke(new UsersViewModel());
        private void ShowDashboard(object obj) => ViewChanged?.Invoke(new DashboardViewModel()); 
        private void ShowUpdateStatus(object obj) => ViewChanged?.Invoke(new UpdateStatusViewModel());
    }


    //public class TreeViewEx : TreeView
    //{
    //    public static readonly DependencyProperty SelectedItemExProperty = DependencyProperty.Register("SelectedItemEx", typeof(object), typeof(TreeViewEx), new FrameworkPropertyMetadata(default(object))
    //    {
    //        BindsTwoWayByDefault = true
    //    });

    //    public object SelectedItemEx
    //    {
    //        get => GetValue(SelectedItemExProperty);
    //        set
    //        {
    //            if (value != null)
    //            {
    //                SetValue(SelectedItemExProperty, value);
    //            }
    //        }
    //    }

    //    protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
    //    {
    //        if (e.NewValue != null)
    //        {
    //            SelectedItemEx = e.NewValue;
    //            //Array.BinarySearch()
    //        }
    //    }
    //}

    //public class BindingProxy : Freezable
    //{
    //    protected override Freezable CreateInstanceCore()
    //    {
    //        return new BindingProxy();
    //    }

    //    public object Data
    //    {
    //        get { return (object)GetValue(DataProperty); }
    //        set { SetValue(DataProperty, value); }
    //    }

    //    public static readonly DependencyProperty DataProperty =
    //        DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    //}
}
