using Application.Repositories.Abstract;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Concrete
{
    public class EfTransmissionRepository : EfGenericRepository<Transmission, Guid, BorusanDbContext>, ITransmissionRepository
    {
        public EfTransmissionRepository(BorusanDbContext context) : base(context)
        {
        }
    }
}
