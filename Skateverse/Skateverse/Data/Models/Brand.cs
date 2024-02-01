using System.ComponentModel.DataAnnotations;

namespace Skateverse.Data.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
