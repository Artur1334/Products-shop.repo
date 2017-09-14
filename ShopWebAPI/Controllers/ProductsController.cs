using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EntitieServices.EntitiProductShop;
using EntitieServices.IRepository;
using Repository;
using System.Collections;

namespace ShopWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _repository;
        private ProductsController()
        {
            this._repository =new ProductRepository();
        }

        // GET: api/Products
        public IEnumerable<Product> GetProducts()
        {

            return _repository.SelectAll();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _repository.Select(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}