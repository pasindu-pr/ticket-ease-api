using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Reservation
{
    public class CreateReservationDto
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public string ScheduleId { get; set; } = null!;
        [Required]
        public string FromStationId { get; set; } = null!;
        [Required]
        public string ToStationId { get; set; } = null!;
    }
}
