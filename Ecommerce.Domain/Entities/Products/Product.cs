﻿using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Subcategories;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public double Height { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        [JsonIgnore]
        public virtual List<ProductImages> Images { get; set; }
        [JsonIgnore]
        public virtual List<ProductSubcategory> ProductSubcategories { get; set; }
    }
}
