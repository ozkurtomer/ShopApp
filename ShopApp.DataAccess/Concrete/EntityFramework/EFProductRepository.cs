using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EFProductRepository : EFGenericRepository<Product, ShopContext>, IProductRepository
    {
        public int GetCountByCategory(string categoryName)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(x => x.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(categoryName))
                {
                    products = products.Include(x => x.ProductCategory)
                                       .ThenInclude(x => x.Category)
                                       .Where(x => x.ProductCategory.Any(x => x.Category.Url.ToLower() == categoryName.ToLower()));
                }

                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(x => x.IsApproved && x.IsHome).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchText)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(x => x.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(searchText))
                {
                    products = products.Include(x => x.ProductCategory)
                                       .ThenInclude(x => x.Category)
                                       .Where(x => x.Name.ToLower().Contains(searchText.ToLower()) || x.Description.ToLower().Contains(searchText.ToLower()));
                }

                return products.ToList();
            }
        }

        public Product GetProductDetails(string productName)
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(x => x.Url == productName)
                                       .Include(x => x.ProductCategory)
                                       .ThenInclude(x => x.Category)
                                       .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string categoryName, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(x => x.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(categoryName))
                {
                    products = products.Include(x => x.ProductCategory)
                                       .ThenInclude(x => x.Category)
                                       .Where(x => x.ProductCategory.Any(x => x.Category.Url.ToLower() == categoryName.ToLower()));
                }

                return products?.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }
    }
}
