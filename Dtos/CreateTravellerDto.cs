using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos
{
    public class CreateTravellerDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid Email")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"([0-9]{9}[x|X|v|V]|[0-9]{12})$", ErrorMessage = "Invalid NIC Number")]
        public string NicNumber { get; set; } = string.Empty;
    }
}
