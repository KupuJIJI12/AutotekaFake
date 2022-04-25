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

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LicenseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PassportId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Pictures")
                        .HasColumnType("bytea");

                    b.HasKey("VIN");

                    b.HasIndex("LicenseId");

                    b.HasIndex("PassportId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarLicense", b =>
                {
                    b.Property<Guid>("LicenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VIN")
                        .HasColumnType("uuid");

                    b.HasKey("LicenseId");

                    b.ToTable("CarLicenses");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Engine", b =>
                {
                    b.Property<Guid>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Displacement")
                        .HasColumnType("real");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Power")
                        .HasColumnType("smallint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("EngineId");

                    b.ToTable("Engine");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Engine");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("VIN")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VIN");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.VehicleOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CitizenShip")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.Property<string>("PresentAddress")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VehiclePassportPassportId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehiclePassportPassportId");

                    b.ToTable("VehicleOwner");

                    b.HasDiscriminator<string>("Discriminator").HasValue("VehicleOwner");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.VehiclePassport", b =>
                {
                    b.Property<Guid>("PassportId")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("PassportId");

                    b.ToTable("CarPassports");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarEngine", b =>
                {
                    b.HasBaseType("AutoInfo.Domain.Models.Engine");

                    b.HasDiscriminator().HasValue("CarEngine");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarOwner", b =>
                {
                    b.HasBaseType("AutoInfo.Domain.Models.VehicleOwner");

                    b.HasDiscriminator().HasValue("CarOwner");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.Car", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.CarLicense", "CarLicense")
                        .WithMany()
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoInfo.Domain.Models.VehiclePassport", "CarPassport")
                        .WithMany()
                        .HasForeignKey("PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AutoInfo.Domain.Models.VehicleCharacteristic", "Characteristic", b1 =>
                        {
                            b1.Property<Guid>("CarVIN")
                                .HasColumnType("uuid");

                            b1.Property<string>("Brand")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Color")
                                .HasColumnType("text");

                            b1.Property<Guid>("EngineId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<float?>("Weight")
                                .HasColumnType("real");

                            b1.HasKey("CarVIN");

                            b1.HasIndex("EngineId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarVIN");

                            b1.HasOne("AutoInfo.Domain.Models.Engine", "Engine")
                                .WithMany()
                                .HasForeignKey("EngineId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Engine");
                        });

                    b.Navigation("CarLicense");

                    b.Navigation("CarPassport");

                    b.Navigation("Characteristic")
                        .IsRequired();
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Car.CarLicense", b =>
                {
                    b.OwnsOne("AutoInfo.Domain.Models.Passport", "Passport", b1 =>
                        {
                            b1.Property<Guid>("CarLicenseLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<string>("IssuingAuthority")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("IssuingDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<Guid>("PassportId")
                                .HasColumnType("uuid");

                            b1.Property<int>("SeriesAndNumberPassport")
                                .HasColumnType("integer");

                            b1.HasKey("CarLicenseLicenseId");

                            b1.ToTable("CarLicenses");

                            b1.WithOwner()
                                .HasForeignKey("CarLicenseLicenseId");
                        });

                    b.OwnsOne("AutoInfo.Domain.Models.VehicleCharacteristic", "Characteristic", b1 =>
                        {
                            b1.Property<Guid>("CarLicenseLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Brand")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Color")
                                .HasColumnType("text");

                            b1.Property<Guid>("EngineId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<float?>("Weight")
                                .HasColumnType("real");

                            b1.HasKey("CarLicenseLicenseId");

                            b1.HasIndex("EngineId");

                            b1.ToTable("CarLicenses");

                            b1.WithOwner()
                                .HasForeignKey("CarLicenseLicenseId");

                            b1.HasOne("AutoInfo.Domain.Models.Engine", "Engine")
                                .WithMany()
                                .HasForeignKey("EngineId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Engine");
                        });

                    b.Navigation("Characteristic")
                        .IsRequired();

                    b.Navigation("Passport")
                        .IsRequired();
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.Report", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.Car.Car", "Car")
                        .WithMany()
                        .HasForeignKey("VIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.VehicleOwner", b =>
                {
                    b.HasOne("AutoInfo.Domain.Models.VehiclePassport", "VehiclePassport")
                        .WithMany("Owners")
                        .HasForeignKey("VehiclePassportPassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehiclePassport");
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.VehiclePassport", b =>
                {
                    b.OwnsOne("AutoInfo.Domain.Models.VehicleCharacteristic", "Characteristic", b1 =>
                        {
                            b1.Property<Guid>("VehiclePassportPassportId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Brand")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Color")
                                .HasColumnType("text");

                            b1.Property<Guid>("EngineId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<float?>("Weight")
                                .HasColumnType("real");

                            b1.HasKey("VehiclePassportPassportId");

                            b1.HasIndex("EngineId");

                            b1.ToTable("CarPassports");

                            b1.HasOne("AutoInfo.Domain.Models.Engine", "Engine")
                                .WithMany()
                                .HasForeignKey("EngineId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("VehiclePassportPassportId");

                            b1.Navigation("Engine");
                        });

                    b.Navigation("Characteristic")
                        .IsRequired();
                });

            modelBuilder.Entity("AutoInfo.Domain.Models.VehiclePassport", b =>
                {
                    b.Navigation("Owners");
                });
#pragma warning restore 612, 618
        }
    }
}
