using Skateverse.Data.Models;

namespace Skateverse.Models.Account
{
    public class PaymentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { set; get; }
        public DateTime Payment_Date { get; set; }
        public string UserId { get; set; }
        public List<Cart> Items { get; set; }
    }
}
