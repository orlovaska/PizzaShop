using Microsoft.EntityFrameworkCore;
using PizzaShop.Models;
using System.Linq;

namespace PizzaShop.DataAccess
{
    public class SqlConnector : DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; } = null!;
        public DbSet<CustomerModel> Customers { get; set; } = null!;
        public DbSet<OrderModel> Orders { get; set; } = null!;
        public DbSet<ProductModel> Products { get; set; } = null!;
        public DbSet<OrderDetailModel> OrderDetails { get; set; } = null!;
        public DbSet<CartsModel> Carts { get; set; } = null!;
        public DbSet<AddressModel> Addresses { get; set; } = null!;
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaShop;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Применение настроек DeleteBehavior.Restrict для всех внешних ключей
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


    }
}
