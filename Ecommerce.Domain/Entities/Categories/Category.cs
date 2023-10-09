using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Subcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [JsonIgnore]
        public virtual List<Subcategory> Subcategories { get; set; }

        public Category(string name)
        {
            Name = name;
            CreatedOn = DateTime.Now;
            Status = true;
        }
    }
}
