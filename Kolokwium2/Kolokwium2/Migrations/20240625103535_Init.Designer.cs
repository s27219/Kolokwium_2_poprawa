﻿// <auto-generated />
using System;
using Kolokwium2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240625103535_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ColorID")
                        .HasColumnType("int");

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.HasIndex("ModelID");

                    b.ToTable("cars");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ColorID = 1,
                            ModelID = 1,
                            Name = "car1",
                            PricePerDay = 1000,
                            Seats = 2,
                            VIN = "aaaa"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.CarRental", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("ClientID");

                    b.ToTable("car_rentals");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CarID = 1,
                            ClientID = 1,
                            DateFrom = new DateTime(2024, 6, 25, 12, 35, 34, 868, DateTimeKind.Local).AddTicks(3678),
                            DateTo = new DateTime(2024, 6, 30, 12, 35, 34, 868, DateTimeKind.Local).AddTicks(3722),
                            Discount = 10,
                            TotalPrice = 900
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("clients");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "ul. Wilcza 8c/12",
                            FirstName = "Adam",
                            LastName = "Ryszka"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Color", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("colors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Blue"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Model", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("models");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Model1"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Car", b =>
                {
                    b.HasOne("Kolokwium2.Models.Color", "Color")
                        .WithMany("Cars")
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Kolokwium2.Models.CarRental", b =>
                {
                    b.HasOne("Kolokwium2.Models.Car", "Car")
                        .WithMany("CarRentals")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Client", "Client")
                        .WithMany("CarRentals")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Kolokwium2.Models.Car", b =>
                {
                    b.Navigation("CarRentals");
                });

            modelBuilder.Entity("Kolokwium2.Models.Client", b =>
                {
                    b.Navigation("CarRentals");
                });

            modelBuilder.Entity("Kolokwium2.Models.Color", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Kolokwium2.Models.Model", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
