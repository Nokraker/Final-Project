using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateverse.Data.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Cart_type { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        [Required]
        public Cart Cart { get; set; }
    }
}