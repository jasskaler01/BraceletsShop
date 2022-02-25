using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BraceletsShop.Data;
using System;
using System.Linq;

namespace BraceletsShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BraceletsShopContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BraceletsShopContext>>()))
            {
                // Look for any Bracelets.
                if (context.Bracelet.Any())
                {
                    return;   // DB has been seeded
                }

                context.Bracelet.AddRange(
                   
                    new Bracelet
                    {
                        Category = "Men ",
                        Material = "Diamond",
                        CollectionDate = DateTime.Parse("2019-2-13"),       
                        Price = 10.2M,
                        Rating = 5
                    }, new Bracelet
                    {
                        Category = "Women",
                        Material = "Gold",
                        CollectionDate = DateTime.Parse("2012-3-13"),
                        Price = 8.5M,
                        Rating = 4
                    }, new Bracelet
                    {
                        Category = "Women",
                        Material = "Silver",
                        CollectionDate = DateTime.Parse("1984-3-13"),
                        Price = 5.1M,
                        Rating = 2
                    }, new Bracelet
                    {
                        Category = " Men",
                        Material = "Stone",
                        CollectionDate = DateTime.Parse("2011-5-18"),
                        Price = 5.0M,
                        Rating = 2
                    }, new Bracelet
                    {
                        Category = "Men ",
                        Material = "Platinum",
                        CollectionDate = DateTime.Parse("2014-8-13"),
                        Price = 9M,
                        Rating = 5
                    }, new Bracelet
                    {
                        Category = "Women",
                        Material = "Bronze",
                        CollectionDate = DateTime.Parse("2009-3-21"),
                        Price = 3M,
                        Rating = 1
                    }, new Bracelet
                    {
                        Category = "Women",
                        Material = "Iron",
                        CollectionDate = DateTime.Parse("2004-3-1"),
                        Price = 1M,
                        Rating = 1
                    }, new Bracelet
                    {
                        Category = "Men",
                        Material = "Gold and Diamond",
                        CollectionDate = DateTime.Parse("2000-1-18"),
                        Price = 8.99M,
                        Rating = 4
                    }, new Bracelet
                    {
                        Category = "Women",
                        Material = "Graphite",
                        CollectionDate = DateTime.Parse("2003-3-13"),
                        Price = 4M,
                        Rating = 2
                    }, new Bracelet
                    {
                        Category = "Men",
                        Material = "Silver",
                        CollectionDate = DateTime.Parse("2001-1-13"),
                        Price = 19M,
                        Rating = 2
                    }

                );
                context.SaveChanges();
            }
        }
    }
}