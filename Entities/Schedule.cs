﻿namespace TicketEase.Entities
{
    public class Schedule : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string DepartureTime { get; set; } = string.Empty;
        public string ArrivalTime { get; set; } = string.Empty;
        public List<Station> Stations { get; set; } = new();
        public Train? Train { get; set; }
    }
}
