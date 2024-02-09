using Microsoft.AspNetCore.Mvc;

namespace Skateverse.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
