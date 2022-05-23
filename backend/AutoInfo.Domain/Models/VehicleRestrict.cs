using System;

namespace AutoInfo.Domain.Models
{
    public class VehicleRestrict
    {
        public DateTime Date { get; set; }
        
        public string Type { get; set; }

        public string Organization { get; set; }

        public string Region { get; set; }
    }
}