using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Categories
{
    public class CategorySubcategoryViewModel
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
        public List<ProductViewModel> Products { get; set; }
    }

    public class ProductViewModel
    {
        public int ProductId { get; set;}
        public string ProductName { get; set;}
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public double Height { get; set; }
        public int Size { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        public List<ProductImagesViewModel> Images { get; set; }
    }


    public class ProductImagesViewModel
    {
        public int ImageId { get; set; }
        public string ImageUrl  { get; set; }   
    }
}
