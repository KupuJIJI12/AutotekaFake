using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoInfo.WebAPI.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCrashes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCrashes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<short>(type: "smallint", nullable: true),
                    Displacement = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEngines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    PresentAddress = table.Column<string>(type: "text", nullable: true),
                    CitizenShip = table.Column<string>(type: "text", nullable: true),
                    OwnerType = table.Column<int>(type: "integer", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarDamage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarCrashId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDamage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDamage_CarCrashes_CarCrashId",
                        column: x => x.CarCrashId,
                        principalTable: "CarCrashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<Guid>(type: "uuid", nullable: false),
                    CarNumber = table.Column<string>(type: "text", nullable: false),
                    EngineNumber = table.Column<Guid>(type: "uuid", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Cars_CarEngines_EngineNumber",
                        column: x => x.EngineNumber,
                        principalTable: "CarEngines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarCarCrash",
                columns: table => new
                {
                    CarCrashesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarsVIN = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCarCrash", x => new { x.CarCrashesId, x.CarsVIN });
                    table.ForeignKey(
                        name: "FK_CarCarCrash_CarCrashes_CarCrashesId",
                        column: x => x.CarCrashesId,
                        principalTable: "CarCrashes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCarCrash_Cars_CarsVIN",
                        column: x => x.CarsVIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarInspects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarVIN = table.Column<Guid>(type: "uuid", nullable: false),
                    Mileage = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Organization = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarInspects_Cars_CarVIN",
                        column: x => x.CarVIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarPassports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeriesAndNumberPassport = table.Column<int>(type: "integer", nullable: false),
                    IssuingAuthority = table.Column<string>(type: "text", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    YearOfManufacture = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPassports_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarPlanInspects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    CarVIN = table.Column<Guid>(type: "uuid", nullable: false),
                    Mileage = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Organization = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPlanInspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPlanInspects_Cars_CarVIN",
                        column: x => x.CarVIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRestricts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarVIN = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Organization = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRestricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRestricts_Cars_CarVIN",
                        column: x => x.CarVIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarVIN = table.Column<Guid>(type: "uuid", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Cars_CarVIN",
                        column: x => x.CarVIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CarPassportId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarLicenses_CarPassports_CarPassportId",
                        column: x => x.CarPassportId,
                        principalTable: "CarPassports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarLicenses_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOwnerCarPassport",
                columns: table => new
                {
                    OwnersId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehiclePassportsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwnerCarPassport", x => new { x.OwnersId, x.VehiclePassportsId });
                    table.ForeignKey(
                        name: "FK_CarOwnerCarPassport_CarOwners_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "CarOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOwnerCarPassport_CarPassports_VehiclePassportsId",
                        column: x => x.VehiclePassportsId,
                        principalTable: "CarPassports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCarCrash_CarsVIN",
                table: "CarCarCrash",
                column: "CarsVIN");

            migrationBuilder.CreateIndex(
                name: "IX_CarDamage_CarCrashId",
                table: "CarDamage",
                column: "CarCrashId");

            migrationBuilder.CreateIndex(
                name: "IX_CarInspects_CarVIN",
                table: "CarInspects",
                column: "CarVIN");

            migrationBuilder.CreateIndex(
                name: "IX_CarLicenses_CarId",
                table: "CarLicenses",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarLicenses_CarPassportId",
                table: "CarLicenses",
                column: "CarPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOwnerCarPassport_VehiclePassportsId",
                table: "CarOwnerCarPassport",
                column: "VehiclePassportsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPassports_CarId",
                table: "CarPassports",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarPlanInspects_CarVIN",
                table: "CarPlanInspects",
                column: "CarVIN");

            migrationBuilder.CreateIndex(
                name: "IX_CarRestricts_CarVIN",
                table: "CarRestricts",
                column: "CarVIN");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineNumber",
                table: "Cars",
                column: "EngineNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CarVIN",
                table: "Reports",
                column: "CarVIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCarCrash");

            migrationBuilder.DropTable(
                name: "CarDamage");

            migrationBuilder.DropTable(
                name: "CarInspects");

            migrationBuilder.DropTable(
                name: "CarLicenses");

            migrationBuilder.DropTable(
                name: "CarOwnerCarPassport");

            migrationBuilder.DropTable(
                name: "CarPlanInspects");

            migrationBuilder.DropTable(
                name: "CarRestricts");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "CarCrashes");

            migrationBuilder.DropTable(
                name: "CarOwners");

            migrationBuilder.DropTable(
                name: "CarPassports");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarEngines");
        }
    }
}
