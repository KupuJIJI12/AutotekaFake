using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models.Car
{
    public class Car : Vehicle<CarEngine, CarPassport, CarLicense>
    {
        [Key]
        public Guid VIN { get; set; }
        
        public string CarNumber { get; set; }

        public override CarEngine Engine { get; set; }
        
        public override CarPassport Passport { get; set; }
        
        public override CarLicense License { get; set; }

        public IEnumerable<CarInspect> CarInspects { get; set; }
    }
}