using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models
{
    public abstract class Vehicle
    {
        [Required]
        [Key]
        public Guid VIN { get; set; }
        
        [Required] 
        public abstract VehicleCharacteristic Characteristic { get; }
        
        public byte[]? Pictures { get; set; }
    }
}