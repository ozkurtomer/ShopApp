using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.UI.Web.Models;
using ShopApp.UI.Web.ViewModels;

namespace ShopApp.UI.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel productModel)
        {
            _productService.Add(new Product
            {
                Description = productModel.Description,
                ImageUrl = productModel.ImageUrl,
                IsApproved = productModel.IsApproved,
                IsHome = productModel.IsHome,
                Name = productModel.Name,
                Price = productModel.Price,
                ProductId = productModel.ProductId,
                Url = productModel.Url,
            });

            TempData["message"] = JsonConvert.SerializeObject(new AlertMessage
            {
                Messages = $"{productModel.Name} isimli ürün eklendi",
                AlertType = "success"
            });

            return RedirectToAction("ProductList", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var entity = _productService.GetById((int)productId);

            if (entity == null)
            {
                return NotFound();
            }

            return View(new ProductModel
            {
                ProductId = entity.ProductId,
                Description = entity.Description,
                IsApproved = entity.IsApproved,
                ImageUrl = entity.ImageUrl,
                IsHome = entity.IsHome,
                Name = entity.Name,
                Price = entity.Price,
                Url = entity.Url,
            });
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductModel productModel)
        {
            var entity = _productService.GetById(productModel.ProductId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Description = productModel.Description;
            entity.ImageUrl = productModel.ImageUrl;
            entity.Name = productModel.Name;
            entity.Price = productModel.Price;
            entity.Url = productModel.Url;

            _productService.Update(entity);

            TempData["message"] = JsonConvert.SerializeObject(new AlertMessage
            {
                Messages = $"{entity.Name} isimli ürün güncellendi",
                AlertType = "success"
            });

            return RedirectToAction("ProductList", "Admin");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity == null)
            {
                return NotFound();
            }

            _productService.Delete(entity);

            TempData["message"] = JsonConvert.SerializeObject(new AlertMessage
            {
                Messages = $"{entity.Name} isimli ürün silindi",
                AlertType = "danger"
            });

            return RedirectToAction("ProductList", "Admin");
        }
    }
}
