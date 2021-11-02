﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Book : IProduct
    {
        public string Name { get; set; }
        public double? Discount { get; set; }
        public double Price { get; set; }
    }
}
