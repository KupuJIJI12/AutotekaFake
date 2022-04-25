using System;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models
{
    public class VehicleOwner : Person
    {
        public Guid Id { get; set; }
        
        public VehiclePassport VehiclePassport { get; set; }
        
        public OwnerType OwnerType { get; set; }
        
        public string? OrganizationName { get; set; }

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