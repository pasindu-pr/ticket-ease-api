namespace TicketEase.Entities
{
    public class Train : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Schedule> schedules { get; set; } = new List<Schedule>();
    }
}
