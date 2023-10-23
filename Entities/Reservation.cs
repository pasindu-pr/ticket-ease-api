namespace TicketEase.Entities
{
    public class Reservation : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public Schedule ScheduleId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Price { get; set; } = 0;
        public Station ToStationId { get; set; } = null!;
        public Station FromStationId { get; set; } = null!;
        public int PassengerCount { get; set; }
        public bool IsCancelled { get; set; } = false;
    }
}
