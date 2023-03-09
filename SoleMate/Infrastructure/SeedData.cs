using Microsoft.EntityFrameworkCore;
using SoleMate.Models;

namespace SoleMate.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category nike = new Category { Name = "Nike", Slug = "nike" };
                Category adidas = new Category { Name = "Adidas", Slug = "adidas" };
                Category converse = new Category { Name = "Converse", Slug = "converse" };
                Category vans = new Category { Name = "Vans", Slug = "vans" };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Nike",
                            Slug = "nike",
                            Description = "A stylish and comfortable shoe that combines modern design with advanced technology to provide optimal performance for any activity.",
                            Price = 59.50M,
                            Category = nike,
                            Image = "nike.png"
                        },
                        new Product
                        {
                            Name = "Adidas",
                            Slug = "adidas",
                            Description = " A sleek and versatile shoe that combines timeless design with cutting-edge features to provide superior comfort and performance for all-day wear.",
                            Price = 69.99M,
                            Category = adidas,
                            Image = "adidas.png"
                        },

                        new Product
                        {
                            Name = "Converse",
                            Slug = "converse",
                            Description = "A classic and iconic shoe that effortlessly blends timeless style with everyday comfort for a versatile and effortless look.",
                            Price = 59.99M,
                            Category = converse,
                            Image = "converse.png"
                        },

                         new Product
                         {
                             Name = "Vans",
                             Slug = "vans",
                             Description = "A cool and casual shoe that embodies the spirit of skate culture with its laid-back design and durable construction, perfect for both the skate park and everyday wear.",
                             Price = 59.99M,
                             Category = vans,
                             Image = "vans.png"
                         },
                         new Product
                         {
                             Name = "Nike",
                             Slug = "nike",
                             Description = "A stylish and comfortable shoe that combines modern design with advanced technology to provide optimal performance for any activity.",
                             Price = 59.50M,
                             Category = nike,
                             Image = "nike.png"
                         },
                        new Product
                        {
                            Name = "Adidas",
                            Slug = "adidas",
                            Description = " A sleek and versatile shoe that combines timeless design with cutting-edge features to provide superior comfort and performance for all-day wear.",
                            Price = 69.99M,
                            Category = adidas,
                            Image = "adidas.png"
                        },

                        new Product
                        {
                            Name = "Converse",
                            Slug = "converse",
                            Description = "A classic and iconic shoe that effortlessly blends timeless style with everyday comfort for a versatile and effortless look.",
                            Price = 59.99M,
                            Category = converse,
                            Image = "converse.png"
                        },

                         new Product
                         {
                             Name = "Vans",
                             Slug = "vans",
                             Description = "A cool and casual shoe that embodies the spirit of skate culture with its laid-back design and durable construction, perfect for both the skate park and everyday wear.",
                             Price = 59.99M,
                             Category = vans,
                             Image = "vans.png"
                         }
                );

                context.SaveChanges();
            }
        }
    }
}