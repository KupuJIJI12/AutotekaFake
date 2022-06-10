using System;

namespace AutoInfo.Domain.Models
{
    public class Fine
    {
        public Guid Id { get; set; }
        public double Cost { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}