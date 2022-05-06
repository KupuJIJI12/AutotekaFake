using System;
using System.Collections.Generic;

namespace AutoInfo.Domain.Models
{
    public abstract class VehiclePassport<TVehicle, TOwner> : Passport
    {
        public DateTime YearOfManufacture { get; set; }
        
        public abstract TVehicle Vehicle { get; set; }
        
        public abstract IEnumerable<TOwner> Owners { get; set; }
    }
}