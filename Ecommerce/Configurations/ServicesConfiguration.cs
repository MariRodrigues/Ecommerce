using Ecommerce.Domain;
using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infra;
using Ecommerce.Infra.Data;
using Ecommerce.Infra.Queries;
using Ecommerce.Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Ecommerce.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImagesRepository, ProductImagesRepository>();
            services.AddScoped<IProductSubcategoryRepository, ProductSubcategoryRepository>();
            services.AddScoped<IProductSizesRepository, ProductSizesRepository>();

            var assembly = AppDomain.CurrentDomain.Load("Ecommerce.Application");
            services.AddMediatR(assembly);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services
                .AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            return services;
        }
    }
}
