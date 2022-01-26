using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryRepository : EFGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int productId, int categoryId)
        {
            using(var context = new ShopContext())
            {
                var cmd = "delete from ProductCategory where ProductId = @p0 and CategoryId = @p1";
                context.Database.ExecuteSqlRaw(cmd,productId,categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using(var context = new ShopContext())
            {
                return context.Categories
                              .Where(x => x.CategoryId == id)
                              .Include(x => x.ProductCategory)
                              .ThenInclude(x => x.Product)
                              .FirstOrDefault();
            }
        }
    }
}
