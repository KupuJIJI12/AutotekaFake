using System;
using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models
{
    public class VehicleOwner : Person
    {
        public Guid Id { get; set; }
        public OwnerType OwnerType { get; }
        public string? OrganizationName { get; }
        
        
        /*protected VehicleOwner(string name, string surname, string patronymic = "")
            : base(name, surname, patronymic)
        { }

        protected VehicleOwner(string name, string surname, OwnerType ownerType, string patronymic = "",
            string organizationName = "") : this(name, surname, patronymic)
        {
            OwnerType = ownerType;
            OrganizationName = ownerType is OwnerType.LegalPerson ? organizationName : "";
        }*/
    }
}