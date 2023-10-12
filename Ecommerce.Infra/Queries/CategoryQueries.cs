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

        public async Task<IEnumerable<CategoryViewModel>> GetCategoryWithSubcategories()
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

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(CategoryViewModel), "Id");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(SubcategoryViewModel), "SubcategoryId");

            return Slapper.AutoMapper.MapDynamic<CategoryViewModel>(result);
        }
    }
}
