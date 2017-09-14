using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Categorie { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string imgpath { get; set; }
    }
}