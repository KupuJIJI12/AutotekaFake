using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models.Car
{
    public class CarLicense
    {
        [Required]
        [Key]
        public Guid LicenseId { get; set; }
        
        [Required]
        public Guid VIN { get; set; }
        
        [Required]
        public string RegistrationNumber { get; set; }
        
        [Required]
        [ForeignKey("VIN")]
        public CarCharacteristic Characteristic { get; set; }
        
        [Required] 
        public VehicleСategory Category { get; set; }
        
        [Required]
        public Passport Passport { get; set; }
    }
}