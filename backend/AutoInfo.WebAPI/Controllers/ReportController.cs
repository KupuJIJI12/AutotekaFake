using System.Collections.Generic;
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
            return _dbContext.Reports.Include(report => report.Vehicle);
        }
    }
}