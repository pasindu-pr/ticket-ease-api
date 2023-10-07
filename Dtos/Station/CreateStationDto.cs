using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Station
{
    public class CreateStationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Province { get; set; } = string.Empty;
        //public string PreviousStationId { get; set; } = string.Empty;
        //public string NextStationId { get; set; } = string.Empty;
        //public double DistanceToNextStation { get; set; }
        //public double DistanceToPreviousStation { get; set; }
    }
}
