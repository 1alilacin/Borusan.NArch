﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fuel : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}