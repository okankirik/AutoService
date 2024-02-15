using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoService.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfExitFromService = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionsMade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGuarantee = table.Column<bool>(type: "bit", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Araclar_Markalar_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Markalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Roller_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentityNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_Araclar_CarId",
                        column: x => x.CarId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Satislar_Araclar_CarId",
                        column: x => x.CarId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Satislar_Musteriler_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "Email", "IsActive", "Name", "Password", "Phone", "RoleId", "Surname", "UploadDate", "UserName" },
                values: new object[] { 1, "admin@otoservissatis.tc", true, "Admin", "123456", "0850", 1, "admin", new DateTime(2024, 2, 2, 18, 51, 24, 138, DateTimeKind.Local).AddTicks(4609), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_BrandId",
                table: "Araclar",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_RoleId",
                table: "Kullanicilar",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_CarId",
                table: "Musteriler",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_CarId",
                table: "Satislar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_CustomerId",
                table: "Satislar",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Servisler");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Markalar");
        }
    }
}
