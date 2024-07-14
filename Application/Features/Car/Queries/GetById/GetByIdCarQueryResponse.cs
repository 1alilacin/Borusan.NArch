﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetById
{
    public class GetByIdCarQueryResponse
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }
        public Guid ModelId { get; set; }
        public Guid ColorId { get; set; }
    }
}
