using PizzaShop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace PizzaShop.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public ICollection<ProductModel> Products { get; set; }
    }
    //Add-Migration AddCategory -project ShopLibrary
    //Update-Database -project ShopLibrary
}
