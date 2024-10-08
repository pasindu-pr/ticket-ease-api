﻿namespace TicketEase.Entities
{
    public class Station : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public Station? PreviousStation { get; set; }
        public Station? NextStation { get; set; }
        public double? DistanceToNextStation { get; set; }
        public double? DistanceToPreviousStation { get; set; }
    }
}
