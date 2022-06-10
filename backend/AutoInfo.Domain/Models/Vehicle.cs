using System.Collections.Generic;

namespace AutoInfo.Domain.Models
{
    public abstract class Vehicle<TEngine, TPassport, TLicense>
    {
        public string Brand { get; set; }
        
        public string Model { get; set; }

        public abstract TEngine Engine { get; set; }

        public abstract TPassport Passport { get; set; }
        
        public abstract TLicense License { get; set; }

        public string Color { get; set; }

        public virtual IEnumerable<Photo> Photos { get; set; }
        
        public float? Weight { get; set; }
    }
}