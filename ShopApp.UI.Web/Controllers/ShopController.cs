using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;

namespace ShopApp.UI.Web.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult List()
        {
            var productViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(productViewModel);
        }
    }
}
