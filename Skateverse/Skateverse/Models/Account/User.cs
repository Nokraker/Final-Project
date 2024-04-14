using Microsoft.AspNetCore.Identity;

namespace Skateverse.Data.Models
{
    public class User:IdentityUser
    {
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
        public List<Cart> ShoppingCars { get; set; } = new List<Cart>();
        public List<Payment> Payments { get; set; } = new List<Payment>();

    }
}
