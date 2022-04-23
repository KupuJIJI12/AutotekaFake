using System.Collections.Generic;

namespace AutoInfo.Domain.Models.Car
{
    public class CarPassport : VehiclePassport
    {
        public override CarCharacteristic Characteristic { get; }
        public override IEnumerable<CarOwner> Owners { get; }
    }
}