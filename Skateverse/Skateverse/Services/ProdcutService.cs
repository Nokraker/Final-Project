using Microsoft.EntityFrameworkCore;
using Skateverse.Contracts;
using Skateverse.Data;
using Skateverse.Models;

namespace Skateverse.Services
{
    public class ProdcutService : IProdcutService
    {
        private readonly SkateverseDbContext context;

        public ProdcutService(SkateverseDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var entities = await context.Products.ToListAsync();
            return entities
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImgUrl = p.ImgUrl,
                    Count = p.Count,
                    CategoryName = p?.Categorie.Name,
                    BrandName = p?.Brand.Name,
                });
        }
    }
}
