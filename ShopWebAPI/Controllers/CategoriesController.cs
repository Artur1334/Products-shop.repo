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

namespace ShopWebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategorieRepository _repository;
        private CategoriesController()
        {
            this._repository = new CategorieRepository();
        }

        // GET: api/Categories
        public IEnumerable<Category> GetCategories()
        {
            return _repository.SelectAll();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = _repository.Select(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCategory(int id, Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != category.CategorieID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
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

        // POST: api/Categories
        //[ResponseType(typeof(Category))]
        //public IHttpActionResult PostCategory(Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _repository.Select(id).Categories.Add(category);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = category.CategorieID }, category);
        //}

        // DELETE: api/Categories/5
        //[ResponseType(typeof(Category))]
        //public IHttpActionResult DeleteCategory(int id)
        //{
        //    Category category = db.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Categories.Remove(category);
        //    db.SaveChanges();

        //    return Ok(category);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool CategoryExists(int id)
        //{
        //    return db.Categories.Count(e => e.CategorieID == id) > 0;
        //}
    }
}