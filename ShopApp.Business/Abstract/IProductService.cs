using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        Product GetProductDetails(string productName);
        List<Product> GetProductsByCategory(string categoryName, int page, int pageSize);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchText);
        Product GetByIdWithCategories(int id);

        int GetCountByCategory(string categoryName);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Update(Product entity, int[] categoryIds);
    }
}
