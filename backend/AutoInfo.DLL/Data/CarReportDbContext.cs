using System;
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

        public CarReportDbContext(DbContextOptions<CarReportDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var testCar = new Car {VIN = Guid.NewGuid()};
            builder.Entity<Car>()
                .HasData(testCar);

            builder.Entity<Report>()
                .HasOne(p => p.Vehicle)
                .WithOne();

            builder.Entity<CarOwner>()
                .HasBaseType<Person>()
                .HasData(
                    new CarOwner("Иван", "Иванов", OwnerType.NaturalPerson)
                    {
                        CitizenShip = "RU",
                        PresentAddress = "Moscow"
                    }
                );
        }
    }
}