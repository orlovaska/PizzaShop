using Microsoft.EntityFrameworkCore;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class DataRepository : IDataConnection
    {
        public CustomerModel CreateCustomer(CustomerModel model)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Add(model);
                context.SaveChanges();

                return model;
            }
        }
        public List<ProductModel> GetProducts_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Products.ToList();
            }
        }
        public List<CustomerModel> GetCustomers_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Customers.ToList();
            }
        }
        public List<string> GetCustomersEmail_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                List<string> Emails = new List<string>();
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    Emails.Add(customer.Email);
                }
                return Emails;
            }
        }
        public List<CategoryModel> GetCategories_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Categories.ToList();
            }
        }
        public List<string> GetCategoryName()
        {
            using (SqlConnector context = new SqlConnector())
            {
                List<string> categoryNames = new List<string>();
                foreach (CategoryModel category in context.Categories.ToList())
                {
                    categoryNames.Add(category.Name);
                }
                return categoryNames;
            }
        }
        public List<ProductModel> GetProductsFromCategory(CategoryModel category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Products.Where(p => p.Category.Id == category.Id).ToList();
            }
        }
        public bool PasswordVerification(string email, string password)
        {
            bool verificationIsSuccess = false;
            using (SqlConnector context = new SqlConnector())
            {
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    if (customer.Email == email && customer.HashPassword == HashingUntil.HashingPassword(password))
                        verificationIsSuccess = true;
                }
            }        //TODO - Исправить вывод - сейчас для тестов 
            return true;
        }
        public void AddCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Customers.Add(customer);
            }
        }
        public void EditCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                //TODO
            }
        }
        public void DeleteCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Customers.Remove(customer);
            }
        }
        public void AddOrder(OrderModel order)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Orders.Add(order);
            }
        }
        public bool EmailIsUnique(string email)
        {
            bool emailIsUnique = true;
            using (SqlConnector context = new SqlConnector())
            {
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    if (customer.Email == email)
                        emailIsUnique = false;
                }
            }        //TODO - Исправить вывод - сейчас для тестов 
            return true;
        }

        public CustomerModel GetByEmail(string email)
        {
            CustomerModel customerModel = new CustomerModel();
            using (SqlConnector context = new SqlConnector())
            {
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    if (customer.Email == email)
                    {
                        customerModel.Id = customer.Id;
                        customerModel.FirstName = customer.FirstName;
                        customerModel.LastName = customer.LastName;
                        customerModel.Email = customer.Email;
                        customerModel.Phone = customer.Phone;
                        customerModel.HashPassword = string.Empty;
                    }

                }
            }
            return customerModel;
        }

        public List<OrderModel> GetActiveOrders(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.Where(p => p.CustomerId == customer.Id && p.Status.Id != 5 && p.Status.Id != 6).ToList();
            }
        }

        public List<OrderModel> GetCompletedOrders(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.Where(p => p.CustomerId == customer.Id && p.Status.Id == 5 || p.Status.Id == 6).ToList();
            }
        }

        public void AddToCart(CustomerModel customer, ProductModel product)
        {
            List<CartsModel> carts = new List<CartsModel>();
            using (SqlConnector context = new SqlConnector())
            {
                carts = context.Carts.Where(p => p.Customer == customer && p.Product == product).ToList();

                if (carts.Count == 0)
                {

                    CustomerModel CurrentCustomer = context.Customers
                    .Where(c => c.Id == customer.Id)
                    .FirstOrDefault();

                    ProductModel CurrentProduct = context.Products
                    .Where(c => c.Id == product.Id)
                    .FirstOrDefault();


                    CartsModel cart1 = new CartsModel();
                    cart1.Customer = CurrentCustomer;
                    cart1.Product = CurrentProduct;                  

                    cart1.Quntity = 1;
                    context.Add(cart1);
                }
                else
                {
                    foreach (CartsModel cart in carts)
                    {
                        cart.Quntity++;
                    }
                }
                context.SaveChanges();
            }
        }

        public List<CartsModel> GetCartByCustomer(CustomerModel customer)
        {
            List<CartsModel> carts = new List<CartsModel>();
            using (SqlConnector context = new SqlConnector())
            { 
                carts = context.Carts.Where(p => p.CustomerId == customer.Id).Include(p => p.Product).ToList();
            }
            return carts;
        }

        public void DeleteFromCart(CustomerModel customer, ProductModel product)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Carts.Single(p => p.CustomerId == customer.Id && p.ProductId == product.Id);
                if (result != null)
                {
                    context.Carts.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        public void ReduceQuntityOfProductFromCart(CustomerModel customer, ProductModel product)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Carts.Single(p => p.CustomerId == customer.Id && p.ProductId == product.Id);
                if (result != null)
                {
                    result.Quntity--;
                    context.SaveChanges();
                }
            }
        }
    }
}
