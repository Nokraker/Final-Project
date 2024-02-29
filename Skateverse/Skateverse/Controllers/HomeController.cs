using Microsoft.AspNetCore.Mvc;
using Skateverse.Contracts;
using Skateverse.Models;
using Skateverse.Services;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Skateverse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService _service)
        {
            _logger = logger;
            productService = _service;
        }

        public async Task< IActionResult> Index()
        {
            List<ProductViewModel> products = await productService.GetAllAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}