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
        public string ImageUrl { get; set; }
        public ICollection<ProductModel> Products { get; set; }

        public CategoryModel()
        {

        }

        public CategoryModel(int id, string name, string ImageUrl, ICollection<ProductModel> products)
        {
            Id = id;
            Name = name;
            ImageUrl = ImageUrl;
            Products = products;
        }

        public object Clone() => new CategoryModel(Id, Name, ImageUrl, Products);
    }
    //Add-Migration AddCategory -project ShopLibrary
    //Update-Database -project ShopLibrary
}
