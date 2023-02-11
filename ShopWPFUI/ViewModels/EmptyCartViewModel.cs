using ShopWPFUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static ShopWPFUI.ViewModels.CartViewModel;

namespace ShopWPFUI.ViewModels
{
    internal class EmptyCartViewModel
    {
        public event EventHandler ShowsCatalog;

        public ICommand ShowsCatalogCommand { get; }

        public EmptyCartViewModel()
        {
            ShowsCatalogCommand = new RelayCommand(OnShowsCatalog);
        }

        private void OnShowsCatalog(object obj)
        {
            ShowsCatalog?.Invoke(this, EventArgs.Empty);
        }
    }
}
