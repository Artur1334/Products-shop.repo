using EntitieServices.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitieServices.EntitiProductShop;

namespace Repository
{
    class OrderRepository : IOrderRepository
    {
        private ProductShopModel DbEntitiesContext;
        public OrderRepository()
        {
            this.DbEntitiesContext = new ProductShopModel();
        }
        public void Create(Order item)
        {
            DbEntitiesContext.Orders.Add(item);
        }

        public void Save()
        {
            DbEntitiesContext.SaveChanges();
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

        ~OrderRepository()
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
