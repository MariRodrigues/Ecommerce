using Dapper;
using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Queries;
using Ecommerce.Infra.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Queries
{
    public class CategoryQueries : ICategoryQueries
    {
        public readonly SqlConnection _connection;

        public CategoryQueries(AppDbContext context)
        {
            _connection = new SqlConnection(context.Database.GetConnectionString());
        }

        public async Task<IEnumerable<CategorySubcategoryViewModel>> GetCategoryWithSubcategories()
        {
            var query = @"SELECT 
                                   c.[Id]
                                  ,c.[Name]
                                  ,c.[Status]
                                  ,c.[CreatedOn]
                                  ,c.[UpdatedOn]
                                  ,s.ID as Subcategories_SubcategoryId
	                              ,s.Name as Subcategories_SubcategoryName
                                  ,s.Status as Subcategories_SubcategoryStatus
                          FROM [Categories] c
                          LEFT JOIN Subcategories s ON s.CategoryId = c.Id ";

            var result = await _connection.QueryAsync(query);

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(CategorySubcategoryViewModel), "Id");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(SubcategoryViewModel), "SubcategoryId");

            return Slapper.AutoMapper.MapDynamic<CategorySubcategoryViewModel>(result);
        }

        public async Task<IEnumerable<CategorySubcategoryViewModel>> GetCategoryWithProducts()
        {
            var query = @"SELECT 
                            c.[Id]
                            ,c.[Name]
                            ,c.[Status]
                            ,c.[CreatedOn]
                            ,c.[UpdatedOn]
                            ,s.ID as Subcategories_SubcategoryId
	                        ,s.Name as Subcategories_SubcategoryName
                            ,s.Status as Subcategories_SubcategoryStatus
                            ,p.Name as Subcategories_Products_ProductName
                            ,p.Id as Subcategories_Products_ProductId
                            ,p.Description as Subcategories_Products_Description
                            ,p.Status as Subcategories_Products_Status
                            ,p.CreatedOn as Subcategories_Products_CreatedOn
                            ,p.UpdatedOn as Subcategories_Products_UpdatedOn
                            ,p.Height as Subcategories_Products_Height
                            ,p.Color as Subcategories_Products_Color
                            ,p.Size as Subcategories_Products_Size
                            ,p.Width as Subcategories_Products_Width
                            ,p.Weight as Subcategories_Products_Weight
                            ,p.Value as Subcategories_Products_Value
							,p_images.Url as Subcategories_Products_Images_ImageUrl
							,p_images.Id as Subcategories_Products_Images_ImageId

                          FROM [Categories] c

                          LEFT JOIN Subcategories s ON s.CategoryId = c.Id
						  LEFT JOIN ProductSubcategories ps ON ps.SubcategoryId = s.Id
						  LEFT JOIN Products p ON p.Id = ps.ProductId 
						  LEFT JOIN ProductImages p_images ON p_images.ProductId = p.Id";

            var result = await _connection.QueryAsync(query);

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(CategorySubcategoryViewModel), "Id");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(SubcategoryViewModel), "SubcategoryId");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ProductViewModel), "ProductId");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ProductImagesViewModel), "ImageId");

            return Slapper.AutoMapper.MapDynamic<CategorySubcategoryViewModel>(result);
        }

    }
}
