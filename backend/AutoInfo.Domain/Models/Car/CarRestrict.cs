using System;

namespace AutoInfo.Domain.Models.Car
{
    public class CarRestrict : VehicleRestrict
    {
        public Guid Id { get; set; }

        public Car Car { get; set; }
    }
}