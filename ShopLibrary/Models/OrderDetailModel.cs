namespace PizzaShop.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int Quntity { get; set; }
        public decimal PriceAtCheckout { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
    }
}