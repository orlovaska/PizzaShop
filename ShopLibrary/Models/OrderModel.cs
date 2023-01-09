using System;
using System.Collections.Generic;

namespace PizzaShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFulfilled { get; set; }

        public int StatusId { get; set; }
        public StatusModel Status { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; } = null!;

        public ICollection<OrderDetailModel> OrderDetails { get; set; } = null!;
    }
}