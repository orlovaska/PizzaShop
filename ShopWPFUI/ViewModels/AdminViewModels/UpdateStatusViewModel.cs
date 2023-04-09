using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using ShopLibrary.Utilities;
using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace ShopWPFUI.ViewModels.AdminViewModels
{
    internal class UpdateStatusViewModel: BaseViewModel
    {
        private OrderModel _selectedOrder;
        public OrderModel SelectedOrder {
            get
            {
                return _selectedOrder;
            }
            set
            {
                if (value != null)
                {
                    _selectedOrder = value;
                }
            }
        }
        private int _widthOrderFulfilledColumn { get; set; }

        public List<StatusModel> StatusesWithoutCancell { get; set; }
        public ObservableCollection<OrderModel> CurrentListOrders { get; set; }


        public List<OrderModel> ActiveOrders { get; set; }
        public List<OrderModel> CompletedOrders { get; set; }
        public List<OrderModel> CancelledOrders { get; set; }

        public int WidthOrderFulfilledColumn
        {
            get 
            { 
                return _widthOrderFulfilledColumn;
            }
            set 
            { 
                _widthOrderFulfilledColumn = value; 
                OnPropertyChanged(nameof(WidthOrderFulfilledColumn));
            }
        }

        private IDataConnection DataRepository { get; set; }
        public ICommand ActiveOrdersCommand { get; }
        public ICommand CompletedOrdersCommand { get; }
        public ICommand CancelledOrdersCommand { get; }

        public ICommand SetNextStatusCommand { get; }
        public ICommand CancelOrderCommand { get; }
        public ICommand CreateExcelReportCommand { get; }

        public UpdateStatusViewModel()
        {
            DataRepository = new DataRepository();
            ActiveOrders = DataRepository.GetActiveOrders_All();
            CompletedOrders = DataRepository.GetCompletedOrders();
            CancelledOrders = DataRepository.GetCancelledOrders();

            CurrentListOrders = new ObservableCollection<OrderModel>(ActiveOrders);
            StatusesWithoutCancell = DataRepository.GetAllStatusWithoutCancell();

            ActiveOrdersCommand = new RelayCommand(ShowActiveOrders);
            CompletedOrdersCommand = new RelayCommand(ShowCompletedOrders);
            CancelledOrdersCommand = new RelayCommand(ShowCancelledOrders);
            SetNextStatusCommand = new RelayCommand(SetNextStatus);
            CancelOrderCommand = new RelayCommand(CancelOrder);
            CreateExcelReportCommand = new RelayCommand(CreateExcelReport);
            WidthOrderFulfilledColumn = 0;

            ExcelUtility excel = new ExcelUtility();
            excel.SaveExcelFile(ActiveOrders);
            excel.SaveExcelFile(CompletedOrders);
            excel.SaveExcelFile(CancelledOrders);//TODO 
        }

        private void CancelOrder(object obj)
        {
            CurrentListOrders.Remove(SelectedOrder);
            DataRepository.ChangeStatus(SelectedOrder, DataRepository.GetCancellationStatus());
            CancelledOrders.Insert(0, SelectedOrder);
        }

        private void CreateExcelReport(object obj)
        {
            ExcelUtility excel = new ExcelUtility();
            excel.SaveExcelFile(SelectedOrder);
        }

        private void SetNextStatus(object obj)
        {

            int index = StatusesWithoutCancell.IndexOf(StatusesWithoutCancell.Where(p => p.Id == SelectedOrder.StatusId).SingleOrDefault());
            if (index != -1 && index != StatusesWithoutCancell.Count - 1)
            {
                int indexOfselectedOrder = CurrentListOrders.IndexOf(SelectedOrder);
                CurrentListOrders.Remove(SelectedOrder);
                DataRepository.ChangeStatus(SelectedOrder, StatusesWithoutCancell[index + 1]);
                SelectedOrder.StatusId = StatusesWithoutCancell[index + 1].Id;
                SelectedOrder.Status = StatusesWithoutCancell[index + 1];
                if (SelectedOrder.StatusId == 5)
                {
                    CompletedOrders.Insert(0, SelectedOrder);
                }
                else CurrentListOrders.Insert(indexOfselectedOrder, SelectedOrder);
            }
        }

        private void ShowCancelledOrders(object obj)
        {
            WidthOrderFulfilledColumn = 0;

            CurrentListOrders.Clear();
            foreach (var order in CancelledOrders)
                CurrentListOrders.Add(order);
        }

        private void ShowCompletedOrders(object obj)
        {
            WidthOrderFulfilledColumn = 150;

            CurrentListOrders.Clear();
            foreach (var order in CompletedOrders)
                CurrentListOrders.Add(order);
        }

        private void ShowActiveOrders(object obj)
        {
            WidthOrderFulfilledColumn = 0;

            CurrentListOrders.Clear();
            foreach (var order in ActiveOrders)
                CurrentListOrders.Add(order);
        }
    }
}
