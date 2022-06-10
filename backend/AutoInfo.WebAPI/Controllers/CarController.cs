using System;
using System.Collections.Generic;
using System.Net;
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
            using var webClient = new WebClient();
            var image1 = webClient.DownloadData("https://31.img.avito.st/image/1/1.UvqbOLa6_hOtkTwWsyU9xUqb-BcvG_bRKpv6Gy-T_A.XqFkRC0tI-zUSeCsuyS9Y53PwJVn78Cqsm1ZQSR00X8");
            var image2 = webClient.DownloadData("https://79.img.avito.st/image/1/1.zjIHpba6YtsxDKDeF-qhDdYGZN-zhmoZtgZm07MOYA.XOS0qXsakAILTD-Z4P94ZDid3Qgk-cPr1c43vxSRgUE");
            var carUid = Guid.NewGuid();
            var testCar = new Car
            {
                Brand = "LADA",
                Model = "ВАЗ-2114",
                Color = "Белый",
                Weight = 1000.0f,
                VIN = carUid,
                CarNumber = "АУ777Е",
                BodyNumber = "XW8AN2XXXFXXXXXXX",
                Type = "Легковая (хэтчбек)",
                LastMileage = 90000,
                Engine = new CarEngine
                {
                    EngineNumber = Guid.NewGuid(),
                    Displacement = 1.6f,
                    Model = "Zhiguli",
                    Power = 90,
                    Type = EngineType.PetrolEngine
                },
                Passport = new CarPassport
                {
                    SeriesAndNumberPassport = 327042304,
                    IssuingAuthority = "Москва ул.Уличная",
                    IssuingDate = DateTime.Today,
                    YearOfManufacture = new DateTime(2013, 1, 12),
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
                            Id = Guid.NewGuid(),
                            OwnershipPeriod = new DateTime(2013, 5, 10),
                            OwnershipDuration = new DateTime(2015, 6, 10),
                        },
                        new CarOwner("Иван",
                            "Иванов")
                        {
                            PresentAddress = "Москва",
                            CitizenShip = "Россия",
                            OwnerType = OwnerType.NaturalPerson,
                            OrganizationName = "УФМС РФ",
                            Id = Guid.NewGuid(),
                            OwnershipPeriod = new DateTime(2015, 6, 10),
                            OwnershipDuration = new DateTime(2018, 5, 10),
                        },
                        new CarOwner("Александр",
                            "Александров")
                        {
                            PresentAddress = "Москва",
                            CitizenShip = "Россия",
                            OwnerType = OwnerType.NaturalPerson,
                            OrganizationName = "УФМС РФ",
                            Id = Guid.NewGuid(),
                            OwnershipPeriod = new DateTime(2018, 5, 10),
                            OwnershipDuration = DateTime.Today
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
                        Date = new DateTime(2014, 7, 10),
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
                        Date = new DateTime(2014, 12, 2),
                        Region = "Москва",
                        Organization = "LADA",
                        Description = "Плановый техосмотр",
                        Cost = 2000,
                        Id = Guid.NewGuid(),
                        CardNumber = "DLFKSDKFDSKFL",
                    },
                    new CarPlanInspect
                    {
                        Mileage = 30000,
                        Date = new DateTime(2015, 4, 2),
                        Region = "Москва",
                        Organization = "LADA",
                        Description = "Плановый техосмотр",
                        Cost = 2000,
                        Id = Guid.NewGuid(),
                        CardNumber = "DLFKSDKFDSKFL",
                    },
                    new CarPlanInspect
                    {
                        Mileage = 75000,
                        Date = new DateTime(2015, 8, 2),
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
                        Date = new DateTime(2014, 8, 24),
                        Region = "Москва",
                        Organization = "FitService",
                        Description = "Замена бампера",
                        Cost = 2000,
                        Id = Guid.NewGuid(),
                    },
                    new CarInspect
                    {
                        Mileage = 25000,
                        Date = new DateTime(2015, 2, 1),
                        Region = "Москва",
                        Organization = "FitService",
                        Description = "Покраска двери",
                        Cost = 5000,
                        Id = Guid.NewGuid(),
                    },
                    new CarInspect
                    {
                        Mileage = 60000,
                        Date = new DateTime(2015, 10, 1),
                        Region = "Москва",
                        Organization = "FitService",
                        Description = "Покраска двери",
                        Cost = 5000,
                        Id = Guid.NewGuid(),
                    }
                    ,
                    new CarInspect
                    {
                        Mileage = 90000,
                        Date = new DateTime(2016, 2, 1),
                        Region = "Москва",
                        Organization = "FitService",
                        Description = "Ремонт двигателя",
                        Cost = 15000,
                        Id = Guid.NewGuid(),
                    }
                },
                CarCrashes = new[]
                {
                    new CarCrash
                    {
                        Date = new DateTime(2016, 8, 20),
                        Type = "Столкновение",
                        VehicleDamages = new[]
                        {
                            new CarDamage {Type = VehicleDamageType.Bumper, Id = Guid.NewGuid()},
                            new CarDamage {Type = VehicleDamageType.RightFirstDoor, Id = Guid.NewGuid()},
                            new CarDamage {Type = VehicleDamageType.LeftFirstDoor, Id = Guid.NewGuid()}
                        },
                        Id = Guid.NewGuid()
                    }
                },
                CarRestricts = new[]
                {
                    new CarRestrict
                    {
                        Date = new DateTime(2016, 10, 20),
                        Type = "Ограничение на регистрационные действия.",
                        Organization = "Суд Москвы",
                        Region = "Москва",
                        Id = Guid.NewGuid(),
                    }
                },
                Photos = new []
                {
                    new Photo()
                    {
                        Id = Guid.NewGuid(),
                        Value = image1
                    },
                    new Photo()
                    {
                        Id = Guid.NewGuid(),
                        Value = image2
                    }
                },
                Fines = new []
                {
                    new Fine()
                    {
                        Cost = 500.0,
                        Date = new DateTime(2018, 7, 20),
                        DecisionNumber = "XXXXXXXXXXXXXXXX9054",
                        Description = "Превышение установленной скорости движения транспортного средства на величину более 20, но не более 40 км/ч..",
                        Id = Guid.NewGuid()
                    },
                    new Fine()
                    {
                        Cost = 1500.0,
                        Date = new DateTime(2018, 10, 20),
                        DecisionNumber = "XXXXXXXXXXXXXXXX7064",
                        Description = "Отсутствует",
                        Id = Guid.NewGuid()
                    }
                }
            };

            await _dbContext.Cars.AddAsync(testCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}