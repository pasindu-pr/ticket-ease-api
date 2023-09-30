using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Trains
{
    public class CreateTrainDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
