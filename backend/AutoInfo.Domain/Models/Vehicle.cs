using System;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models
{
    public class Vehicle
    {
        [Key]
        public Guid VIN { get; set; }
        
        public VehicleCharacteristic Characteristic { get; set; }
        
        public byte[]? Pictures { get; set; }
    }
}