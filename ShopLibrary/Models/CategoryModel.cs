using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PizzaShop.Models
{
    public class CategoryModel: ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public ICollection<ProductModel> Products { get; set; }

        public CategoryModel()
        {

        }

        public CategoryModel(int id, string name, byte[] image, ICollection<ProductModel> products)
        {
            Id = id;
            Name = name;
            Image = image;
            Products = products;
        }

        public object Clone() => new CategoryModel(Id, Name, Image, Products);
    }
    //Add-Migration AddCategory -project ShopLibrary
    //Update-Database -project ShopLibrary
}
