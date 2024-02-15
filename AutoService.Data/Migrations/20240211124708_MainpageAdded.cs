using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Data.Migrations
{
    /// <inheritdoc />
    public partial class MainpageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MainPage",
                table: "Araclar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 2, 11, 15, 47, 8, 706, DateTimeKind.Local).AddTicks(356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPage",
                table: "Araclar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 2, 3, 21, 57, 45, 779, DateTimeKind.Local).AddTicks(5155));
        }
    }
}
