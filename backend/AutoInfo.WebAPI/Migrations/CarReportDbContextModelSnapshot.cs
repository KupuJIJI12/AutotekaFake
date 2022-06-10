﻿// <auto-generated />
using System;
using AutoInfo.DLL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AutoInfo.WebAPI.Migrations
{
    [DbContext(typeof(CarReportDbContext))]
    partial class CarReportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.Car", b =>
                {
                    b.Property<Guid>("VIN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BodyNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("EngineNumber")
                        .HasColumnType("uuid");

                    b.Property<double>("LastMileage")
                        .HasColumnType("double precision");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("VIN");

                    b.HasIndex("EngineNumber");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarCrash", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CarCrashes");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarDamage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CarCrashId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarCrashId");

                    b.ToTable("CarDamage");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarEngine", b =>
                {
                    b.Property<Guid>("EngineNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<float?>("Displacement")
                        .HasColumnType("real");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short?>("Power")
                        .HasColumnType("smallint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("EngineNumber");

                    b.ToTable("CarEngines");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarInspect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarVIN")
                        .HasColumnType("uuid");

                    b.Property<double?>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Mileage")
                        .HasColumnType("double precision");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarVIN");

                    b.ToTable("CarInspects");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarLicense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CarPassportId")
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("CarPassportId");

                    b.ToTable("CarLicenses");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CitizenShip")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("text");

                    b.Property<int>("OwnerType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OwnershipDuration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("OwnershipPeriod")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PresentAddress")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CarOwners");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarPassport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uuid");

                    b.Property<string>("IssuingAuthority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SeriesAndNumberPassport")
                        .HasColumnType("integer");

                    b.Property<DateTime>("YearOfManufacture")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("CarPassports");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarPlanInspect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarVIN")
                        .HasColumnType("uuid");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Mileage")
                        .HasColumnType("double precision");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarVIN");

                    b.ToTable("CarPlanInspects");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarRestrict", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarVIN")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarVIN");

                    b.ToTable("CarRestricts");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Fine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CarVIN")
                        .HasColumnType("uuid");

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DecisionNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CarVIN");

                    b.ToTable("Fine");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CarVIN")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Value")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("CarVIN");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CarVIN")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarVIN");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("CarCarCrash", b =>
                {
                    b.Property<Guid>("CarCrashesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarsVIN")
                        .HasColumnType("uuid");

                    b.HasKey("CarCrashesId", "CarsVIN");

                    b.HasIndex("CarsVIN");

                    b.ToTable("CarCarCrash");
                });

            modelBuilder.Entity("CarOwnerCarPassport", b =>
                {
                    b.Property<Guid>("OwnersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehiclePassportsId")
                        .HasColumnType("uuid");

                    b.HasKey("OwnersId", "VehiclePassportsId");

                    b.HasIndex("VehiclePassportsId");

                    b.ToTable("CarOwnerCarPassport");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.Car", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.CarEngine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineNumber");

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarDamage", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.CarCrash", null)
                        .WithMany("VehicleDamages")
                        .HasForeignKey("CarCrashId");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarInspect", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Car")
                        .WithMany("CarInspects")
                        .HasForeignKey("CarVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarLicense", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Car")
                        .WithOne("License")
                        .HasForeignKey("AutoInfo.Domain.Models.Car.CarLicense", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoInfo.Domain.Models.Car.CarPassport", "CarPassport")
                        .WithMany()
                        .HasForeignKey("CarPassportId");

                    b.Navigation("Car");

                    b.Navigation("CarPassport");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarPassport", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Vehicle")
                        .WithOne("Passport")
                        .HasForeignKey("AutoInfo.Domain.Models.Car.CarPassport", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarPlanInspect", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Car")
                        .WithMany("CarPlanInspects")
                        .HasForeignKey("CarVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarRestrict", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Car")
                        .WithMany("CarRestricts")
                        .HasForeignKey("CarVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Fine", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", null)
                        .WithMany("Fines")
                        .HasForeignKey("CarVIN");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Photo", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", null)
                        .WithMany("Photos")
                        .HasForeignKey("CarVIN");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Report", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarVIN");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarCarCrash", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.CarCrash", null)
                        .WithMany()
                        .HasForeignKey("CarCrashesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoInfo.Domain.Models.Car.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarOwnerCarPassport", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.CarOwner", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoInfo.Domain.Models.Car.CarPassport", null)
                        .WithMany()
                        .HasForeignKey("VehiclePassportsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.Car", b =>
                {
                    b.Navigation("CarInspects");

                    b.Navigation("CarPlanInspects");

                    b.Navigation("CarRestricts");

                    b.Navigation("Fines");

                    b.Navigation("License")
                        .IsRequired();

                    b.Navigation("Passport")
                        .IsRequired();

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarCrash", b =>
                {
                    b.Navigation("VehicleDamages");
                });
#pragma warning restore 612, 618
        }
    }
}
