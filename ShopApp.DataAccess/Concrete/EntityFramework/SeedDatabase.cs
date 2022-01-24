using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategories);
                }
                context.SaveChanges();
            }
        }

        private static Category[] Categories =
        {
            new Category{Name ="Telefon",Url="telefon"},
            new Category{Name ="Bilgisayar",Url="bilgisayar"},
            new Category{Name ="Elektronik", Url = "elektronik"},
            new Category{Name ="Beyaz Eşya", Url = "beyaz-esya"},
        };

        private static Product[] Products =
        {
            new Product{Name ="Samsung S5", Url="telefon-samsung-s5", Price = 2000, ImageUrl = "1.jpg",Description="İyi telefon",IsApproved= true},
            new Product{Name ="Samsung S6", Url="telefon-samsung-s6", Price = 3000, ImageUrl = "2.jpg",Description="İyi telefon",IsApproved= false},
            new Product{Name ="Samsung S7", Url="telefon-samsung-s7", Price = 4000, ImageUrl = "3.jpg",Description="İyi telefon",IsApproved= true},
            new Product{Name ="Samsung S8", Url="telefon-samsung-s8", Price = 5000, ImageUrl = "4.jpg",Description="İyi telefon",IsApproved= false},
            new Product{Name ="Samsung S9", Url="telefon-samsung-s9", Price = 6000, ImageUrl = "5.jpg",Description="İyi telefon",IsApproved= true},
            new Product{Name ="Samsung Çamaşır Makinesi", Url="telefon-samsung-camasir", Price = 3000, ImageUrl = "6.jpg",Description="İyi makine",IsApproved= true}
        };

        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory
            {
                Product = Products[0],
                Category = Categories[0]
            },
            new ProductCategory
            {
                Product = Products[0],
                Category = Categories[2]
            },
            new ProductCategory
            {
                Product = Products[1],
                Category = Categories[0]
            },
            new ProductCategory
            {
                Product = Products[1],
                Category = Categories[2]
            },
            new ProductCategory
            {
                Product = Products[2],
                Category = Categories[0]
            },
            new ProductCategory
            {
                Product = Products[2],
                Category = Categories[2]
            },
            new ProductCategory
            {
                Product = Products[3],
                Category = Categories[0]
            },
            new ProductCategory
            {
                Product = Products[3],
                Category = Categories[2]
            },
            new ProductCategory
            {
                Product = Products[5],
                Category = Categories[3]
            },
        };
    }
}
