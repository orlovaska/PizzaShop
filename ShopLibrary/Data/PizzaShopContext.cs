using Microsoft.EntityFrameworkCore;
using PizzaShop.Models;

namespace PizzaShop.Data
{
    internal class PizzaShopContext: DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; } = null!;
        public DbSet<OrderModel> Orders { get; set; } = null!;
        public DbSet<ProductModel> Products { get; set; } = null!;
        public DbSet<OrderDetailModel> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PizzaShop; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }
}
