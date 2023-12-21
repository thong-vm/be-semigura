using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_semigura.Migrations
{
    public partial class AddDataEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });
            // constraints: table =>
            // {
            //     table.PrimaryKey("PK_DataEntry", x => x.Id);
            //     table.ForeignKey(
            //         name: "FK_DataEntry_Container_ContainerId",
            //         column: x => x.ContainerId,
            //         principalTable: "Container",
            //         principalColumn: "Id");
            //     table.ForeignKey(
            //         name: "FK_DataEntry_LotContainer_LotContainerId",
            //         column: x => x.LotContainerId,
            //         principalTable: "LotContainer",
            //         principalColumn: "Id");
            // });

            //     migrationBuilder.CreateIndex(
            //         name: "IX_SensorData_LotContainerId",
            //         table: "SensorData",
            //         column: "LotContainerId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_SensorData_TerminalId",
            //         table: "SensorData",
            //         column: "TerminalId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_LotContainerTerminal_LotContainerId",
            //         table: "LotContainerTerminal",
            //         column: "LotContainerId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_LotContainerTerminal_TerminalId",
            //         table: "LotContainerTerminal",
            //         column: "TerminalId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_LotContainer_ContainerId",
            //         table: "LotContainer",
            //         column: "ContainerId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_LotContainer_LocationId",
            //         table: "LotContainer",
            //         column: "LocationId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_LotContainer_LotId",
            //         table: "LotContainer",
            //         column: "LotId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_Lot_FactoryId",
            //         table: "Lot",
            //         column: "FactoryId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_Location_FactoryId",
            //         table: "Location",
            //         column: "FactoryId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_Container_LocationId",
            //         table: "Container",
            //         column: "LocationId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_DataEntry_ContainerId",
            //         table: "DataEntry",
            //         column: "ContainerId");

            //     migrationBuilder.CreateIndex(
            //         name: "IX_DataEntry_LotContainerId",
            //         table: "DataEntry",
            //         column: "LotContainerId");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_Container_Location_LocationId",
            //         table: "Container",
            //         column: "LocationId",
            //         principalTable: "Location",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_Location_Factory_FactoryId",
            //         table: "Location",
            //         column: "FactoryId",
            //         principalTable: "Factory",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_Lot_Factory_FactoryId",
            //         table: "Lot",
            //         column: "FactoryId",
            //         principalTable: "Factory",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_LotContainer_Container_ContainerId",
            //         table: "LotContainer",
            //         column: "ContainerId",
            //         principalTable: "Container",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_LotContainer_Location_LocationId",
            //         table: "LotContainer",
            //         column: "LocationId",
            //         principalTable: "Location",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_LotContainer_Lot_LotId",
            //         table: "LotContainer",
            //         column: "LotId",
            //         principalTable: "Lot",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_LotContainerTerminal_LotContainer_LotContainerId",
            //         table: "LotContainerTerminal",
            //         column: "LotContainerId",
            //         principalTable: "LotContainer",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_LotContainerTerminal_Terminal_TerminalId",
            //         table: "LotContainerTerminal",
            //         column: "TerminalId",
            //         principalTable: "Terminal",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_SensorData_LotContainer_LotContainerId",
            //         table: "SensorData",
            //         column: "LotContainerId",
            //         principalTable: "LotContainer",
            //         principalColumn: "Id");

            //     migrationBuilder.AddForeignKey(
            //         name: "FK_SensorData_Terminal_TerminalId",
            //         table: "SensorData",
            //         column: "TerminalId",
            //         principalTable: "Terminal",
            //         principalColumn: "Id");
            // }

            // protected override void Down(MigrationBuilder migrationBuilder)
            // {
            //     migrationBuilder.DropForeignKey(
            //         name: "FK_Container_Location_LocationId",
            //         table: "Container");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_Location_Factory_FactoryId",
            //         table: "Location");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_Lot_Factory_FactoryId",
            //         table: "Lot");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_LotContainer_Container_ContainerId",
            //         table: "LotContainer");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_LotContainer_Location_LocationId",
            //         table: "LotContainer");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_LotContainer_Lot_LotId",
            //         table: "LotContainer");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_LotContainerTerminal_LotContainer_LotContainerId",
            //         table: "LotContainerTerminal");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_LotContainerTerminal_Terminal_TerminalId",
            //         table: "LotContainerTerminal");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_SensorData_LotContainer_LotContainerId",
            //         table: "SensorData");

            //     migrationBuilder.DropForeignKey(
            //         name: "FK_SensorData_Terminal_TerminalId",
            //         table: "SensorData");

            //     migrationBuilder.DropTable(
            //         name: "DataEntry");

            //     migrationBuilder.DropIndex(
            //         name: "IX_SensorData_LotContainerId",
            //         table: "SensorData");

            //     migrationBuilder.DropIndex(
            //         name: "IX_SensorData_TerminalId",
            //         table: "SensorData");

            //     migrationBuilder.DropIndex(
            //         name: "IX_LotContainerTerminal_LotContainerId",
            //         table: "LotContainerTerminal");

            //     migrationBuilder.DropIndex(
            //         name: "IX_LotContainerTerminal_TerminalId",
            //         table: "LotContainerTerminal");

            //     migrationBuilder.DropIndex(
            //         name: "IX_LotContainer_ContainerId",
            //         table: "LotContainer");

            //     migrationBuilder.DropIndex(
            //         name: "IX_LotContainer_LocationId",
            //         table: "LotContainer");

            //     migrationBuilder.DropIndex(
            //         name: "IX_LotContainer_LotId",
            //         table: "LotContainer");

            //     migrationBuilder.DropIndex(
            //         name: "IX_Lot_FactoryId",
            //         table: "Lot");

            //     migrationBuilder.DropIndex(
            //         name: "IX_Location_FactoryId",
            //         table: "Location");

            //     migrationBuilder.DropIndex(
            //         name: "IX_Container_LocationId",
            //         table: "Container");
        }
    }
}
