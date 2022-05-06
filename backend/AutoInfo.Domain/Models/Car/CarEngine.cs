using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models.Car
{
    public class CarEngine : Engine
    {
        [Key]
        [Column("Id")]
        public override Guid EngineNumber { get; set; }
    }
}