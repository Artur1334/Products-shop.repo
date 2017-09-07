using EntitieServices.EntitiProductShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitieServices.IRepository
{
   public interface IProductRepository : IDisposable
    {
        IEnumerable SelectAll();
        Product Select(int? id);
    }
}
