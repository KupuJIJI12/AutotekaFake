using System;
using System.Collections.Generic;

namespace AutoInfo.Domain.Models.Car
{
    public class CarCrash : VehicleCrash<CarDamage>
    {
        public Guid Id { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}