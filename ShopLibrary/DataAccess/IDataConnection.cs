using PizzaShop.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaShop.DataAccess
{
    public interface IDataConnection
    {
        bool PasswordVerification(string email, string password);
        bool EmailIsUnique(string email);
        void AddCustomer(CustomerModel customer, RoleModel role, string password);
        void EditCustomer(CustomerModel customer);
        //void DeleteCustomer(CustomerModel customer);
        CustomerModel GetByEmail(string email);
        List<CustomerModel> GetCustomers_Managers();
        List<CustomerModel> GetCustomers_Customers();



        List<OrderDetailModel> GetOrderDetails_ByOrder(OrderModel order);
        void AddOrderDetailsFromCarts(OrderModel order, ICollection<CartsModel> carts);

        OrderModel AddOrder(CustomerModel customer, OrderModel order, AddressModel address);
        //List<OrderModel> GetOrders_All();
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



        public void DeleteFromCart(CustomerModel customer, ProductModel product);
        public void ReduceQuntityOfProductFromCart(CustomerModel customer, ProductModel product);
        public void AddToCart(CustomerModel customer, ProductModel product);
        public List<CartsModel> GetCartByCustomer(CustomerModel customer);
        void DeleteAllCartsByCustomer(CustomerModel customer);

        public List<RoleModel> GelAllRoles();
    }
}
