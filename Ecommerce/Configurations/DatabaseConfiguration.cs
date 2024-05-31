using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void Initialize(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())

            using (var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                Log.Information("Trying to check for pending migrations");
                // Verifica se o banco de dados existe
                if (context.Database.GetPendingMigrations().Any())
                {
                    try
                    {
                        Log.Information("Trying to create and migrate database");
                        context.Database.Migrate();
                        Log.Information("Migration done");
                    }
                    catch (SqlException exception) when (exception.Number == 1801)
                    {
                        Log.Information("Database already exists.");
                    }
                }

                // Verifica se a tabela categoria possui algum dado cadastrado
                if (context.Categories.Any())
                {
                    return;
                }

                Log.Information("Populating database");

                // Categorias
                List<Category> categories = new()
                {
                    new Category("Acessórios"),
                    new Category("Vestuário"),
                    new Category("Temas"),
                    new Category("Presentes")
                };
                context.Categories.AddRange(categories);

                // Subcategorias
                List<Subcategory> subcategories = new()
                {
                    new Subcategory("Camisetas", categories[1]),
                    new Subcategory("Calças", categories[1]),
                    new Subcategory("Saias", categories[1]),
                    new Subcategory("Chaveiros", categories[0]),
                    new Subcategory("Porta-Copos", categories[0]),
                    new Subcategory("Games", categories[2]),
                    new Subcategory("Geek", categories[2]),
                    new Subcategory("Harry Potter", categories[2])
                };
                context.Subcategories.AddRange(subcategories);

                // Produtos
                List<Product> products = new() {
                    new Product
                    {
                        Name = "Urso Polar Esportista Coca-Cola",
                        Description = "Urso POLAR Esportista da Coca-Cola - Oficial",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 49.99
                    },
                    new Product
                    {
                        Name = "Urso Polar Esportista Coca-Cola - Karatê",
                        Description = "Urso POLAR Esportista da Coca-Cola - Oficial",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 49.99,
                        Quantity = 23
                    },
                    new Product
                    {
                        Name = "Caderno Avatar 2 - 10 matérias",
                        Description = "Caderno Avatar 2 - 10 matérias",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 24.99,
                        Quantity = 76
                    },
                    new Product
                    {
                        Name = "DVD Blue-ray - A fuga das Galinhas",
                        Description = "DVD Blue-ray - A fuga das Galinhas",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 14.99,
                        Quantity = 340
                    },
                    new Product
                    {
                        Name = "Chaveiro Genshing Impact - Qiqi",
                        Description = "Chaveiro Genshing Impact - Qiqi",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 14.99,
                        Quantity = 98
                    },
                    new Product
                    {
                        Name = "Caneca Valorant - Sova",
                        Description = "Caneca Valorant - Sova",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 14.99, 
                        Quantity = 12
                    },
                    new Product
                    {
                        Name = "Caneca Dev - Visual Studio",
                        Description = "Caneca Dev - Visual Studio Cheat sheet",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Value = 14.99,
                        Quantity = 20
                    }
                };
                context.Products.AddRange(products);

                // Imagens para produtos
                List<ProductImages> productsImages = new()
                {
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/mzzKWdy/1.png",
                        Product = products[0]
                    },
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/crT6yJL/2.png",
                        Product = products[1]
                    },
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/QPKrs14/3.png",
                        Product = products[2]
                    },
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/557MTwm/4.png",
                        Product = products[3]
                    },
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/CwdBLw1/5.png",
                        Product = products[4]
                    },
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/9NFzmZ7/6.png",
                        Product = products[6]
                    },
                    new ProductImages
                    {
                        Url = "https://i.ibb.co/XVfH14N/7.png",
                        Product = products[5]
                    }
                };
                context.ProductImages.AddRange(productsImages);

                // Variações de tamanhos para os três primeiros produtos
                List<ProductSize> productSizesVariations = new()
                {
                    // Product 1
                    new ProductSize { Product = products[0], Size = SizeEnum.P, Quantity = 10 },
                    new ProductSize { Product = products[0], Size = SizeEnum.M, Quantity = 15 },
                    new ProductSize { Product = products[0], Size = SizeEnum.G, Quantity = 20 },
                    new ProductSize { Product = products[0], Size = SizeEnum.PP, Quantity = 5 },

                    // Product 2
                    new ProductSize { Product = products[1], Size = SizeEnum.P, Quantity = 8 },
                    new ProductSize { Product = products[1], Size = SizeEnum.M, Quantity = 12 },
                    new ProductSize { Product = products[1], Size = SizeEnum.G, Quantity = 18 },
                    new ProductSize { Product = products[1], Size = SizeEnum.PP, Quantity = 4 },

                    // Product 3
                    new ProductSize { Product = products[2], Size = SizeEnum.P, Quantity = 25 },
                    new ProductSize { Product = products[2], Size = SizeEnum.M, Quantity = 30 },
                    new ProductSize { Product = products[2], Size = SizeEnum.G, Quantity = 35 },
                    new ProductSize { Product = products[2], Size = SizeEnum.PP, Quantity = 10 },
                };
                context.ProductSizes.AddRange(productSizesVariations);

                // Relacionamento Subcategoria e produto
                context.ProductSubcategories.Add(new ProductSubcategory(products[0], subcategories[0]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[0], subcategories[7]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[1], subcategories[3]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[1], subcategories[5]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[2], subcategories[6]));

                context.SaveChanges();

                Log.Information("End of database population");
            }
        }
    }
}
