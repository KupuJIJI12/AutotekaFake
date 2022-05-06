using System;

namespace AutoInfo.Domain.Models
{
    public class Passport
    {
        public int SeriesAndNumberPassport { get; set; }
        
        public string IssuingAuthority { get; set; }
        
        public DateTime IssuingDate { get; set; }
    }
}