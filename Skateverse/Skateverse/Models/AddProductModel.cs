using System.ComponentModel.DataAnnotations;

namespace Skateverse.Models
{
    public class AddProductModel
    {
        public string Name { get; set; } = null;
        public string ImgUrl { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Guid CategorieId { get; set; }
        public Guid BrandId { get; set; }
    }
}
