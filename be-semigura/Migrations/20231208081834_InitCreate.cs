using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_semigura.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moromi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    Day = table.Column<string>(type: "varchar(32)", nullable: true),
                    Datetime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Bmd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RoomTemperature = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProductTemperature = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Baume = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JapanSakeLevel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AlcoholContent = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moromi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HashedPassword = table.Column<string>(type: "varchar(128)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Account",
                table: "User",
                column: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moromi");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
