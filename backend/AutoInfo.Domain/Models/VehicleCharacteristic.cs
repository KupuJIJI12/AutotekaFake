using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models
{
    public class VehicleCharacteristic
    {
        public string Brand { get; set; }
        
        public string Model { get; set; }
        
        public Guid EngineId { get; set; }
        
        [ForeignKey("EngineId")]
        public Engine? Engine { get; set; }
        
        public string? Color { get; set; }
        public float? Weight { get; set; }
    }
}