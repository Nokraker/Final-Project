using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateverse.Data.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Count { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Cart> ShoppingCarts { get; set; } = new List<Cart>();
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}