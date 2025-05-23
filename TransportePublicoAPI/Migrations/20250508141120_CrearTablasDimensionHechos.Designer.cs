﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportePublicoAPI.Data;

#nullable disable

namespace TransportePublicoAPI.Migrations
{
    [DbContext(typeof(TransporteDbContext))]
    [Migration("20250508141120_CrearTablasDimensionHechos")]
    partial class CrearTablasDimensionHechos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TransportePublicoAPI.Models.Distancia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DistanciaKm")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Distancias");
                });

            modelBuilder.Entity("TransportePublicoAPI.Models.Frecuencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FrecuenciaDomingoYFestivos")
                        .HasColumnType("int");

                    b.Property<int>("FrecuenciaLunesASabado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Frecuencias");
                });

            modelBuilder.Entity("TransportePublicoAPI.Models.HechosRuta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DistanciaId")
                        .HasColumnType("int");

                    b.Property<int>("FrecuenciaId")
                        .HasColumnType("int");

                    b.Property<int>("RutaId")
                        .HasColumnType("int");

                    b.Property<int>("TiempoDestinoMinutosDomYFestivos")
                        .HasColumnType("int");

                    b.Property<int>("TiempoDestinoMinutosLunesASab")
                        .HasColumnType("int");

                    b.Property<int>("TiempoId")
                        .HasColumnType("int");

                    b.Property<int>("TiempoTotalMinutosDomYFestivos")
                        .HasColumnType("int");

                    b.Property<int>("TiempoTotalMinutosLunesASab")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistanciaId");

                    b.HasIndex("FrecuenciaId");

                    b.HasIndex("RutaId");

                    b.HasIndex("TiempoId");

                    b.ToTable("HechosRutas");
                });

            modelBuilder.Entity("TransportePublicoAPI.Models.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstacionFin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstacionInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreRuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sentido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rutas");
                });

            modelBuilder.Entity("TransportePublicoAPI.Models.Tiempo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HoraFinDomingoYFestivos")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraFinLunesASabado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicioDomingoYFestivos")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicioLunesASabado")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tiempos");
                });

            modelBuilder.Entity("TransportePublicoAPI.Models.HechosRuta", b =>
                {
                    b.HasOne("TransportePublicoAPI.Models.Distancia", "Distancia")
                        .WithMany()
                        .HasForeignKey("DistanciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportePublicoAPI.Models.Frecuencia", "Frecuencia")
                        .WithMany()
                        .HasForeignKey("FrecuenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportePublicoAPI.Models.Ruta", "Ruta")
                        .WithMany()
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportePublicoAPI.Models.Tiempo", "Tiempo")
                        .WithMany()
                        .HasForeignKey("TiempoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distancia");

                    b.Navigation("Frecuencia");

                    b.Navigation("Ruta");

                    b.Navigation("Tiempo");
                });
#pragma warning restore 612, 618
        }
    }
}
