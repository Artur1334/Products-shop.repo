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
       // private ProductShopModel db = new ProductShopModel();
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
            //Product product1 = db.Products.Find(id);
            Product product = _repository.Select(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.ProductID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Products
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        //}

        // DELETE: api/Products/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.ProductID == id) > 0;
        //}
    }
}