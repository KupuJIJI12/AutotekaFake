using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models.Car
{
    public class CarCharacteristic : VehicleCharacteristic
    {
        [Required]
        public Guid ChassisNumber { get; set; }

        [ForeignKey("EngineId")]
        public CarEngine Engine { get; set; }
    }
}