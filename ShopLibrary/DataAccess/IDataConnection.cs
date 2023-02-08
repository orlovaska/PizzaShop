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
        bool PasswordVerification(string email, string password);
        bool EmailIsUnique(string email);
        void AddCustomer(CustomerModel customer);
        void EditCustomer(CustomerModel customer);
        void DeleteCustomer(CustomerModel customer);
        CustomerModel GetByEmail(string email);

        OrderModel AddOrder(CustomerModel customer, OrderModel order); 
        void AddOrderDetailsFromCarts(OrderModel order, ICollection<CartsModel> carts);
        List<OrderModel> GetActiveOrders(CustomerModel customer);
        List<OrderModel> GetCompletedOrders(CustomerModel customer);



        List<ProductModel> GetProducts_All();
        List<CustomerModel> GetCustomers_All();
        List<CategoryModel> GetCategories_All();
        List<string> GetCustomersEmail_All();
        List<string> GetCategoryName();
        List<ProductModel> GetProductsFromCategory(CategoryModel category);



        public void DeleteFromCart(CustomerModel customer, ProductModel product);
        public void ReduceQuntityOfProductFromCart(CustomerModel customer, ProductModel product);
        public void AddToCart(CustomerModel customer, ProductModel product);
        public List<CartsModel> GetCartByCustomer(CustomerModel customer);
        void DeleteAllCartsByCustomer(CustomerModel customer);
    }
}
