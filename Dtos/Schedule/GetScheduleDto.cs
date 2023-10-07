using MongoDB.Driver;
using TicketEase.Dtos.Trains;
using TicketEase.Entities;

namespace TicketEase.Dtos.Schedule
{
    public class GetScheduleDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string DepartureTime { get; set; } = string.Empty;
        public string ArrivalTime { get; set; } = string.Empty;
        public CreateTrainDto Train { get; set; } = new();
        public List<TicketEase.Entities.Station> stations { get; set; } = new();
    }
}
