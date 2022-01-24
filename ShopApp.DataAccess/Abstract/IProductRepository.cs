using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string productName);
        List<Product> GetSearchResult(string searchText);
        List<Product> GetTop5Products();
        List<Product> GetProductsByCategory(string categoryName, int page, int pageSize);
        List<Product> GetHomePageProducts();
        int GetCountByCategory(string categoryName);
    }
}
