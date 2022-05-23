using System;

namespace AutoInfo.Domain.Models
{
    public class VehicleInspect
    {
        public double Mileage { get; set; }

        public DateTime Date { get; set; }

        public string Region { get; set; }

        public string Organization { get; set; }

        public string Description { get; set; }
        
        public double? Cost { get; set; }
    }
}