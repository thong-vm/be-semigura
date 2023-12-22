using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_semigura.Migrations
{
    public partial class CreateInital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(5)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Note = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<string>(type: "varchar(100)", nullable: true),
                    LoginId = table.Column<string>(type: "varchar(100)", nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", nullable: true),
                    DeleteFlg = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    FactoryId = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Factory_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", nullable: true),
                    FactoryId = table.Column<string>(type: "varchar(100)", nullable: true),
                    MaterialId = table.Column<string>(type: "varchar(100)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaterialClassification = table.Column<int>(type: "int", nullable: true),
                    RicePolishingRatioName = table.Column<string>(type: "varchar(100)", nullable: true),
                    RicePolishingRatio = table.Column<double>(type: "float", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lot_Factory_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", nullable: true),
                    LocationId = table.Column<string>(type: "varchar(100)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    DeleteFlg = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Container_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LotContainer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    LotId = table.Column<string>(type: "varchar(100)", nullable: true),
                    LocationId = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContainerId = table.Column<string>(type: "varchar(100)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempMin = table.Column<double>(type: "float", nullable: true),
                    TempMax = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotContainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotContainer_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LotContainer_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LotContainer_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataEntry",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContainerId = table.Column<string>(type: "varchar(100)", nullable: true),
                    LotContainerId = table.Column<string>(type: "varchar(100)", nullable: true),
                    BaumeDegree = table.Column<double>(type: "float", nullable: true),
                    AlcoholDegree = table.Column<double>(type: "float", nullable: true),
                    Acid = table.Column<double>(type: "float", nullable: true),
                    AminoAcid = table.Column<double>(type: "float", nullable: true),
                    Glucose = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "varchar(500)", nullable: true),
                    MeasureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataEntry_Container_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Container",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataEntry_LotContainer_LotContainerId",
                        column: x => x.LotContainerId,
                        principalTable: "LotContainer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LotContainerTerminal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    LotContainerId = table.Column<string>(type: "varchar(100)", nullable: true),
                    TerminalId = table.Column<string>(type: "varchar(100)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotContainerTerminal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotContainerTerminal_LotContainer_LotContainerId",
                        column: x => x.LotContainerId,
                        principalTable: "LotContainer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LotContainerTerminal_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    TerminalId = table.Column<string>(type: "varchar(100)", nullable: true),
                    LotContainerId = table.Column<string>(type: "varchar(100)", nullable: true),
                    Temperature1 = table.Column<double>(type: "float", nullable: true),
                    Temperature2 = table.Column<double>(type: "float", nullable: true),
                    Temperature3 = table.Column<double>(type: "float", nullable: true),
                    Humidity = table.Column<double>(type: "float", nullable: true),
                    MeasureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorData_LotContainer_LotContainerId",
                        column: x => x.LotContainerId,
                        principalTable: "LotContainer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SensorData_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_LocationId",
                table: "Container",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataEntry_ContainerId",
                table: "DataEntry",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_DataEntry_LotContainerId",
                table: "DataEntry",
                column: "LotContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_FactoryId",
                table: "Location",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_FactoryId",
                table: "Lot",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LotContainer_ContainerId",
                table: "LotContainer",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_LotContainer_LocationId",
                table: "LotContainer",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LotContainer_LotId",
                table: "LotContainer",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_LotContainerTerminal_LotContainerId",
                table: "LotContainerTerminal",
                column: "LotContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_LotContainerTerminal_TerminalId",
                table: "LotContainerTerminal",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_LotContainerId",
                table: "SensorData",
                column: "LotContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_TerminalId",
                table: "SensorData",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Account",
                table: "User",
                column: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEntry");

            migrationBuilder.DropTable(
                name: "LotContainerTerminal");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LotContainer");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Factory");
        }
    }
}
