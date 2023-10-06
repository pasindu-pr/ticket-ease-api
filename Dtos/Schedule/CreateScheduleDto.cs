using TicketEase.Entities;

namespace TicketEase.Dtos.Schedule
{
    public class CreateScheduleDto
    {
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string DepartureTime { get; set; } = string.Empty;
        public string ArrivalTime { get; set; } = string.Empty;
    }
}
