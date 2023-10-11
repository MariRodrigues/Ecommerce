using AutoMapper;
using Ecommerce.Domain.Entities.Subcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Profiles
{
    public class SubcategoryProfile : Profile
    {
        public SubcategoryProfile()
        {
            CreateMap<Subcategory, SubcategoryViewModel>();
        }
    }
}
