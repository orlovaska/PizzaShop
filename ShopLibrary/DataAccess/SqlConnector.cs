using Microsoft.EntityFrameworkCore;
using PizzaShop.Models;
using ShopLibrary;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShop.DataAccess
{
    public class SqlConnector: DbContext, IDataConnection
    {
        public DbSet<CategoryModel> Categories { get; set; } = null!;
        public DbSet<CustomerModel> Customers { get; set; } = null!;
        public DbSet<OrderModel> Orders { get; set; } = null!;
        public DbSet<ProductModel> Products { get; set; } = null!;
        public DbSet<OrderDetailModel> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(GlobalConfig.ConectionString("Shop"));
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PizzaShop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

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

        public List<ProductModel> GetProductsFromCategory(string category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Products.Where(p => p.Category.Name == category).ToList();
            }
        }
    }
}
