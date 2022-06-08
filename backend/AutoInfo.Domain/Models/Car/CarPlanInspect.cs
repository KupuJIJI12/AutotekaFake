using System;

namespace AutoInfo.Domain.Models.Car
{
    public class CarPlanInspect : VehicleInspect
    {
        public Guid Id { get; set; }

        public string CardNumber { get; set; }

        public Car Car { get; set; }
    }
}