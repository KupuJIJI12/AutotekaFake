using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models
{
    public abstract class VehiclePassport : Passport
    {

        [Required]
        public DateTime YearOfManufacture { get; set; }
        
        [Required]
        public abstract VehicleCharacteristic Characteristic { get; }
        
        [Required]
        public IEnumerable<VehicleOwner> Owners { get; set; }
    }
}