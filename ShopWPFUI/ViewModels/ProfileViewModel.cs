using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public int CustomerID { get; set; }

        public ProfileViewModel()
        {
            CustomerID = 100528;
        }
        public override string ToString()
        {
            return "Как это сделать";
        }
    }
}
