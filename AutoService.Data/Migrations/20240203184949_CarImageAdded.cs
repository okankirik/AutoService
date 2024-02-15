using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarImageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Araclar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Araclar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Araclar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 2, 3, 21, 49, 48, 991, DateTimeKind.Local).AddTicks(3422));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Araclar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 2, 2, 18, 51, 24, 138, DateTimeKind.Local).AddTicks(4609));
        }
    }
}
