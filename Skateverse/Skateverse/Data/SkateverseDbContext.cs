using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skateverse.Data.Models;

namespace Skateverse.Data
{
    public class SkateverseDbContext:IdentityDbContext<User>
    {
        public SkateverseDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cart> ShoppingCarts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentCard> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Favourite>()
                .HasKey(x => new { x.UserId, x.ProductId });

            builder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            base.OnModelCreating(builder);

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
            base.OnModelCreating(builder);
        }
    }
}
