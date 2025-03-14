﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Puntocharlie.Data;

#nullable disable

namespace Puntocharlie.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250313032833_primeraMigracion")]
    partial class primeraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Puntocharlie.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTecnico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTecnico");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Puntocharlie.Models.PuntoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PuntoServicios");
                });

            modelBuilder.Entity("Puntocharlie.Models.Tecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPuntoServicio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPuntoServicio");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("Puntocharlie.Models.Cita", b =>
                {
                    b.HasOne("Puntocharlie.Models.Tecnico", "Tecnico")
                        .WithMany()
                        .HasForeignKey("IdTecnico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("Puntocharlie.Models.Tecnico", b =>
                {
                    b.HasOne("Puntocharlie.Models.PuntoServicio", "PuntoServicio")
                        .WithMany()
                        .HasForeignKey("IdPuntoServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PuntoServicio");
                });
#pragma warning restore 612, 618
        }
    }
}
