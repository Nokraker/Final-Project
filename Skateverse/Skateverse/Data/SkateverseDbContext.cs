using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skateverse.Controllers;
using Skateverse.Data.Models;

namespace Skateverse.Data
{
    public class SkateverseDbContext:IdentityDbContext<User>
    {
        private UserController controller;
        public SkateverseDbContext(DbContextOptions options, UserController _uController) : base(options) { this.controller = _uController; }

        public DbSet<Cart> ShoppingCarts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected async override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Favourite>()
                .HasKey(x => new { x.UserId, x.ProductId });

            builder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<Category>()
                .HasData(new Models.Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Jeans"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Upperwear"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Shirts"
                });
            await controller.CreateRoles();
            base.OnModelCreating(builder);
        }
    }
}
