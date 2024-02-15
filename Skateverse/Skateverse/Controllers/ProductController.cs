using Microsoft.AspNetCore.Mvc;
using Skateverse.Contracts;
using Skateverse.Services;

namespace Skateverse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = productService.GetAllAsync();

            return View(model);
        }
    }
}
