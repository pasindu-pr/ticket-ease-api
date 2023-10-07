namespace TicketEase.Dtos.Schedule
{
    public class AddStationsToScheduleDto
    {
        public string ScheduleId { get; set; } = string.Empty;
        public List<string> Stations { get; set; } = new();
    }
}
