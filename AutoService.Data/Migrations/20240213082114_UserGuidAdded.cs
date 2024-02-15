using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserGuidAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Kullanicilar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UploadDate", "UserGuid" },
                values: new object[] { new DateTime(2024, 2, 13, 11, 21, 14, 435, DateTimeKind.Local).AddTicks(915), new Guid("ad0aae76-ccc1-4a8d-8b21-c8176ee3c244") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Kullanicilar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 2, 11, 15, 47, 8, 706, DateTimeKind.Local).AddTicks(356));
        }
    }
}
