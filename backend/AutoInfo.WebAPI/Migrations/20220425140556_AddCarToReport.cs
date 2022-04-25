using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoInfo.WebAPI.Migrations
{
    public partial class AddCarToReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VIN",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_VIN",
                table: "Reports",
                column: "VIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Cars_VIN",
                table: "Reports",
                column: "VIN",
                principalTable: "Cars",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Cars_VIN",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_VIN",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Reports");
        }
    }
}
