using System;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models
{
    public class VehicleCharacteristic
    {
        [Required]
        [Key]
        public Guid VIN { get; set; }
        
        [Required]
        public string Brand { get; set; }
        
        [Required]
        public string Model { get; set; }
        
        public string? Color { get; set; }
        public float? Weight { get; set; }
    }
}