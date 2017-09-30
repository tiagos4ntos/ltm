﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTM.WebApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}