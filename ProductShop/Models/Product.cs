using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        //[Required]
        //[StringLength(50)]
        public string ProductName { get; set; }
        public int Categorie { get; set; }
        public decimal Quantity { get; set; }
        //[Column(TypeName = "money")]
        public decimal Price { get; set; }
        //[StringLength(50)]
        public string ProductDescription { get; set; }
        //[StringLength(70)]
        public string imgpath { get; set; }
    }
}