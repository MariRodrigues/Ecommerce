using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Quantity { get; set; }
        public double Value { get; set; }
        [JsonIgnore]
        public virtual List<ProductSize> ProductSizes { get; set; }
        [JsonIgnore]
        public virtual List<ProductImages> Images { get; set; }
        [JsonIgnore]
        public virtual List<ProductSubcategory> ProductSubcategories { get; set; }

        public Product() { }

        public Product(string name, string description, double value, int quantity)
        {
            Name = name;
            Description = description;
            Status = true;
            CreatedOn = DateTime.Now;
            Value = value;
            Quantity = quantity;
        }
    }

    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public SizeEnum Size { get; set; }
        public int Quantity { get; set; }
    }

    public enum SizeEnum
    {
        PP = 1,
        P = 2,
        M = 3,
        G = 4,
        GG = 5
    }
}
