using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Abstract
{
    public interface IAsyncGenericRepository<T, TId> where T : class
    {
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T t, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T t);
        Task<T> DeleteAsync(T t);
    }
}
