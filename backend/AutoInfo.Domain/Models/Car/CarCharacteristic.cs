using System;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models.Car
{
    public class CarCharacteristic : VehicleCharacteristic
    {
        [Required]
        public Guid ChassisNumber { get; set; }
    }
}