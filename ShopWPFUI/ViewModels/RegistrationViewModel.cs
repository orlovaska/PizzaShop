using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels
{
    internal class RegistrationViewModel : BaseViewModel
    {
        private bool _isViewVisible = true;

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }
    }
}
