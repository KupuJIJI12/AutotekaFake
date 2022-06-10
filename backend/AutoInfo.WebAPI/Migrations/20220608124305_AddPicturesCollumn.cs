using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoInfo.WebAPI.Migrations
{
    public partial class AddPicturesCollumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<byte[]>(type: "bytea", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CarVIN = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Cars_CarVIN",
                        column: x => x.CarVIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CarVIN",
                table: "Photo",
                column: "CarVIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");
        }
    }
}
