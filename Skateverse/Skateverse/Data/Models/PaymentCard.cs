using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateverse.Data.Models
{
    public class PaymentCard
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }

        public List<Payment> Orders { get; set; }


    }
}
