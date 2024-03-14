using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skateverse.Contracts;
using Skateverse.Data;
using Skateverse.Data.Models;
using Skateverse.Models;

namespace Skateverse.Services
{
    public class ProductService : IProductService
    {
        private readonly SkateverseDbContext context;
        private readonly UserManager<User> userManager;

        public ProductService(SkateverseDbContext _context, UserManager<User> manager)
        {
            this.context = _context;
            this.userManager = manager;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var entities = await context.Products.Include(nameof(Category)).ToListAsync();
            return entities
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImgUrl = p.ImgUrl,
                    Count = p.Count,
                    Price = p.Price,
                    CategoryName = p?.Category.Name,
                }).ToList();
        }

        public bool Add(AddProductModel model)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ImgUrl = model.ImgUrl,
                Count = model.Count,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            context.Products.Add(product);
            context.SaveChanges();

            if (context.Products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public List<CartViewModel> ViewShoppingCart(string userId)
        {

            List<CartViewModel> carts = context.ShoppingCarts.Include(x => x.Product).Include(x => x.Product.Category).Where(x => x.User.Id == userId && x.IsPayed == false).
                Select(p => new CartViewModel
                {
                    Product = p.Product,
                    IsPayed = p.IsPayed
                }).ToList();

            return carts;
        }

        public void AddCart(string userId, Guid productId)
        {

            Cart cart = new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
            };

            context.ShoppingCarts.Add(cart);
            context.SaveChanges();
        }
    }
}
