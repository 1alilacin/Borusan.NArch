using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public DateTime ModelDate { get; set; }
        public Guid BrandId { get; set; }
        public Guid TransmissionId { get; set; }
        public virtual Brand Brand { get; set; }


    }
}
