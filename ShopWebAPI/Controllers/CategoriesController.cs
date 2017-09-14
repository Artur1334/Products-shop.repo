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