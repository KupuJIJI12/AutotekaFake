using System.ComponentModel.DataAnnotations.Schema;

namespace AutoInfo.Domain.Models.Car
{
    public class Car : Vehicle
    {
        public override CarCharacteristic Characteristic { get; }
        public string CarNumber { get; set; }
        [ForeignKey("PassportId")]
        public CarPassport CarPassport { get; set; }
        [ForeignKey("LicenseId")]
        public CarLicense CarLicense { get; set; }

    }
}