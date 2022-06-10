using System;
using System.Collections.Generic;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models
{
    public abstract class VehicleOwner<TPassport> : Person
    {
        public virtual IEnumerable<TPassport> VehiclePassports { get; set; }
        
        public OwnerType OwnerType { get; set; }
        
        public string? OrganizationName { get; set; }

        public DateTime OwnershipPeriod { get; set; }

        public DateTime OwnershipDuration { get; set; }
        
        protected VehicleOwner(string firstName, string secondName, string middleName = "")
            : base(firstName, secondName, middleName)
        { }

        public VehicleOwner(string firstName, string secondName, OwnerType ownerType, string middleName = "",
            string organizationName = "") : this(firstName, secondName, middleName)
        {
            OwnerType = ownerType;
            OrganizationName = ownerType is OwnerType.LegalPerson ? organizationName : "";
        }
    }
}