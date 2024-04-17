using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Skateverse.Data;
using Skateverse.Data.Models;
using Skateverse.Models;

namespace Skateverse.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SkateverseDbContext context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        //Adding the userManager and the SignInManager
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, SkateverseDbContext _context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = _context;
        }

        //Register get method
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if(User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var userList = context.Users.ToList();
            var result = await userManager.CreateAsync(user, model.Password);
            if (userList.Count <= 0)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await userManager.AddToRoleAsync(user, "User");
            }

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach(var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if(User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LogInViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(model.UserName);

            if(User != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ProfilePage()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task CreateRoles()
        {
            var roleList = context.Roles.ToList();

            if (roleList.Count <= 0)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
