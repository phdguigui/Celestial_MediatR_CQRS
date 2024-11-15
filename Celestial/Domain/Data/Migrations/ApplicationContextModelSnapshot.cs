﻿// <auto-generated />
using System;
using Celestial.API.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Celestial.Domain.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Celestial.Domain.Entities.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Magnitude")
                        .HasPrecision(18, 2)
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Stars", (string)null);
                });

            modelBuilder.Entity("Celestial.Domain.Entities.Star", b =>
                {
                    b.OwnsOne("Celestial.Domain.ValueObjects.Position", "Position", b1 =>
                        {
                            b1.Property<int>("StarId")
                                .HasColumnType("integer");

                            b1.Property<double>("Declination")
                                .HasColumnType("double precision")
                                .HasColumnName("Declination");

                            b1.Property<double?>("Distance")
                                .HasColumnType("double precision")
                                .HasColumnName("Distance");

                            b1.Property<double>("RightAscension")
                                .HasColumnType("double precision")
                                .HasColumnName("RightAscension");

                            b1.HasKey("StarId");

                            b1.ToTable("Stars");

                            b1.WithOwner()
                                .HasForeignKey("StarId");
                        });

                    b.Navigation("Position")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
