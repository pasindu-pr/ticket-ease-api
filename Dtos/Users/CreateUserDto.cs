using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Users
{
    public class CreateUserDto
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
        public BackOfficeUserAndTravelAgentTypes UserType { get; set; }
    }
}
