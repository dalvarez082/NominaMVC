using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NominaMVC.Models
{
    public partial class NominaContext : DbContext
    {
        public NominaContext()
        {
        }

        public NominaContext(DbContextOptions<NominaContext> options)
            : base(options)
        {

        }


        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__FC851A3A6E0EBE0F");

                entity.ToTable("Pago");

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.IdPersona)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.oPersona)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__IdPersona__3B75D760");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__2EC8D2ACEF997DE6");

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.oRol)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Persona__IdRol__38996AB5");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584CA1337A42");

                entity.ToTable("Rol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
