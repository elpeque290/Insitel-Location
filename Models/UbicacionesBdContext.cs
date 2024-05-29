
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GoogleMaps;
using Microsoft.CodeAnalysis;

namespace CRUD_INSITEL.Models
{
    // Contexto de la base de datos para la tabla de ubicaciones.
    public partial class UbicacionesBdContext : DbContext
    {
        // Constructor sin parámetros.
        public UbicacionesBdContext()
        {
        }

        // Constructor que acepta opciones de configuración del contexto.
        public UbicacionesBdContext(DbContextOptions<UbicacionesBdContext> options)
            : base(options)
        {
        }

        // DbSet para la tabla de ubicaciones en la base de datos.
        public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

        // Método llamado cuando el contexto está configurando opciones.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración predeterminada si no se proporcionan otras opciones.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=UbicacionesBD.mssql.somee.com; database=UbicacionesBD; user id=elpeque290_SQLLogin_1; pwd=wv4x3e1ao1; TrustServerCertificate=True");
            }
        }

        // Método llamado cuando se está configurando el modelo.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Ubicacione.
            modelBuilder.Entity<Ubicacione>(entity =>
            {
                // Nombre de la tabla en la base de datos.
                entity.ToTable("Ubicaciones");

                // Definición de la clave primaria.
                entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC07426F49EB");

                // Restricciones y configuraciones de propiedades.
                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Longitud)
                    .IsRequired();

                entity.Property(e => e.Latitud)
                    .IsRequired();

                entity.Property(e => e.TemperaturaActual)
                    .IsRequired();
            });

            // Llamada a método de configuración parcial.
            OnModelCreatingPartial(modelBuilder);
        }

        // Método parcial llamado durante la configuración del modelo.
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }



}
