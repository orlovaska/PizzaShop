using PizzaShop.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaShop.DataAccess
{
    public interface IDataConnection
    {
        bool PasswordVerification(string email, string password);
        bool EmailIsUnique(string email);
        void AddCustomer(string firstName,
  string lastName,
  string email,
  string phone,
  string password, 
  int roleId);
        void EditUser(int userId, string firstName,
  string lastName,
  string email,
  string phone);
        CustomerModel GetByEmail(string email);
        List<CustomerModel> GetCustomers_Managers();
        List<CustomerModel> GetCustomers_Customers();



        List<OrderDetailModel> GetOrderDetails_ByOrder(OrderModel order);
        void AddOrderDetailsFromCarts(int orderId);
        OrderModel AddNewOrder(int customerId, int addressId, string comment);
        List<OrderModel> GetActiveOrders_All();
        List<OrderModel> GetCompletedOrders();
        List<OrderModel> GetCancelledOrders();
        List<OrderModel> GetActiveOrdersByCustomer(CustomerModel customer);
        List<OrderModel> GetCompletedOrdersByCustomer(CustomerModel customer);
        OrderModel ChangeStatus(OrderModel order, StatusModel status);



        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts_All();
        List<ProductModel> GetProductsFromCategory(CategoryModel category);
        ProductModel AddProduct(ProductModel product, CategoryModel category);
        ProductModel EditProduct(ProductModel product, CategoryModel category);
        void DeleteProduct(ProductModel product);


        List<CategoryModel> GetCategories_All();
        void DeleteCategory(CategoryModel category);
        CategoryModel AddCategory(CategoryModel category);
        CategoryModel EditCategory(CategoryModel category);



        public void DeleteFromCart(int customerId, int productId);
        public void ReduceQuntityOfProductFromCart(int customerId, int productId);
        public void AddToCart(int customerId, int productId);
        public List<CartsModel> GetCartByCustomer(int customerId);
        void DeleteAllCartsByCustomer(int customerId);


        public List<RoleModel> GetAllRoles();
        public RoleModel GetCustomerRole();

        public AddressModel AddAddress(int customerId, string addresss);
    }
}
