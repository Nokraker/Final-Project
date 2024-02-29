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

        public ProductService(SkateverseDbContext _context)
        {
            this.context = _context;
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
    }
}
