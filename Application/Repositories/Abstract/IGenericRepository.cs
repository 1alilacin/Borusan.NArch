using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Abstract
{
    public interface IGenericRepository<T, TId> where T : class
    {
        List<T> GetAll(); // list of product 
        T Insert(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(TId id);
    }
}
