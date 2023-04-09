using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models
{
    public class CartsModel
    {
        public int Id { get; set; }
        public int Quntity { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        [NotMapped]
        public decimal Price => (decimal)Quntity * Product.CurrentPrice;

    }
}
