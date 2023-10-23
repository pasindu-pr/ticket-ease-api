using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Reservation
{
    public class GetReservationsDto
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string ScheduleId { get; set; } = null!;
        public string FromStationId { get; set; } = null!;
        public string ToStationId { get; set; } = null!;
        public string Date { get; set; } = string.Empty;
        public int PassengerCount { get; set; } = 0;
        public double Price { get; set; }
    }
}
