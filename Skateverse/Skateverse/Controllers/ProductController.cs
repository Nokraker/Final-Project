using Microsoft.AspNetCore.Mvc;
using Skateverse.Contracts;
using Skateverse.Data;
using Skateverse.Models;
using Skateverse.Services;

namespace Skateverse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly SkateverseDbContext context;

        public ProductController(IProductService _productService, SkateverseDbContext _context)
        {
            productService = _productService;
            context = _context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var pr = productService.Add(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
