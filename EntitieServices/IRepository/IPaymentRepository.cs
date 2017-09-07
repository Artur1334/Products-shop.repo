using EntitieServices.EntitiProductShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitieServices.IRepository
{
   public interface IPaymentRepository : IDisposable
    {
        void Create(Payment item);
        void Save();
    }
}
