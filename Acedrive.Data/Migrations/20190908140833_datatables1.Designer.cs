﻿// <auto-generated />
using System;
using Acedrive.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acedrive.Data.Migrations
{
    [DbContext(typeof(AcedriveDbContext))]
    [Migration("20190908140833_datatables1")]
    partial class datatables1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acedrive.Domain.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationAddress");

                    b.Property<string>("LocationCity");

                    b.Property<string>("LocationState");

                    b.Property<string>("LocationZipcode");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Acedrive.Domain.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PaymentAmount");

                    b.Property<int>("RentalId");

                    b.Property<int>("UserId");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Acedrive.Domain.Models.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndDate");

                    b.Property<int>("StartDate");

                    b.Property<int>("UserId");

                    b.Property<int>("VehicleId");

                    b.Property<string>("VehicleStatus")
                        .HasMaxLength(1);

                    b.HasKey("RentalId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Acedrive.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsInsured");

                    b.Property<string>("LastName");

                    b.Property<string>("UserAddress");

                    b.Property<string>("UserCity");

                    b.Property<DateTime>("UserDOB");

                    b.Property<string>("UserDriverLicense");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserPhoneNumber");

                    b.Property<string>("UserState")
                        .HasMaxLength(2);

                    b.Property<string>("UserZipcode")
                        .HasMaxLength(10);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Acedrive.Domain.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<string>("VehicleLicensePlate");

                    b.Property<int>("VehicleTypeRefId");

                    b.Property<int>("Year");

                    b.HasKey("VehicleId");

                    b.HasIndex("VehicleTypeRefId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Acedrive.Domain.Models.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("VehicleTypeCostPerDay");

                    b.Property<string>("VehicleTypeName");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Acedrive.Domain.Models.Vehicle", b =>
                {
                    b.HasOne("Acedrive.Domain.Models.VehicleType", "VehType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
