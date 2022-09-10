using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<OrderModel> Orders { get; set; } = null!;

    }
}
