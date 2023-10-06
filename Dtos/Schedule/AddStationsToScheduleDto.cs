namespace TicketEase.Dtos.Schedule
{
    public class AddStationsToScheduleDto
    {
        public int ScheduleId { get; set; }
        public List<string> StationIds { get; set; } = new();
    }
}
