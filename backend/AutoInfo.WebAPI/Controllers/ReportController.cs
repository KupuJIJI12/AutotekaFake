using System;
using System.Collections.Generic;
using System.Linq;
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
                .Include(c => c.Car.CarRestricts)
                .Include(c => c.Car.Photos)
                .Include(c => c.Car.Fines);

            return reports;
        }

        [HttpGet]
        [Route("report")]
        public Report GetReport(string reportId)
        {
            var report = _dbContext.Reports
                .Where(r => r.Id == Guid.Parse(reportId))
                .Include(c => c.Car)
                .Include(c => c.Car.Engine)
                .Include(c => c.Car.License)
                .Include(c => c.Car.Passport)
                .ThenInclude(c => c.Owners)
                .Include(c => c.Car.CarCrashes)
                .ThenInclude(c => c.VehicleDamages)
                .Include(c => c.Car.CarInspects)
                .Include(c => c.Car.CarPlanInspects)
                .Include(c => c.Car.CarRestricts)
                .Include(c => c.Car.Photos)
                .Include(c => c.Car.Fines)
                .First();
            
            return report;
        }

        [HttpPost]
        public async Task<string> CreateReport([FromQuery] string vin)
        {
            var report = await _dbContext.Reports
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Car.VIN == Guid.Parse(vin));
            
            if (report != null)
            {
                return report.Id.ToString();
            }
            
            var car = await _dbContext.Cars.FindAsync(Guid.Parse(vin));
            var reportId = Guid.NewGuid();
            var newReport = new Report
            {
                Car = car,
                Date = DateTime.Now,
                Id = reportId
            };

            await _dbContext.Reports.AddAsync(newReport);
            await _dbContext.SaveChangesAsync();

            return reportId.ToString();
        }
    }
}