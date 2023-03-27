﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entity.Miasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wojewodztwo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Miasto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "Katowice",
                            Wojewodztwo = "Slaskie"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "Chorzow",
                            Wojewodztwo = "Slaskie"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "Bytom",
                            Wojewodztwo = "Slaskie"
                        });
                });

            modelBuilder.Entity("DAL.Entity.Miejsce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MiejsceInwalidzkieId")
                        .HasColumnType("int");

                    b.Property<int>("ParkingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiejsceInwalidzkieId");

                    b.HasIndex("ParkingId");

                    b.ToTable("Miejsce");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MiejsceInwalidzkieId = 1,
                            ParkingId = 1
                        },
                        new
                        {
                            Id = 2,
                            ParkingId = 3
                        },
                        new
                        {
                            Id = 3,
                            ParkingId = 2
                        });
                });

            modelBuilder.Entity("DAL.Entity.MiejsceInwalidzkie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdMiejsca")
                        .HasColumnType("int");

                    b.Property<decimal>("RozmiarMiejsca")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdMiejsca")
                        .IsUnique()
                        .HasFilter("[IdMiejsca] IS NOT NULL");

                    b.ToTable("MiejsceInwalidzkie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdMiejsca = 2,
                            RozmiarMiejsca = 15m
                        });
                });

            modelBuilder.Entity("DAL.Entity.Opiekun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Opiekun");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Imie = "Michał",
                            Nazwisko = "Czajkowski"
                        },
                        new
                        {
                            Id = 2,
                            Imie = "Konrad",
                            Nazwisko = "Bladziak"
                        });
                });

            modelBuilder.Entity("DAL.Entity.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdMiasta")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdMiasta");

                    b.ToTable("Parking");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adres = "Kolejowa 16",
                            IdMiasta = 1,
                            Nazwa = "Slaski"
                        },
                        new
                        {
                            Id = 2,
                            Adres = "Wesoła 21",
                            IdMiasta = 2,
                            Nazwa = "Chorzowski"
                        },
                        new
                        {
                            Id = 3,
                            Adres = "Jana Pawła II 51",
                            IdMiasta = 1,
                            Nazwa = "Na zakręcie"
                        },
                        new
                        {
                            Id = 4,
                            Adres = "Grzybowa 11",
                            IdMiasta = 3,
                            Nazwa = "Przy galerii"
                        });
                });

            modelBuilder.Entity("DAL.Entity.Rezerwacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Do")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMiejsca")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Od")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdMiejsca");

                    b.ToTable("Rezerwacja");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Do = new DateTime(2023, 7, 12, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            IdMiejsca = 2,
                            Imie = "Maciej",
                            Nazwisko = "Grzybowski",
                            Od = new DateTime(2023, 7, 12, 14, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("OpiekunParking", b =>
                {
                    b.Property<int>("OpiekunowieId")
                        .HasColumnType("int");

                    b.Property<int>("ParkingiId")
                        .HasColumnType("int");

                    b.HasKey("OpiekunowieId", "ParkingiId");

                    b.HasIndex("ParkingiId");

                    b.ToTable("OpiekunParking");
                });

            modelBuilder.Entity("DAL.Entity.Miejsce", b =>
                {
                    b.HasOne("DAL.Entity.MiejsceInwalidzkie", "MiejsceInwalidzkie")
                        .WithMany()
                        .HasForeignKey("MiejsceInwalidzkieId");

                    b.HasOne("DAL.Entity.Parking", "Parking")
                        .WithMany("Miejsca")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiejsceInwalidzkie");

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("DAL.Entity.MiejsceInwalidzkie", b =>
                {
                    b.HasOne("DAL.Entity.Miejsce", "Miejsce")
                        .WithOne()
                        .HasForeignKey("DAL.Entity.MiejsceInwalidzkie", "IdMiejsca");

                    b.Navigation("Miejsce");
                });

            modelBuilder.Entity("DAL.Entity.Parking", b =>
                {
                    b.HasOne("DAL.Entity.Miasto", "Miasto")
                        .WithMany("Parkingi")
                        .HasForeignKey("IdMiasta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miasto");
                });

            modelBuilder.Entity("DAL.Entity.Rezerwacja", b =>
                {
                    b.HasOne("DAL.Entity.Miejsce", "Miejsce")
                        .WithMany("Rezerwacje")
                        .HasForeignKey("IdMiejsca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miejsce");
                });

            modelBuilder.Entity("OpiekunParking", b =>
                {
                    b.HasOne("DAL.Entity.Opiekun", null)
                        .WithMany()
                        .HasForeignKey("OpiekunowieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entity.Parking", null)
                        .WithMany()
                        .HasForeignKey("ParkingiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entity.Miasto", b =>
                {
                    b.Navigation("Parkingi");
                });

            modelBuilder.Entity("DAL.Entity.Miejsce", b =>
                {
                    b.Navigation("Rezerwacje");
                });

            modelBuilder.Entity("DAL.Entity.Parking", b =>
                {
                    b.Navigation("Miejsca");
                });
#pragma warning restore 612, 618
        }
    }
}
