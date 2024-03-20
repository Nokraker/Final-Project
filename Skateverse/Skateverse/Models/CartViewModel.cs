using Skateverse.Data.Models;

namespace Skateverse.Models
{
    public class CartViewModel
    {
        public Guid Id { set; get; }
        public Product Product { get; set; }
        public bool IsPayed { get; set; }

        public int Count { get; set; }
    }
}
