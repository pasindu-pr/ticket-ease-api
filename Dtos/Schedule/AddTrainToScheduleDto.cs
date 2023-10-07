using System.ComponentModel.DataAnnotations;

namespace TicketEase.Dtos.Schedule
{
    public class AddTrainToScheduleDto
    {
        [Required]
        public string TrainId { get; set; } = string.Empty;
        [Required]
        public string ScheduleId { get; set; } = string.Empty;
    }
}
