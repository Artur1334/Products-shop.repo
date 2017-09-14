using ProductShop.ItemClass;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntitieServices.EntitiProductShop;

namespace ProductShop.Controllers
{
    public class CartController : Controller
    {
       public List<Item> cart;
        ProductClient _productClient = new ProductClient();
        public ActionResult Add(EntitieServices.EntitiProductShop.Product pr)
        {
            if (Session["cart"] == null)
            {
                 cart = new List<Item>();
                cart.Add(new Item((Models.Product)_productClient.FindProduct(pr.ProductID),1));
                Session["cart"] = cart;
                ViewBag.cart = cart.Count();
                Session["count"] = 1;
            }
            else
            {
                 cart = (List<Item>)Session["cart"];
                int index = IsExisting(pr.ProductID);
                    if(index==-1)
                { 
                        cart.Add(new Item((Models.Product)_productClient.FindProduct(pr.ProductID), 1));
                Session["cart"] = cart;
                ViewBag.cart = cart.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
            }
            return RedirectToAction("Index", "Products");
        }
        private int IsExisting(int id)
        {
             cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductID==id)
                    return i;
            return -1; 
        }

        public ActionResult Remove(EntitieServices.EntitiProductShop.Product pr)
        {
            cart = (List<Item>)Session["cart"];
            cart.RemoveAll(x => x.Product.ProductID == pr.ProductID);
            Session["cart"] = cart;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "Cart");
        }
        public ActionResult Myorder()
        {
            CategorieClient _categorieClient = new CategorieClient();
            ViewBag.listcategorie = _categorieClient.FindAll();
            return View(Session["cart"]);
        }

        public ActionResult ChakQuantity(List<Item> cart)
        {
             cart = (List<Item>)Session["cart"];
            foreach (Item it in cart)
            {
                if (it.Quantity>=it.Product.Quantity)
                {
                    ViewBag.Message = "we do not have so much quantity"+it.Product.ProductName;
                    return RedirectToAction("Myorder", "Cart");
                }   
            }
            TempData["cart"] = cart;
            return RedirectToAction("Create", "Order");

        }
    }
}