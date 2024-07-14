using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Concrete
{
    public class EfCarRepository : EfGenericRepository<Car, Guid, BorusanDbContext>, ICarRepository
    {
        public EfCarRepository(BorusanDbContext context) : base(context)
        {
        }
    }
}
