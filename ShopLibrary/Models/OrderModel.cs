using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PizzaShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFulfilled { get; set; }

        public int StatusId { get; set; }
        public StatusModel Status { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; } = null!;

        [ForeignKey(nameof(AddressId))]
        public int AddressId { get; set; }
        public AddressModel Address { get; set; }
        public string Comment { get; set; }

        public ICollection<OrderDetailModel> OrderDetails { get; set; } = new List<OrderDetailModel>();

        [NotMapped]
        public decimal Price => OrderDetails.Sum(p => p.PriceAtCheckout * p.Quntity);

        public OrderModel(DateTime orderPlaced, DateTime orderFulfilled, string comment)
        {
            OrderPlaced = orderPlaced;
            OrderFulfilled = orderFulfilled;
            Comment = comment;
        }
    }
}