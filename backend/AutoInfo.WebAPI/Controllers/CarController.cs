using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoInfo.DLL.Data;
using AutoInfo.Domain.Enums;
using AutoInfo.Domain.Models;
using AutoInfo.Domain.Models.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoInfo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarReportDbContext _dbContext;

        public CarController(CarReportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            var car = _dbContext.Cars
                .Include(c => c.Engine)
                .Include(c => c.License)
                .ThenInclude(c => c.CarPassport)
                .Include(c => c.Passport)
                .ThenInclude(c => c.Owners)
                .Include(c => c.CarInspects)
                .Include(c => c.CarPlanInspects)
                .Include(c => c.CarCrashes)
                .ThenInclude(c => c.VehicleDamages)
                .Include(c => c.CarRestricts);
            
            return car;
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateCar(Car car)
        {
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPost]
        public async Task CreateCar()
        {
            var carUid = Guid.NewGuid();
            var testCar = new Car
            {
                Brand = "Zhiguli",
                Model = "ВАЗ-2106",
                Color = "Вишнёвый",
                Weight = 1000.0f,
                VIN = carUid,
                CarNumber = "АУ777Е",
                Engine = new CarEngine
                {
                    EngineNumber = Guid.NewGuid(),
                    Displacement = 1.6f,
                    Model = "Mitsubishi",
                    Power = 105,
                    Type = EngineType.PetrolEngine
                },
                Passport = new CarPassport
                {
                    SeriesAndNumberPassport = 327042304,
                    IssuingAuthority = "Москва ул.Уличная",
                    IssuingDate = DateTime.Today,
                    YearOfManufacture = new DateTime(1990, 1, 12),
                    Id = Guid.NewGuid(),
                    Owners = new[]
                    {
                        new CarOwner("Пётр",
                            "Петров")
                        {
                            PresentAddress = "Москва",
                            CitizenShip = "Россия",
                            OwnerType = OwnerType.NaturalPerson,
                            OrganizationName = "УФМС РФ",
                            Id = Guid.NewGuid()
                        },
                        new CarOwner("Иван",
                            "Иванов")
                        {
                            PresentAddress = "Москва",
                            CitizenShip = "Россия",
                            OwnerType = OwnerType.NaturalPerson,
                            OrganizationName = "УФМС РФ",
                            Id = Guid.NewGuid()
                        }
                    },
                },
                License = new CarLicense
                {
                    Id = Guid.NewGuid(),
                    CarId = carUid,
                    RegistrationNumber = "AOIENCALSKDNALW",
                    Category = VehicleСategory.B,
                },
                CarPlanInspects = new[]
                {
                    new CarPlanInspect
                    {
                        Mileage = 6000,
                        Date = new DateTime(2003, 5, 10),
                        Region = "Москва",
                        Organization = "LADA",
                        Description = "Плановый техосмотр",
                        Cost = 2000,
                        Id = Guid.NewGuid(),
                        CardNumber = "DLFKSDKFDSKFL",
                    },
                    new CarPlanInspect
                    {
                        Mileage = 15000,
                        Date = new DateTime(2003, 12, 2),
                        Region = "Москва",
                        Organization = "LADA",
                        Description = "Плановый техосмотр",
                        Cost = 2000,
                        Id = Guid.NewGuid(),
                        CardNumber = "DLFKSDKFDSKFL",
                    }
                },
                CarInspects = new[]
                {
                    new CarInspect
                    {
                        Mileage = 8000,
                        Date = new DateTime(2003, 8, 24),
                        Region = "Москва",
                        Organization = "FitService",
                        Description = "Замена бампера",
                        Cost = 2000,
                        Id = Guid.NewGuid(),
                    },
                    new CarInspect
                    {
                        Mileage = 17000,
                        Date = new DateTime(2004, 2, 1),
                        Region = "Москва",
                        Organization = "FitService",
                        Description = "Покраска двери",
                        Cost = 5000,
                        Id = Guid.NewGuid(),
                    }
                },
                CarCrashes = new[]
                {
                    new CarCrash
                    {
                        Date = new DateTime(2003, 8, 20),
                        Type = "Столкновение.",
                        VehicleDamages = new[]
                        {
                            new CarDamage {Type = VehicleDamageType.Bumper, Id = Guid.NewGuid()}
                        },
                        Id = Guid.NewGuid()
                    }
                },
                CarRestricts = new[]
                {
                    new CarRestrict
                    {
                        Date = DateTime.Today,
                        Type = "Ограничение на регистрационные действия.",
                        Organization = "Суд Москвы",
                        Region = "Москва",
                        Id = Guid.NewGuid(),
                    }
                }
            };

            await _dbContext.Cars.AddAsync(testCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}