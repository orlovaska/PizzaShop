using ShopWPFUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPFUI.Commands
{
    internal class NavigateCommand<ViewModel> : ICommand
        where ViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModel> _createViewModel;

        public event EventHandler? CanExecuteChanged;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModel> createViewModel)
        {
            _createViewModel = createViewModel;
            _navigationStore = navigationStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
