using System;
using System.ComponentModel.DataAnnotations;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models.Car
{
    public class CarLicense
    {
        [Required]
        public Guid LicenseId { get; set; }
        
        [Required]
        public string VIN { get; set; }
        
        [Required]
        public string RegistrationNumber { get; set; }
        
        [Required]
        public CarCharacteristic Characteristic { get; set; }
        
        [Required] 
        public VehicleСategory Category { get; set; }
        
        [Required]
        public Passport Passport { get; set; }
    }
}