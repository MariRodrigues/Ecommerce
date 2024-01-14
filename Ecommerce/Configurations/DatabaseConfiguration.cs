using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
                // Verifica se o banco de dados existe
                if (context.Database.GetPendingMigrations().Any())
                {
                    try
                    {
                        Console.WriteLine("Trying to create and migrate database");
                        context.Database.Migrate();
                    } 
                    catch(SqlException exception) when (exception.Number == 1801)
                    {
                        Console.WriteLine("Database already exists.");
                    }
                }

                // Verifica se a tabela categoria possui algum dado cadastrado
                if (context.Categories.Any())
                {
                    return;
                }

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
                        Height = 70.0,
                        Size = 2,
                        Width = 50.0,
                        Weight = 0.3,
                        Value = 49.99
                    },
                    new Product
                    {
                        Name = "Urso Polar Esportista Coca-Cola - Karatê",
                        Description = "Urso POLAR Esportista da Coca-Cola - Oficial",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 10.0,
                        Size = 1,
                        Width = 5.0,
                        Weight = 0.05,
                        Value = 49.99
                    },
                    new Product
                    {
                        Name = "Caderno Avatar 2 - 10 matérias",
                        Description = "Caderno Avatar 2 - 10 matérias",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 12.0,
                        Size = 3,
                        Width = 8.0,
                        Weight = 0.4,
                        Value = 24.99
                    },
                    new Product
                    {
                        Name = "DVD Blue-ray - A fuga das Galinhas",
                        Description = "DVD Blue-ray - A fuga das Galinhas",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 12.0,
                        Size = 3,
                        Width = 8.0,
                        Weight = 0.4,
                        Value = 14.99
                    },
                    new Product
                    {
                        Name = "Chaveiro Genshing Impact - Qiqi",
                        Description = "Chaveiro Genshing Impact - Qiqi",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 12.0,
                        Size = 3,
                        Width = 8.0,
                        Weight = 0.4,
                        Value = 14.99
                    },
                    new Product
                    {
                        Name = "Caneca Valorant - Sova",
                        Description = "Caneca Valorant - Sova",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 12.0,
                        Size = 3,
                        Width = 8.0,
                        Weight = 0.4,
                        Value = 14.99
                    },
                    new Product
                    {
                        Name = "Caneca Dev - Visual Studio",
                        Description = "Caneca Dev - Visual Studio Cheat sheet",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 12.0,
                        Size = 3,
                        Width = 8.0,
                        Weight = 0.4,
                        Value = 14.99
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

                // Relacionamento Subcategoria e produto
                context.ProductSubcategories.Add(new ProductSubcategory(products[0], subcategories[0]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[0], subcategories[7]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[1], subcategories[3]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[1], subcategories[5]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[2], subcategories[6]));

                context.SaveChanges();
            }
        }
    }
}
