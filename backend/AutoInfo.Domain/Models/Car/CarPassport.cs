using System;
using System.Collections.Generic;

namespace AutoInfo.Domain.Models.Car
{
    public class CarPassport : VehiclePassport<Car, CarOwner>
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }
        
        public override Car Vehicle { get; set; }
        
        public override IEnumerable<CarOwner> Owners { get; set; }
    }
}