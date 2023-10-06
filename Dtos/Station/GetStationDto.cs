namespace TicketEase.Dtos.Station
{
    public class GetStationDto
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string PreviousStation { get; set; } = string.Empty;
        public string NextStation { get; set; } = string.Empty;
        public double DistanceToNextStation { get; set; }
        public double DistanceToPreviousStation { get; set; }
    }
}
