using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Commands.Create
{
    public class CreateFuelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
