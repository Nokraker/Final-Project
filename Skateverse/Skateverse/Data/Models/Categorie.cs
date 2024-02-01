using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace Skateverse.Data.Models
{
    public class Categorie
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null;

        public List<Product> Product { get; set; } = new List<Product>();        
    }
}
