﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reserva;

namespace Reserva.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200318054549_tablaAdminTorneo1")]
    partial class tablaAdminTorneo1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reserva.Models.Admin", b =>
                {
                    b.Property<int>("idAdmin")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnName("Email")
                        .HasMaxLength(20);

                    b.Property<int>("idComplejo")
                        .HasColumnName("IdComplejo")
                        .HasColumnType("int");

                    b.Property<int>("idTorneo")
                        .HasColumnName("IdTorneo")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnName("Nombre")
                        .HasMaxLength(20);

                    b.Property<string>("password")
                        .HasColumnName("Password")
                        .HasMaxLength(20);

                    b.Property<bool>("rol")
                        .HasColumnName("Rol")
                        .HasColumnType("bit");

                    b.HasKey("idAdmin");

                    b.HasIndex("idComplejo");

                    b.HasIndex("idTorneo");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Reserva.Models.Cancha", b =>
                {
                    b.Property<int>("idCancha")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .HasColumnName("Estado")
                        .HasMaxLength(20);

                    b.Property<int>("idComplejo")
                        .HasColumnName("idComplejo")
                        .HasColumnType("int");

                    b.Property<int>("precio")
                        .HasColumnName("Precio")
                        .HasColumnType("int");

                    b.HasKey("idCancha");

                    b.HasIndex("idComplejo");

                    b.ToTable("Cancha");
                });

            modelBuilder.Entity("Reserva.Models.Complejo", b =>
                {
                    b.Property<int>("idComplejo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cantCanchas")
                        .HasColumnName("CantidadDeCanchas")
                        .HasColumnType("int");

                    b.Property<string>("localidad")
                        .HasColumnName("Localidad")
                        .HasMaxLength(20);

                    b.Property<string>("nombre")
                        .HasColumnName("Nombre")
                        .HasMaxLength(20);

                    b.HasKey("idComplejo");

                    b.ToTable("Complejo");
                });

            modelBuilder.Entity("Reserva.Models.Equipo", b =>
                {
                    b.Property<int>("idEquipo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idUsuario")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnName("Nombre")
                        .HasMaxLength(20);

                    b.HasKey("idEquipo");

                    b.HasIndex("idUsuario");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("Reserva.Models.Reservaciones", b =>
                {
                    b.Property<int>("idReservacion")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("horaFinal")
                        .HasColumnName("HoraFinal")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("horaInicial")
                        .HasColumnName("HoraInicial")
                        .HasColumnType("Datetime");

                    b.Property<int>("idCancha")
                        .HasColumnName("idCancha")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("idReservacion");

                    b.HasIndex("idCancha");

                    b.HasIndex("idUsuario");

                    b.ToTable("Reservacion");
                });

            modelBuilder.Entity("Reserva.Models.Torneo", b =>
                {
                    b.Property<int>("idTorneo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("cantEquipos")
                        .HasColumnName("CantidadEquipos")
                        .HasColumnType("decimal");

                    b.Property<string>("nombreTorneo")
                        .HasColumnName("NombreTorneo")
                        .HasMaxLength(20);

                    b.Property<string>("premio")
                        .HasColumnName("Premio")
                        .HasMaxLength(20);

                    b.HasKey("idTorneo");

                    b.ToTable("Torneo");
                });

            modelBuilder.Entity("Reserva.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("edad")
                        .HasColumnName("Edad")
                        .HasColumnType("decimal");

                    b.Property<string>("email")
                        .HasColumnName("Email")
                        .HasMaxLength(20);

                    b.Property<string>("nombre")
                        .HasColumnName("Nombre")
                        .HasMaxLength(20);

                    b.Property<string>("nombreUsuario")
                        .HasColumnName("NombreUsuario")
                        .HasMaxLength(20);

                    b.Property<string>("password")
                        .HasColumnName("Password")
                        .HasMaxLength(20);

                    b.Property<bool>("rol")
                        .HasColumnName("Rol")
                        .HasColumnType("bit");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Reserva.Models.Admin", b =>
                {
                    b.HasOne("Reserva.Models.Complejo", "complejo")
                        .WithMany()
                        .HasForeignKey("idComplejo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Reserva.Models.Torneo", "torneo")
                        .WithMany()
                        .HasForeignKey("idTorneo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reserva.Models.Cancha", b =>
                {
                    b.HasOne("Reserva.Models.Complejo", "complejo")
                        .WithMany()
                        .HasForeignKey("idComplejo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reserva.Models.Equipo", b =>
                {
                    b.HasOne("Reserva.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reserva.Models.Reservaciones", b =>
                {
                    b.HasOne("Reserva.Models.Cancha", "cancha")
                        .WithMany()
                        .HasForeignKey("idCancha")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Reserva.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
