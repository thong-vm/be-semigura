using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_semigura.Migrations
{
    public partial class AddMoromi : Migration
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
                    RoomTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTemperature = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Baume = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JapanSakeLevel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AlcoholContent = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moromi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moromi");
        }
    }
}
