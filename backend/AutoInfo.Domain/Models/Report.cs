using System;

namespace AutoInfo.Domain.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        
        public Car.Car Car { get; set; }

        public DateTime Date { get; set; }
    }
}