﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Commands.Delete
{
    public class DeleteColorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}