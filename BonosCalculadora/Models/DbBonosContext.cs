using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class DbBonosContext : DbContext
    {
        public DbBonosContext()
        {

        }
        public DbBonosContext(DbContextOptions<DbBonosContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Calculadora> Calculadora { get; set; }
        public virtual DbSet<FrecuenciaPago> FrecuenciaPago { get; set; }
        public virtual DbSet<DiasAño> DiasAño { get; set; }
        public virtual DbSet<Capitalizacion> Capitalizacion { get; set; }
        public virtual DbSet<TasaInteres> TasaInteres { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-T5IR78P\\PIERO;Database=DbBonos;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nombre)
                     .HasMaxLength(50)
                     .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                     .HasMaxLength(50)
                     .IsUnicode(false);

                entity.Property(e => e.Dni)
                     .HasMaxLength(50)
                     .IsUnicode(false);

                entity.Property(e => e.Correo)
                     .HasMaxLength(50)
                     .IsUnicode(false);

                entity.Property(e => e.Usuario).HasMaxLength(256);

            });

            modelBuilder.Entity<Historial>(entity =>
            {
                entity.Property(e => e.Observacion)
                     .HasMaxLength(50)
                     .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                      .WithMany(p => p.Historial)
                      .HasForeignKey(d => d.ClienteId)
                      .HasConstraintName("FK_Historial_Ciente");


            });
            modelBuilder.Entity<Capitalizacion>(entity => 
            {
                entity.Property(c => c.NCapitalizacion)
                      .HasMaxLength(50)
                      .IsUnicode(false);

            });
            modelBuilder.Entity<DiasAño>(entity => 
            {
                entity.Property(c => c.Dias)
                     .HasMaxLength(9)
                     .IsUnicode(false);

            });
            modelBuilder.Entity<FrecuenciaPago>(entity =>
            {
                entity.Property(c => c.Diasfrecuencia)
                   .HasMaxLength(10)
                   .IsUnicode(false);

                entity.Property(c => c.Tipofrecuencia)
                       .HasMaxLength(15)
                       .IsUnicode(false);

            });
            modelBuilder.Entity<MetodoPago>(entity => 
            {
                entity.Property(c => c.TipoMetodo)
                  .HasMaxLength(15)
                  .IsUnicode(false);


            });
            modelBuilder.Entity<TasaInteres>(entity => 
            {
                entity.Property(c => c.Tasa)
                 .HasMaxLength(10)
                 .IsUnicode(false);

                entity.Property(c => c.Tipotasa)
                 .HasMaxLength(15)
                 .IsUnicode(false);


            });
            modelBuilder.Entity<Calculadora>(entity=>
            {
                entity.Property(e => e.Vnominal)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.Vcomercial)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.NAños)
                   .HasMaxLength(11)
                   .IsUnicode(false);

                entity.Property(e => e.Cok)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.ImRenta)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("fecha");

                entity.Property(e => e.Prima)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.Estructuración)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.Colocación)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.Flotacion)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.Cavali)
                   .HasMaxLength(15)
                   .IsUnicode(false);


                entity.HasOne(d => d.Cliente)
                       .WithMany(p => p.Calculadora)
                       .HasForeignKey(d => d.ClienteId)
                       .HasConstraintName("FK_Calculadora_Ciente");

                entity.HasOne(d => d.Capitalizacion)
                    .WithMany(p => p.Calculadora)
                    .HasForeignKey(d => d.CapitalizacionId)
                    .HasConstraintName("FK_Calculadora_Capitalizacion");

                entity.HasOne(d => d.FrecuenciaPago)
                    .WithMany(p => p.Calculadora)
                    .HasForeignKey(d => d.FrecuenciaPagoId)
                    .HasConstraintName("FK_Calculadora_FrecuenciaPago");

                entity.HasOne(d => d.DiasAño)
                    .WithMany(p => p.Calculadora)
                    .HasForeignKey(d => d.DiasAñoId)
                    .HasConstraintName("FK_Calculadora_DiasAño");

                entity.HasOne(d => d.TasaInteres)
                    .WithMany(p => p.Calculadora)
                    .HasForeignKey(d => d.TasaInteresId)
                    .HasConstraintName("FK_Calculadora_TasaInteres");

                entity.HasOne(d => d.MetodoPago)
                    .WithMany(p => p.Calculadora)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .HasConstraintName("FK_Calculadora_MetodoPago");

            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
