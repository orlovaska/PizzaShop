using PizzaShop.DataAccess;
using PizzaShop.Migrations;
using PizzaShop.Models;
using ShopLibrary;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels
{
    internal class CatalogViewModel : BaseViewModel
    {
        public delegate void MethodContainer(CategoryModel selectedCatedory);
        public event MethodContainer onCount = null;

        public CategoryModel _selectedCatedory;
        public CategoryModel SelectedCatedory
        {
            get
            {
                return _selectedCatedory;
            }

            set
            {
                
                _selectedCatedory = value;
                onCount?.Invoke(SelectedCatedory);
                OnPropertyChanged(nameof(SelectedCatedory));
            }
        }



        public List<CategoryModel> Categories { get; set; }

        //public ICommand SelectCategoryCommand { get; set; }
        private IDataConnection DataRepository { get; set; }

        public CatalogViewModel()
        {
            DataRepository = new DataRepository();
            Categories = DataRepository.GetCategories_All();
            //SelectCategoryCommand = new RelayCommand(GetCategory);
        }


    }
}
