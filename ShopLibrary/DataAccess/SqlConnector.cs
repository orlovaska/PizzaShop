using Microsoft.EntityFrameworkCore;
using PizzaShop.Migrations;
using PizzaShop.Models;
using ShopLibrary;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShop.DataAccess
{
    public class SqlConnector: DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; } = null!;
        public DbSet<CustomerModel> Customers { get; set; } = null!;
        public DbSet<OrderModel> Orders { get; set; } = null!;
        public DbSet<ProductModel> Products { get; set; } = null!;
        public DbSet<OrderDetailModel> OrderDetails { get; set; } = null!;
        public DbSet<CartsModel> Carts { get; set; } = null!;
        public DbSet<AddressModel> Addresses { get; set; } = null!;
        public DbSet<StatusModel> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(GlobalConfig.ConectionString("Shop"));
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaShop;Integrated Security=True");
        }

        
    }
}
