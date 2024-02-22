using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateverse.Data.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Payment_Date { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        [ForeignKey(nameof(PaymentCard))]
        public Guid PCardId { get; set; }
        public PaymentCard PCard { get; set; }

        List<Cart> cartItems { get; set; }
    }
}