﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoInfo.DLL.Data;
using AutoInfo.Domain.Enums;
using AutoInfo.Domain.Models.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoInfo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly CarReportDbContext _dbContext;
        
        public ReportController(CarReportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Car> GetReports()
        {
            var report = _dbContext.Cars
                .Include(c => c.Engine)
                .Include(c => c.License)
                .Include(c => c.Passport)
                .ThenInclude(p => p.Owners);

            return report;
        }

        [HttpPost]
        public async Task AddCar()
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
                    SeriesAndNumberPassport = 0,
                    IssuingAuthority = "",
                    IssuingDate = default,
                    YearOfManufacture = default,
                    Id = Guid.NewGuid(),
                    Owners = new []
                    {
                        new CarOwner("firstName", "secondName")
                        {
                            PresentAddress = null,
                            CitizenShip = null,
                            OwnerType = OwnerType.NaturalPerson,
                            OrganizationName = null,
                            Id = Guid.NewGuid()
                        }
                    },
                },
                License = new CarLicense
                {
                    Id = Guid.NewGuid(),
                    CarId = carUid,
                    RegistrationNumber = "sfasafs",
                    Category = VehicleСategory.B,
                }
            };
            
            await _dbContext.Cars.AddAsync(testCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}