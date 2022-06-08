using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoInfo.DLL.Data;
using AutoInfo.Domain.Models;
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
        public IEnumerable<Report> GetReports()
        {
            var reports = _dbContext.Reports
                .Include(c => c.Car)
                .Include(c => c.Car.Engine)
                .Include(c => c.Car.License)
                .Include(c => c.Car.Passport)
                .ThenInclude(c => c.Owners)
                .Include(c => c.Car.CarCrashes)
                .ThenInclude(c => c.VehicleDamages)
                .Include(c => c.Car.CarInspects)
                .Include(c => c.Car.CarPlanInspects)
                .Include(c => c.Car.CarRestricts);

            return reports;
        }

        [HttpPost]
        public async Task CreateReport([FromQuery] string vin)
        {
            var car = await _dbContext.Cars.FindAsync(Guid.Parse(vin));
            var newReport = new Report
            {
                Car = car,
                Date = DateTime.Now,
                Id = Guid.NewGuid()
            };

            await _dbContext.Reports.AddAsync(newReport);
            await _dbContext.SaveChangesAsync();
        }
    }
}