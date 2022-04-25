using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models.Car
{
    public class Car : Vehicle
    {
        public string CarNumber { get; set; }

        public Guid PassportId { get; set; }
        public Guid LicenseId { get; set; }
        
        [ForeignKey("PassportId")]
        public VehiclePassport CarPassport { get; set; }
        
        [ForeignKey("LicenseId")]
        public CarLicense CarLicense { get; set; }

    }
}