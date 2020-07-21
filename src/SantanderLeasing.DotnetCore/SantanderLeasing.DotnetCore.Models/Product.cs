﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SantanderLeasing.DotnetCore.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
    }
}