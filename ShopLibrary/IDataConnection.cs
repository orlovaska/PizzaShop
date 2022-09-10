using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public interface IDataConnection
    {
        CustomerModel CreateCustomer(CustomerModel model);
    }
}
