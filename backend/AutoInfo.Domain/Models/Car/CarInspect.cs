using System;

namespace AutoInfo.Domain.Models.Car
{
    public class CarInspect
    {
        public Guid Id { get; set; }
        
        public double Mileage { get; set; }
        
        public string CardNumber { get; set; }
    }
}