using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Skateverse.Contracts;
using Skateverse.Data;
using Skateverse.Data.Models;
using Skateverse.Models;
using System.Runtime.CompilerServices;

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

        public async Task Add(AddProductModel model)
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

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task<List<CartViewModel>> ViewShoppingCart(string userId)
        {

            List<CartViewModel> carts = await context.ShoppingCarts.Include(x => x.Product).Include(x => x.Product.Category).Where(x => x.User.Id == userId && x.IsPayed == false).
                Select(p => new CartViewModel
                {
                    Id = p.Id,
                    Product = p.Product,
                    IsPayed = p.IsPayed,
                    Count = p.Count
                }).ToListAsync();

            return carts;
        }

        public async Task AddCart(string userId, Guid productId)
        {

            Cart cart = new Cart()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
                Count = 1
            };

            await context.ShoppingCarts.AddAsync(cart);
            await context.SaveChangesAsync();
        }

        public async Task<Product> FullProductPage(Guid productId)
        {
            return await context.Products.Include(x => x.Category).Where(x => x.Id == productId).FirstOrDefaultAsync();
        }

        public async Task  UpTheCountOfAProductInACart(Guid cartId)
        {
            Cart cart = await context.ShoppingCarts.FindAsync(cartId);

            cart.Count++;
            await context.SaveChangesAsync();
        }
        public async Task LowerTheCountOfAProductInACart(Guid cartId)
        {
            Cart cart = await context.ShoppingCarts.FindAsync(cartId);


            cart.Count--;
            if(cart.Count <= 0)
            {
               context.ShoppingCarts.Remove(cart);
            }

            await context.SaveChangesAsync();
        }

        public async Task AddToFavourites(Guid productId, string userId)
        {
            Favourite fav = new Favourite()
            {
                ProductId = productId,
                UserId = userId
            };

            await context.Favourites.AddAsync(fav);
            await context.SaveChangesAsync();
        }

        public async Task<List<Favourite>> ViewFavourites(string userId)
        {
            return await context.Favourites.Include(x => x.Product).Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task RemoveFromFavourites(Guid productId,string userId)
        {
            Favourite fav = await context.Favourites.Where(f => f.Product.Id == productId && f.User.Id == userId).FirstOrDefaultAsync();
            context.Favourites.Remove(fav);
            await context.SaveChangesAsync();
        }
    }
}
