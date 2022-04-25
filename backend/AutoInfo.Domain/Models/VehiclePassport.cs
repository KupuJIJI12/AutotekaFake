using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models
{
    public class VehiclePassport : Passport
    {
        [Required]
        public DateTime YearOfManufacture { get; set; }
        
        [Required]
        public VehicleCharacteristic Characteristic { get; set; }
        
        [Required]
        public IEnumerable<VehicleOwner> Owners { get; set; }
    }
}