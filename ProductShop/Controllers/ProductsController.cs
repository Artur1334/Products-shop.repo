using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShop.Models;

namespace ProductShop.Controllers
{
    public class ProductsController : Controller
    {
         
        public ActionResult Index()
        {
            CategorieClient _categorieClient = new CategorieClient();
            ViewBag.listcategorie = _categorieClient.FindAll();
            ProductClient _productClient = new ProductClient();
            ViewBag.listProduct = _productClient.FindAll();
            return View();
        }

        public ActionResult SearchByCatigory(int id=0)
        {
            CategorieClient _categorieClient = new CategorieClient();
            ViewBag.listcategorie = _categorieClient.FindAll();
            ProductClient _productClient = new ProductClient();
            ViewBag.listProduct = _productClient.FindCategory(id);
            return View("index");
        }
    }
}