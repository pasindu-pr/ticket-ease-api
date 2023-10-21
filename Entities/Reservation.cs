namespace TicketEase.Entities
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string ScheduleId { get; set; } = null!;
        public double Price { get; set; } = 0;
        public string ToStationId { get; set; } = null!;
        public string FromStationId { get; set; } = null!;
        public int PassengerCount { get; set; }
    }
}
