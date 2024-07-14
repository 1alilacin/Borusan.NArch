using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : BaseEntity<Guid>
    {
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }
        public Guid ModelId { get; set; }
        public Guid ColorId { get; set; }
        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }

    }
}
