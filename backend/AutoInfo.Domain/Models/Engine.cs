using System;
using System.ComponentModel.DataAnnotations;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models
{
    public class Engine
    {
        [Required]
        public string EngineId { get; set; }
        
        public EngineType Type { get; set; }
        
        [Required]
        public string Model { get; set; }

        [Required]
        public short Power { get; set; }
        
        [Required]
        public short Displacement { get; set; }
    }
}