using EntitieServices.EntitiProductShop;
using ProductShop.ItemClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductShop.Mapping
{
    public static class OrderMapper
    {
        public static Order To_Order(this Item it,int kk)
        {
            Order VMBank = new Order()
            {
                PaymentId = kk,
                ProductQuantity = it.Quantity,
                ProductId= it.Product.ProductID,
            };
            return VMBank;
        }
        public static List<Order> To_order_Create_Cart(this List<Item> itcart,int kk)
        {
            List<Order> _ord = new List<Order>();
            foreach (var item in itcart)
            {
                _ord.Add(item.To_Order(kk));
            }
            return _ord;
        }
    }
}