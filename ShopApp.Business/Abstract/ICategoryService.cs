using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        Category GetByIdWithProducts(int id);

        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
