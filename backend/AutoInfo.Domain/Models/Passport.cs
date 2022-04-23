using System;
using System.ComponentModel.DataAnnotations;

namespace AutoInfo.Domain.Models
{
    public class Passport
    {
        [Required]
        public int SeriesAndNumberPassport { get; set; }
        
        [Required]
        public string IssuingAuthority { get; set; }
        
        [Required]
        public DateTime IssuingDate { get; set; }
    }
}