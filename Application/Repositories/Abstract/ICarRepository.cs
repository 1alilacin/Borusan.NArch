using Application.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Abstract
{
    public interface ICarRepository : IGenericRepository<Car, Guid>, IAsyncGenericRepository<Car, Guid>
    {
    }
}
