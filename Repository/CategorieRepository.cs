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
  public  class CategorieRepository : ICategorieRepository
    {
        private ProductShopModel DbEntitiesContext;

        public CategorieRepository()
        {
            this.DbEntitiesContext = new ProductShopModel();
          

        }
        public Category Select(int? id)
        {
            return DbEntitiesContext.Categories.Find(id);
        }

        public IEnumerable SelectAll()
        {
            return DbEntitiesContext.Categories.ToList();
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

        ~CategorieRepository()
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
