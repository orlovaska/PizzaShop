using ShopWPFUI.Commands;
using ShopWPFUI.ViewModels.CustomerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels.AdminViewModels
{
    internal class AdminNavigationViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigateAuthorizationCommand { get; }
        public ICommand CategoriesCommand { get; }
        public ICommand ProductsCommand { get; }
        public ICommand CustomersCommand { get; }
        public ICommand DashboardCommand { get; }
        public ICommand SellingReportCommand { get; }
        public ICommand UpdateStatusCommand { get; }

        private void ShowCategories(object obj) => CurrentView = new CategoriesViewModel();
        private void ShowProducts(object obj) => CurrentView = new ProductsViewModel();
        private void ShowCustomers(object obj) => CurrentView = new UsersViewModel();
        private void ShowDashboard(object obj)
        {
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            CurrentView = dashboardViewModel;
            dashboardViewModel.ViewChanged += DashboardViewModel_ViewChanged;
        }

        private void DashboardViewModel_ViewChanged(BaseViewModel viewmodel)
        {
            CurrentView = viewmodel;
        }

        private void ShowSellingReport(object obj) => CurrentView = new SellingReportViewModel();
        private void ShowUpdateStatus(object obj) => CurrentView = new UpdateStatusViewModel();

        public AdminNavigationViewModel(NavigationStore navigationStore)
        {
            NavigateAuthorizationCommand = new NavigateCommand<AuthorizationViewModel>(navigationStore, () => new AuthorizationViewModel(navigationStore));

            CategoriesCommand = new RelayCommand(ShowCategories);
            ProductsCommand = new RelayCommand(ShowProducts);
            CustomersCommand = new RelayCommand(ShowCustomers);
            DashboardCommand = new RelayCommand(ShowDashboard);
            SellingReportCommand = new RelayCommand(ShowSellingReport);
            UpdateStatusCommand = new RelayCommand(ShowUpdateStatus);

            ShowDashboard(null);
        }
    }
}
