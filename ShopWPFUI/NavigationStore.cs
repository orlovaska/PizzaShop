using ShopWPFUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public void OnCurrentViewModelChanged([CallerMemberName] string propName = null)
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
