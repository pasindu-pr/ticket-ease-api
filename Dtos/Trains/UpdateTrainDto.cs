using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Trains
{
    public class UpdateTrainDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
