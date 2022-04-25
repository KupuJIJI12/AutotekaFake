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
            return _dbContext.Cars.Include(c => c.Characteristic).ThenInclude(c => c.Engine);
        }

        [HttpPost]
        public async Task AddCar()
        {
            var carUid = Guid.NewGuid();
            var carCharacteristic = new VehicleCharacteristic()
            {
                Brand = "Zhiguli",
                Model = "ВАЗ-2106",
                Color = "Вишнёвый",
                Weight = 1000.0f,
                Engine = new Engine()
                {
                    EngineId = Guid.NewGuid(),
                    Displacement = 1.6f,
                    Model = "Mitsubishi",
                    Power = 105,
                    Type = EngineType.PetrolEngine
                }
            };
            var testCar = new Car
            {
                VIN = carUid,
                Characteristic = carCharacteristic,
                CarNumber = "afsdfa"
            };
            await _dbContext.Cars.AddAsync(testCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}