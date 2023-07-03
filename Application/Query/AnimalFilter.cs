﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stgen.Domain.Enums;

namespace Stgen.Application.Query
{
    public class AnimalFilter
    {
        public int? AnimalId { get; set; }
        public string? Name { get; set; }
        public Sex? Sex { get; set; }
        public Status? Status { get; set; }
    }
}
