﻿// <auto-generated />
using System;
using BookingManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingManagement.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240122152917_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookingManagement.Core.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "DummyAdress",
                            Capacity = 150,
                            Category = "Vine House",
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(507),
                            Name = "DummyName",
                            Status = true,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Adress = "DummyAdress",
                            Capacity = 130,
                            Category = "Fine Dine",
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(519),
                            Name = "DummyName",
                            Status = true,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Adress = "DummyAdress",
                            Capacity = 200,
                            Category = "Grill House",
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(521),
                            Name = "DummyName",
                            Status = true,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BookingManagement.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(809),
                            Gender = "Kadın",
                            Name = "Test",
                            Surname = "Test",
                            TelNumber = 21211222,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(811),
                            Gender = "Kadın",
                            Name = "Test1",
                            Surname = "Test1",
                            TelNumber = 21211222,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(812),
                            Gender = "Erkek",
                            Name = "Test2",
                            Surname = "Test2",
                            TelNumber = 21211222,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 1, 22, 18, 29, 16, 959, DateTimeKind.Local).AddTicks(812),
                            Gender = "Erkek",
                            Name = "Test3",
                            Surname = "Test3",
                            TelNumber = 21211222,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BookingManagement.Core.Models.UserBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBooking");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlaceId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            PlaceId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            PlaceId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            PlaceId = 3,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("BookingManagement.Core.Models.UserBooking", b =>
                {
                    b.HasOne("BookingManagement.Core.Models.Place", "Place")
                        .WithMany("UserBookings")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingManagement.Core.Models.User", "User")
                        .WithMany("UserBookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingManagement.Core.Models.Place", b =>
                {
                    b.Navigation("UserBookings");
                });

            modelBuilder.Entity("BookingManagement.Core.Models.User", b =>
                {
                    b.Navigation("UserBookings");
                });
#pragma warning restore 612, 618
        }
    }
}