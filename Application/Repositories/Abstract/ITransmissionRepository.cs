using Domain.Entities;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Abstract
{
    public interface ITransmissionRepository : IGenericRepository<Transmission, Guid>, IAsyncGenericRepository<Transmission, Guid>
    {
    }
}
