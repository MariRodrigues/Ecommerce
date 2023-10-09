using AutoMapper;
using Ecommerce.Application.Commands.Category;
using Ecommerce.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        { 
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
