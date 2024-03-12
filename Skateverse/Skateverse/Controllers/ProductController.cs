using Microsoft.AspNetCore.Mvc;
using Skateverse.Contracts;
using Skateverse.Data;
using Skateverse.Data.Models;
using Skateverse.Models;
using Skateverse.Services;
using System.Security.Claims;

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
        public IActionResult Add(AddProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var pr = productService.Add(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddCart(Guid productId)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            productService.AddCart(userId, productId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ViewShoppingCart()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            var shoppingCart = productService.ViewShoppingCart(userId);
            return View(shoppingCart);
        }
    }
}
