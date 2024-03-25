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
        public async Task<IActionResult> Add(AddProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await productService.Add(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(Guid productId)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            await productService.AddCart(userId, productId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ViewShoppingCart()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            var shoppingCart = await productService.ViewShoppingCart(userId);
            return View(shoppingCart);
        }

        [HttpGet]
        public async Task<IActionResult> FullProductPage(Guid productId)
        {
            var product = await productService.FullProductPage(productId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpTheCount([FromForm] Guid cartId)
        {
            await productService.UpTheCountOfAProductInACart(cartId);
            return RedirectToAction("ViewShoppingCart");
        }
        [HttpPost]
        public async Task<IActionResult> LowerTheCount(Guid cartId)
        {
            await productService.LowerTheCountOfAProductInACart(cartId);
            return RedirectToAction("ViewShoppingCart");
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavourites(Guid productId)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            await productService.AddToFavourites(productId, userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ViewFavourites()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            List<Favourite> favourites = await productService.ViewFavourites(userId);
            return View(favourites);    
        }
    }
}
