using EntitieServices.EntitiProductShop;
using EntitieServices.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class PaymentRepository: IPaymentRepository
    {
        private ProductShopModel DbEntitiesContext;
        public PaymentRepository()
        {
            this.DbEntitiesContext = new ProductShopModel();
        }
        public void Create(Payment item)
        {
            DbEntitiesContext.Payments.Add(item);
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

        ~PaymentRepository()
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
