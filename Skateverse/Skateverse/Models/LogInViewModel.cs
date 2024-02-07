using System.ComponentModel.DataAnnotations;

namespace Skateverse.Models
{
    public class LogInViewModel
    {
        [Required]
        public string UserName { get; set; } = null;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null;
    }
}
