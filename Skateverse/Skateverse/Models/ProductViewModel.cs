using Skateverse.Data.Models;

namespace Skateverse.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null;
        public string ImgUrl { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }
    }
}
