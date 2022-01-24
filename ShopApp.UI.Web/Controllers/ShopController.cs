using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.UI.Web.Models;
using ShopApp.UI.Web.ViewModels;
using System.Linq;

namespace ShopApp.UI.Web.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 3;
            var productViewModel = new ProductListViewModel
            {
                PageInfo = new PageInfo
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentCategory = category,
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            };

            return View(productViewModel);
        }

        public IActionResult Details(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails(productName);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel { Product = product, Categories = product.ProductCategory.Select(x => x.Category).ToList() });
        }

        public IActionResult Search(string q)
        {
            var productViewModel = new ProductListViewModel
            {
                Products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }
    }
}
