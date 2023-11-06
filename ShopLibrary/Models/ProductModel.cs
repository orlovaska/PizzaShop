using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace PizzaShop.Models
{
    public class ProductModel: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(6 ,2)")]
        public decimal CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int WeightInGrams { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public ProductModel(int id, string name, decimal currentPrice, string image, int categoryId)
        {
            Id = id;
            Name = name;
            ImageUrl = image;
            CurrentPrice = currentPrice;
            CategoryId = categoryId;
        }
        public ProductModel()
        {

        }
        public object Clone() => new ProductModel(Id, Name, CurrentPrice, ImageUrl, CategoryId);
    }
}
