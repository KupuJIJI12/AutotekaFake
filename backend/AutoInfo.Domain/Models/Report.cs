using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models
{
    public class Report
    {
        [Required]
        public Guid Id { get; set; }
        
        public Guid VIN { get; set; }
        
        [Required]
        [ForeignKey("VIN")]
        public Car.Car Car { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}