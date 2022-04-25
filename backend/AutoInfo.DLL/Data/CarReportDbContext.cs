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
        public DbSet<CarCharacteristic> CarCharacteristics { get; set; }
        public DbSet<CarLicense> CarLicenses { get; set; }
        public DbSet<CarPassport> CarPassports { get; set; }

        public CarReportDbContext(DbContextOptions<CarReportDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*var carUid = Guid.NewGuid();
            var carCharacteristic = new CarCharacteristic
            {
                VIN = carUid,
                Brand = "Zhiguli",
                Model = "ВАЗ-2106",
                Color = "Вишнёвый",
                Weight = 1000.0f,
                ChassisNumber = Guid.NewGuid(),
                Engine = new CarEngine
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
                VIN = Guid.NewGuid(),
                Pictures = new List<byte[]>(),
                CarNumber = "А777УЕ",
                CarPassport = new CarPassport
                {
                    SeriesAndNumberPassport = 234234,
                    IssuingAuthority = "asdas",
                    IssuingDate = default,
                    PassportId = Guid.NewGuid(),
                    YearOfManufacture = default,
                    Owners = new []{new CarOwner("Иван", "Иванов", OwnerType.NaturalPerson)
                    {
                        Id = Guid.NewGuid(),
                        CitizenShip = "RU",
                        PresentAddress = "Moscow",
                    }}
                },
                CarLicense = new CarLicense
                {
                    LicenseId = Guid.NewGuid(),
                    VIN = carUid,
                    RegistrationNumber = "sdfdsaf",
                    Characteristic = carCharacteristic,
                    Category = VehicleСategory.B,
                    Passport = new Passport
                    {
                        SeriesAndNumberPassport = 23423,
                        IssuingAuthority = "null",
                        IssuingDate = default
                    }
                },
                Characteristic =
                {
                    VIN = carUid
                }
            };*/

            builder.Entity<CarPassport>()
                .HasBaseType<VehiclePassport>();
                
                builder.Entity<Passport>()
                    .HasKey(p => p.PassportId);

            builder.Entity<CarLicense>();

            builder.Entity<Car>()
                .HasBaseType<Vehicle>();
               // .HasData(testCar);

            builder.Entity<Report>()
                .HasOne(p => p.Vehicle)
                .WithOne();

            builder.Entity<CarEngine>()
                .HasBaseType<Engine>();

            builder.Entity<CarOwner>(b =>
            {
                b.HasBaseType<VehicleOwner>();
                /*b.HasBaseType<Person>();
                //b.Property(p => p.FullName);
                b.Property(p => p.OrganizationName);
                b.Property(p => p.OwnerType);*/
            });

            builder.Entity<CarCharacteristic>()
                .HasBaseType<VehicleCharacteristic>();
        }
    }
}