using PizzaShop.DataAccess;
using ShopLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels.AdminViewModels
{
    internal class SellingReportViewModel: BaseViewModel
    {
        private IDataConnection DataRepository { get; set; }
        public SellingReportViewModel()
        {
            DataRepository = new DataRepository();
        }
    }
}
