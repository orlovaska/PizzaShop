using System.Collections.Generic;

namespace PizzaShop.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string HashPassword { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        public RoleModel Role { get; set; }

        public ICollection<OrderModel> Orders { get; set; } = null!;
        public ICollection<AddressModel> Addresses { get; set; } = null!;

        public CustomerModel(string firstName, string lastName, string hashPassword, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            HashPassword = hashPassword;
            Email = email;
        }

        public CustomerModel()
        {
        }
    }
}
