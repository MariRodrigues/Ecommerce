using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Products;
using Ecommerce.Domain.Entities.Subcategories;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Builder;
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
                if (!context.Database.CanConnect())
                {
                    // Aplica as migrações se o banco não existir
                    context.Database.Migrate();
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
                        Name = "Camiseta Harry Potter",
                        Description = "Camiseta estilizada com o emblema da casa de Hogwarts. Perfeita para os fãs do bruxinho mais famoso do mundo!",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 70.0,
                        Size = 2,
                        Width = 50.0,
                        Weight = 0.3,
                        Value = 39.99
                    },
                    new Product
                    {
                        Name = "Chaveiro KillJoy",
                        Description = "Chaveiro inspirado no agente KillJoy do Valorant. Um toque de estilo e tecnologia para suas chaves!",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 10.0,
                        Size = 1,
                        Width = 5.0,
                        Weight = 0.05,
                        Value = 9.99
                    },
                    new Product
                    {
                        Name = "Caneca Valorant Sova",
                        Description = "Caneca personalizada com a arte do agente Sova do Valorant. Ideal para tomar sua bebida favorita enquanto joga!",
                        Status = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = null,
                        Height = 12.0,
                        Size = 3,
                        Width = 8.0,
                        Weight = 0.4,
                        Value = 24.99
                    }
                };
                context.Products.AddRange(products);

                // Imagens para produtos
                List<ProductImages> productsImages = new()
                {
                    new ProductImages
                    {
                        Url = "https://images.fatum.com.br/site/produtos/39_20969_03.jpg?losslevel=1&v=10.4",
                        Product = products[0]
                    },
                    new ProductImages
                    {
                        Url = "https://images.fatum.com.br/site/produtos/39_20969_04.jpg?losslevel=1&v=10.4",
                        Product = products[0]
                    },
                    new ProductImages
                    {
                        Url = "https://down-br.img.susercontent.com/file/br-11134207-7qukw-lhpayk4rt3ef83",
                        Product = products[1]
                    }
                };
                context.ProductImages.AddRange(productsImages);

                // Relacionamento Subcategoria e produto
                context.ProductSubcategories.Add(new ProductSubcategory(products[0], subcategories[0]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[0], subcategories[7]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[1], subcategories[3]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[1], subcategories[5]));
                context.ProductSubcategories.Add(new ProductSubcategory(products[2], subcategories[6]));

                // Usuário comum


                // Usuários admin

                context.SaveChanges();
            }
        }
    }
}
