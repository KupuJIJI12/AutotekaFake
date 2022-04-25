using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoInfo.WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<short>(type: "smallint", nullable: false),
                    Displacement = table.Column<float>(type: "real", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarLicenses",
                columns: table => new
                {
                    LicenseId = table.Column<Guid>(type: "uuid", nullable: false),
                    VIN = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    Characteristic_Brand = table.Column<string>(type: "text", nullable: false),
                    Characteristic_Model = table.Column<string>(type: "text", nullable: false),
                    Characteristic_EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Characteristic_Color = table.Column<string>(type: "text", nullable: true),
                    Characteristic_Weight = table.Column<float>(type: "real", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Passport_PassportId = table.Column<Guid>(type: "uuid", nullable: false),
                    Passport_SeriesAndNumberPassport = table.Column<int>(type: "integer", nullable: false),
                    Passport_IssuingAuthority = table.Column<string>(type: "text", nullable: false),
                    Passport_IssuingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLicenses", x => x.LicenseId);
                    table.ForeignKey(
                        name: "FK_CarLicenses_Engine_Characteristic_EngineId",
                        column: x => x.Characteristic_EngineId,
                        principalTable: "Engine",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarPassports",
                columns: table => new
                {
                    PassportId = table.Column<Guid>(type: "uuid", nullable: false),
                    YearOfManufacture = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Characteristic_Brand = table.Column<string>(type: "text", nullable: false),
                    Characteristic_Model = table.Column<string>(type: "text", nullable: false),
                    Characteristic_EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Characteristic_Color = table.Column<string>(type: "text", nullable: true),
                    Characteristic_Weight = table.Column<float>(type: "real", nullable: true),
                    SeriesAndNumberPassport = table.Column<int>(type: "integer", nullable: false),
                    IssuingAuthority = table.Column<string>(type: "text", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPassports", x => x.PassportId);
                    table.ForeignKey(
                        name: "FK_CarPassports_Engine_Characteristic_EngineId",
                        column: x => x.Characteristic_EngineId,
                        principalTable: "Engine",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<Guid>(type: "uuid", nullable: false),
                    CarNumber = table.Column<string>(type: "text", nullable: false),
                    PassportId = table.Column<Guid>(type: "uuid", nullable: false),
                    LicenseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Characteristic_Brand = table.Column<string>(type: "text", nullable: false),
                    Characteristic_Model = table.Column<string>(type: "text", nullable: false),
                    Characteristic_EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Characteristic_Color = table.Column<string>(type: "text", nullable: true),
                    Characteristic_Weight = table.Column<float>(type: "real", nullable: true),
                    Pictures = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Cars_CarLicenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "CarLicenses",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarPassports_PassportId",
                        column: x => x.PassportId,
                        principalTable: "CarPassports",
                        principalColumn: "PassportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Engine_Characteristic_EngineId",
                        column: x => x.Characteristic_EngineId,
                        principalTable: "Engine",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VehiclePassportPassportId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerType = table.Column<int>(type: "integer", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    PresentAddress = table.Column<string>(type: "text", nullable: true),
                    CitizenShip = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleOwner_CarPassports_VehiclePassportPassportId",
                        column: x => x.VehiclePassportPassportId,
                        principalTable: "CarPassports",
                        principalColumn: "PassportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarLicenses_Characteristic_EngineId",
                table: "CarLicenses",
                column: "Characteristic_EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPassports_Characteristic_EngineId",
                table: "CarPassports",
                column: "Characteristic_EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Characteristic_EngineId",
                table: "Cars",
                column: "Characteristic_EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LicenseId",
                table: "Cars",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PassportId",
                table: "Cars",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwner_VehiclePassportPassportId",
                table: "VehicleOwner",
                column: "VehiclePassportPassportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "VehicleOwner");

            migrationBuilder.DropTable(
                name: "CarLicenses");

            migrationBuilder.DropTable(
                name: "CarPassports");

            migrationBuilder.DropTable(
                name: "Engine");
        }
    }
}
