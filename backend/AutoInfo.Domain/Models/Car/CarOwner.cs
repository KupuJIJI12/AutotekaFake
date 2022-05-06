using System;
using System.Collections.Generic;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models.Car
{
    public class CarOwner : VehicleOwner<CarPassport>
    {
        public Guid Id { get; set; }
        
        public CarOwner(string firstName, string secondName, string middleName = "")
            : base(firstName, secondName, middleName)
        { }

        public override IEnumerable<CarPassport> VehiclePassports { get; set; }
    }
}