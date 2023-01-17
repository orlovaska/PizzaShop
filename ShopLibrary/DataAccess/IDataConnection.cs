﻿using PizzaShop.Models;
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

        void AddOrder(OrderModel order);


        List<ProductModel> GetProducts_All();
        List<CustomerModel> GetCustomers_All();
        List<CategoryModel> GetCategories_All();
        List<string> GetCustomersEmail_All();
        List<string> GetCategoryName();
        List<ProductModel> GetProductsFromCategory(CategoryModel category);
    }
}
