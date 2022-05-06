using System;
using System.ComponentModel.DataAnnotations;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models.Car
{
    public class CarLicense
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        
        public string RegistrationNumber { get; set; }
        
        public VehicleСategory Category { get; set; }
        
        public CarPassport CarPassport { get; set; }
    }
}