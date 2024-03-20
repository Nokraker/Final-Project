using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateverse.Data.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public int Count { get; set; } = 0;

        [Required]
        public bool IsPayed { get; set; } = false;

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public List<Payment> Payments { get; set; }
    }
}