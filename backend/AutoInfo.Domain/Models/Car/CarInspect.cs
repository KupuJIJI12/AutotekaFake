﻿using System;

namespace AutoInfo.Domain.Models.Car
{
    public class CarInspect : VehicleInspect
    {
        public Guid Id { get; set; }

        public Car Car { get; set; }
    }
}