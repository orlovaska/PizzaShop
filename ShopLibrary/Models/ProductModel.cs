using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column (TypeName = "decimal(6 ,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        //Add-Migration AddPic -project ShopLibrary
        //Update-Database -project ShopLibrary
    }
}
