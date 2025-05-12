using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TransportePublicoAPI.Models;

namespace TransportePublicoAPI.Data
{
    public class TransporteDbContext : DbContext
    {
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Tiempo> Tiempos { get; set; }
        public DbSet<Frecuencia> Frecuencias { get; set; }
        public DbSet<Distancia> Distancias { get; set; }
        public DbSet<HechosRuta> HechosRutas { get; set; }

        public TransporteDbContext(DbContextOptions<TransporteDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación entre la tabla de hechos y las dimensiones
            modelBuilder.Entity<HechosRuta>()
                .HasOne(hr => hr.Ruta)
                .WithMany()
                .HasForeignKey(hr => hr.RutaId);

            modelBuilder.Entity<HechosRuta>()
                .HasOne(hr => hr.Tiempo)
                .WithMany()
                .HasForeignKey(hr => hr.TiempoId);

            modelBuilder.Entity<HechosRuta>()
                .HasOne(hr => hr.Frecuencia)
                .WithMany()
                .HasForeignKey(hr => hr.FrecuenciaId);

            modelBuilder.Entity<HechosRuta>()
                .HasOne(hr => hr.Distancia)
                .WithMany()
                .HasForeignKey(hr => hr.DistanciaId);
        }
    }
}
