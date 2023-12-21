﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace be_semigura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231221081004_AddDataEntryTable")]
    partial class AddDataEntryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("be_semigura.Models.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FactoryId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Models.Container", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<double?>("Capacity")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DeleteFlg")
                        .HasColumnType("bit");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("LocationId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("Models.DataEntry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<double?>("Acid")
                        .HasColumnType("float");

                    b.Property<double?>("AlcoholDegree")
                        .HasColumnType("float");

                    b.Property<double?>("AminoAcid")
                        .HasColumnType("float");

                    b.Property<double?>("BaumeDegree")
                        .HasColumnType("float");

                    b.Property<string>("ContainerId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Glucose")
                        .HasColumnType("float");

                    b.Property<string>("LotContainerId")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("MeasureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.HasIndex("LotContainerId");

                    b.ToTable("DataEntry");
                });

            modelBuilder.Entity("Models.Factory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Factory");
                });

            modelBuilder.Entity("Models.Lot", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FactoryId")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("MaterialClassification")
                        .HasColumnType("int");

                    b.Property<string>("MaterialId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double?>("RicePolishingRatio")
                        .HasColumnType("float");

                    b.Property<string>("RicePolishingRatioName")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("Lot");
                });

            modelBuilder.Entity("Models.LotContainer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ContainerId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LotId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TempMax")
                        .HasColumnType("float");

                    b.Property<double?>("TempMin")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.HasIndex("LocationId");

                    b.HasIndex("LotId");

                    b.ToTable("LotContainer");
                });

            modelBuilder.Entity("Models.LotContainerTerminal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LotContainerId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TerminalId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LotContainerId");

                    b.HasIndex("TerminalId");

                    b.ToTable("LotContainerTerminal");
                });

            modelBuilder.Entity("Models.Material", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Models.SensorData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Humidity")
                        .HasColumnType("float");

                    b.Property<string>("LotContainerId")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("MeasureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Temperature1")
                        .HasColumnType("float");

                    b.Property<double?>("Temperature2")
                        .HasColumnType("float");

                    b.Property<double?>("Temperature3")
                        .HasColumnType("float");

                    b.Property<string>("TerminalId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LotContainerId");

                    b.HasIndex("TerminalId");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("Models.Terminal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DeleteFlg")
                        .HasColumnType("bit");

                    b.Property<string>("LoginId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Account")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Account");

                    b.ToTable("User");
                });

            modelBuilder.Entity("be_semigura.Models.Location", b =>
                {
                    b.HasOne("Models.Factory", "Factory")
                        .WithMany("Locations")
                        .HasForeignKey("FactoryId");

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("Models.Container", b =>
                {
                    b.HasOne("be_semigura.Models.Location", "Location")
                        .WithMany("Containers")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Models.DataEntry", b =>
                {
                    b.HasOne("Models.Container", "Container")
                        .WithMany("DataEntrys")
                        .HasForeignKey("ContainerId");

                    b.HasOne("Models.LotContainer", "LotContainer")
                        .WithMany("DataEntrys")
                        .HasForeignKey("LotContainerId");

                    b.Navigation("Container");

                    b.Navigation("LotContainer");
                });

            modelBuilder.Entity("Models.Lot", b =>
                {
                    b.HasOne("Models.Factory", "Factory")
                        .WithMany("Lots")
                        .HasForeignKey("FactoryId");

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("Models.LotContainer", b =>
                {
                    b.HasOne("Models.Container", "Container")
                        .WithMany("LotContainers")
                        .HasForeignKey("ContainerId");

                    b.HasOne("be_semigura.Models.Location", "Location")
                        .WithMany("LotContainers")
                        .HasForeignKey("LocationId");

                    b.HasOne("Models.Lot", "Lot")
                        .WithMany("LotContainers")
                        .HasForeignKey("LotId");

                    b.Navigation("Container");

                    b.Navigation("Location");

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("Models.LotContainerTerminal", b =>
                {
                    b.HasOne("Models.LotContainer", "LotContainer")
                        .WithMany("LotContainerTerminals")
                        .HasForeignKey("LotContainerId");

                    b.HasOne("Models.Terminal", "Terminal")
                        .WithMany("LotContainerTerminals")
                        .HasForeignKey("TerminalId");

                    b.Navigation("LotContainer");

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("Models.SensorData", b =>
                {
                    b.HasOne("Models.LotContainer", "LotContainer")
                        .WithMany("SensorDatas")
                        .HasForeignKey("LotContainerId");

                    b.HasOne("Models.Terminal", "Terminal")
                        .WithMany("SensorDatas")
                        .HasForeignKey("TerminalId");

                    b.Navigation("LotContainer");

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("be_semigura.Models.Location", b =>
                {
                    b.Navigation("Containers");

                    b.Navigation("LotContainers");
                });

            modelBuilder.Entity("Models.Container", b =>
                {
                    b.Navigation("DataEntrys");

                    b.Navigation("LotContainers");
                });

            modelBuilder.Entity("Models.Factory", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Lots");
                });

            modelBuilder.Entity("Models.Lot", b =>
                {
                    b.Navigation("LotContainers");
                });

            modelBuilder.Entity("Models.LotContainer", b =>
                {
                    b.Navigation("DataEntrys");

                    b.Navigation("LotContainerTerminals");

                    b.Navigation("SensorDatas");
                });

            modelBuilder.Entity("Models.Terminal", b =>
                {
                    b.Navigation("LotContainerTerminals");

                    b.Navigation("SensorDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
