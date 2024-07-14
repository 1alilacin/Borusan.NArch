using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Model.Queries.GetAll
{
    public class GetAllModelQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ModelDate { get; set; }
        public Guid BrandId { get; set; }
        public Guid TransmissionId { get; set; }
    }
}
