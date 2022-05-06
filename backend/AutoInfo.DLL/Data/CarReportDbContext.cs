using System;
using System.Collections.Generic;
using AutoInfo.Domain.Enums;
using AutoInfo.Domain.Models;
using AutoInfo.Domain.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoInfo.DLL.Data
{
    public sealed class CarReportDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<CarEngine> CarEngines { get; set; }
        public DbSet<CarPassport> CarPassports { get; set; }
        public DbSet<CarLicense> CarLicenses { get; set; }

        public CarReportDbContext(DbContextOptions<CarReportDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Report>();

            builder.Entity<CarEngine>();
            
            builder.Entity<CarOwner>(typeBuilder =>
            {
                typeBuilder.Property(p => p.FirstName);
                typeBuilder.Property(p => p.SecondName);
                typeBuilder.Property(p => p.MiddleName);
                typeBuilder.Property(p => p.FullName);
            });
        }
    }
}