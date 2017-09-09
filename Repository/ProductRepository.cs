using EntitieServices.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitieServices.EntitiProductShop;
using System.Collections;

namespace Repository
{
   public class ProductRepository : IProductRepository
    {
        private readonly  ProductShopModel DbEntitiesContext;
        public ProductRepository()
        {
            this.DbEntitiesContext = new ProductShopModel();
        }
        public IEnumerable<Product> SelectAll()
        {
            return DbEntitiesContext.Products.ToList();
        }

        public Product Select(int? id)
        {
            return DbEntitiesContext.Products.Find(id);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DbEntitiesContext.Dispose();
                }
                disposedValue = true;
            }
        }

        ~ProductRepository()
        {
            Dispose(false);
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

     
        #endregion
    }
}
