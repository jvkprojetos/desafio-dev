﻿// <auto-generated />
using System;
using DesafioDev.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioDev.Infra.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230726161918_CreateTablesMigration")]
    partial class CreateTablesMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesafioDev.Domain.Entities.Establishment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Establishments", (string)null);
                });

            modelBuilder.Entity("DesafioDev.Domain.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners", (string)null);
                });

            modelBuilder.Entity("DesafioDev.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EstablishmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Hour")
                        .HasColumnType("time");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("DesafioDev.Domain.Entities.Establishment", b =>
                {
                    b.HasOne("DesafioDev.Domain.Entities.Owner", "Owner")
                        .WithOne("Establishment")
                        .HasForeignKey("DesafioDev.Domain.Entities.Establishment", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DesafioDev.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("DesafioDev.Domain.Entities.Establishment", "Establishment")
                        .WithMany("Transactions")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establishment");
                });

            modelBuilder.Entity("DesafioDev.Domain.Entities.Establishment", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("DesafioDev.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Establishment");
                });
#pragma warning restore 612, 618
        }
    }
}
