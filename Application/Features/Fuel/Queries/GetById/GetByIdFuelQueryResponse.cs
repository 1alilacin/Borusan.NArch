using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Queries.GetById
{
    public class GetByIdFuelQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
