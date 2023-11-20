using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Subcategories
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual List<ProductSubcategory> ProductSubcategories { get; set; }

        public Subcategory(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
            Status = true;
            CreatedOn = DateTime.Now;
        }

        public Subcategory(string name, Category category)
        {
            Name = name;
            Category = category;
            Status = true;
            CreatedOn = DateTime.Now;
        }
    }
}

