﻿// <auto-generated />
using System;
using ChineseDebtTrap.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChineseDebtTrap.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220516101837_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChineseDebtTrap.Core.Borpower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Borpowers");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("BorpowerId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("LenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.Property<int?>("SensitiveTerritoryId")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BorpowerId");

                    b.HasIndex("CountryId");

                    b.HasIndex("LenderId");

                    b.HasIndex("SectorId");

                    b.HasIndex("SensitiveTerritoryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Lender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lenders");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.SensitiveTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SensitiveTerritories");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Company", b =>
                {
                    b.HasOne("ChineseDebtTrap.Core.Borpower", "Borpower")
                        .WithMany("Companies")
                        .HasForeignKey("BorpowerId");

                    b.HasOne("ChineseDebtTrap.Core.Country", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("CountryId");

                    b.HasOne("ChineseDebtTrap.Core.Lender", "Lender")
                        .WithMany("Companies")
                        .HasForeignKey("LenderId");

                    b.HasOne("ChineseDebtTrap.Core.Sector", "Sector")
                        .WithMany("Companies")
                        .HasForeignKey("SectorId");

                    b.HasOne("ChineseDebtTrap.Core.SensitiveTerritory", "SensitiveTerritory")
                        .WithMany("Companies")
                        .HasForeignKey("SensitiveTerritoryId");

                    b.Navigation("Borpower");

                    b.Navigation("Country");

                    b.Navigation("Lender");

                    b.Navigation("Sector");

                    b.Navigation("SensitiveTerritory");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Borpower", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Country", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Lender", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.Sector", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ChineseDebtTrap.Core.SensitiveTerritory", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
