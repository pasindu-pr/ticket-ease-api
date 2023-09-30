﻿namespace TicketEase.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserTypes UserType { get; set; }
        public string? NicNumber { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
    }
}
