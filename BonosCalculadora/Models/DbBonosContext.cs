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

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
