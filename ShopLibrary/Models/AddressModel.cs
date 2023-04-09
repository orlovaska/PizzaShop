namespace PizzaShop.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public bool IsSelected { get; set; }
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
