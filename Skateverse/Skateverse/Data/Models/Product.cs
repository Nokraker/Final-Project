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
        public string Name { get; set; } = null;

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Count { get; set; }

        [ForeignKey(nameof(Categorie))]
        public Guid CategorieId { get; set; }
        public Category Categorie { get; set; } = new Category();

        [ForeignKey(nameof(Brand))]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Cart> ShoppingCarts { get; set; } = new List<Cart>();
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}