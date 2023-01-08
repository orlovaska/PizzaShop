using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.DataAccess
{
    public interface IDataConnection
    {
        CustomerModel CreateCustomer(CustomerModel customer);
        List<ProductModel> GetProducts_All();
        List<CustomerModel> GetCustomers_All();
        List<CategoryModel> GetCategories_All();
        List<string> GetCustomersEmail_All();
        List<string> GetCategoryName();
        List<ProductModel> GetProductsFromCategory(string category);
        //List<CategoryModel> GetCategory_All();
    }
}
