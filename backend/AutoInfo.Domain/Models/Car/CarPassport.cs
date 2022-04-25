using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models.Car
{
    public class CarPassport : VehiclePassport
    {
        [ForeignKey("VIN")]
        public override CarCharacteristic Characteristic { get; }
        [ForeignKey("Id")]
        public IEnumerable<VehicleOwner> Owners { get; set; }
    }
}