﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmhiDb;

namespace SmhiDb.Migrations
{
    [DbContext(typeof(SmhiDbContext))]
    [Migration("20210507101430_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("SmhiDb.Model.SmhiLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Href")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rel")
                        .HasColumnType("TEXT");

                    b.Property<int>("SmhiStationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SmhiStationId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("From")
                        .HasColumnType("TEXT");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<int>("SmhiStationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SmhiStationId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerCategory")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SmhiParameterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SmhiParameterId")
                        .IsUnique();

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quality")
                        .HasColumnType("TEXT");

                    b.Property<int>("SmhiStationId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("SmhiStationId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiLink", b =>
                {
                    b.HasOne("SmhiDb.Model.SmhiStation", "SmhiStation")
                        .WithMany("SmhiLinks")
                        .HasForeignKey("SmhiStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SmhiStation");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiPosition", b =>
                {
                    b.HasOne("SmhiDb.Model.SmhiStation", "SmhiStation")
                        .WithMany("SmhiPositions")
                        .HasForeignKey("SmhiStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SmhiStation");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiStation", b =>
                {
                    b.HasOne("SmhiDb.Model.SmhiParameter", "SmhiParameter")
                        .WithOne("SmhiStation")
                        .HasForeignKey("SmhiDb.Model.SmhiStation", "SmhiParameterId");

                    b.Navigation("SmhiParameter");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiValue", b =>
                {
                    b.HasOne("SmhiDb.Model.SmhiStation", "SmhiStation")
                        .WithMany("SmhiValues")
                        .HasForeignKey("SmhiStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SmhiStation");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiParameter", b =>
                {
                    b.Navigation("SmhiStation");
                });

            modelBuilder.Entity("SmhiDb.Model.SmhiStation", b =>
                {
                    b.Navigation("SmhiLinks");

                    b.Navigation("SmhiPositions");

                    b.Navigation("SmhiValues");
                });
#pragma warning restore 612, 618
        }
    }
}
