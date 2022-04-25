using AutoInfo.Domain.Enums;

namespace AutoInfo.Domain.Models.Car
{
    public class CarOwner : VehicleOwner
    {
        public CarOwner(string firstName, string secondName, string middleName = "")
            : base(firstName, secondName, middleName)
        { }
    }
}