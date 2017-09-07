using EntitieServices.EntitiProductShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitieServices.IRepository
{
 public interface ICategorieRepository : IDisposable
    {
        IEnumerable SelectAll();
        Category Select(int? id);
    }
}
