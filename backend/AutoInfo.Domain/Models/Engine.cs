using System;
using System.ComponentModel.DataAnnotations;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models
{
    public class Engine
    {
        public virtual Guid EngineNumber { get; set; }
        
        public EngineType Type { get; set; }
        
        public string Model { get; set; }

        public short? Power { get; set; }
        
        public float? Displacement { get; set; }
    }
}