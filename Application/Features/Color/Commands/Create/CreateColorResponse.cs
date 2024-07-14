using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Commands.Create
{
    public class CreateColorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
