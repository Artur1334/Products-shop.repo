using EntitieServices.EntitiProductShop;
using EntitieServices.IRepository;
using ProductShop.ItemClass;
using ProductShop.Mapping;
using ProductShop.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProductShop.Controllers
{
    public class OrderController : Controller
    {
        public List<Item> cart;
        protected IPaymentRepository _repository;
        protected IOrderRepository _repoorder;
        protected IProductRepository _repositoryproduct;
        public OrderController()
        {
            this._repository = new PaymentRepository();
            this._repoorder = new OrderRepository();
            this._repositoryproduct =new ProductRepository();
        }
        // GET: Order
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PaymentViewModel pvm)
        {
            pvm.OrderDate = DateTime.Now;
            cart = (List<Item>)TempData["cart"];
            if (ModelState.IsValid)
            {
                Payment _payment = PaymentMapper.To_Payment_Create_ViewModel(pvm);
                _repository.Create(_payment);
                _repository.Save();
                List<Order> order = OrderMapper.To_order_Create_Cart(cart, _payment.PaymentID);
                foreach (Order ord in order)
                {
                    _repoorder.Create(ord);
                    _repoorder.Save();
                    EntitieServices.EntitiProductShop.Product pr =  _repositoryproduct.Select(ord.ProductId);
                    pr.Quantity = pr.Quantity - ord.ProductQuantity;
                    _repositoryproduct.Save();                      
                }
            }
                Session["cart"] = null;
                return RedirectToAction("Index", "Products");
        }
        protected override void Dispose(bool disposing)
        {
            if (_repository != null)
            {
                _repository.Dispose();
                _repoorder.Dispose();
                _repositoryproduct = null;
            }

            base.Dispose(disposing);
        }

    }

}