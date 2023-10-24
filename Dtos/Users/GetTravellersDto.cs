namespace TicketEase.Dtos.Users
{
    public class GetTravellersDto
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? NicNumber { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
    }
}
