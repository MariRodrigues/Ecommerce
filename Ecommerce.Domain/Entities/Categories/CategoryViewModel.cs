using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<SubcategoryViewModel> Subcategories { get; set; }
    }

    public class SubcategoryViewModel
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public bool SubcategoryStatus { get; set; }
    }
}
