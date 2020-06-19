﻿// <auto-generated />
using System;
using BonosCalculadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BonosCalculadora.Migrations.DbBonos
{
    [DbContext(typeof(DbBonosContext))]
    partial class DbBonosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BonosCalculadora.Models.Calculadora", b =>
                {
                    b.Property<int>("CalculadoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapitalizacionId")
                        .HasColumnType("int");

                    b.Property<string>("Cavali")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Cok")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Colocación")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int>("DiasAño")
                        .HasColumnType("int");

                    b.Property<string>("Estructuración")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnName("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Flotacion")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int>("FrecuenciaPagoId")
                        .HasColumnType("int");

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<int>("NAños")
                        .HasColumnType("int")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Prima")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("TasaDeInteres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TasaInteresId")
                        .HasColumnType("int");

                    b.Property<string>("Vcomercial")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Vnominal")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("CalculadoraId");

                    b.HasIndex("CapitalizacionId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FrecuenciaPagoId");

                    b.HasIndex("MetodoPagoId");

                    b.HasIndex("TasaInteresId");

                    b.ToTable("Calculadora");
                });

            modelBuilder.Entity("BonosCalculadora.Models.Capitalizacion", b =>
                {
                    b.Property<int>("CapitalizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoCapitalizacion")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("CapitalizacionId");

                    b.ToTable("Capitalizacion");
                });

            modelBuilder.Entity("BonosCalculadora.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BonosCalculadora.Models.FrecuenciaPago", b =>
                {
                    b.Property<int>("FrecuenciaPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipofrecuencia")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("FrecuenciaPagoId");

                    b.ToTable("FrecuenciaPago");
                });

            modelBuilder.Entity("BonosCalculadora.Models.Historial", b =>
                {
                    b.Property<int>("HistorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("HistorialId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Historial");
                });

            modelBuilder.Entity("BonosCalculadora.Models.MetodoPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoMetodo")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("BonosCalculadora.Models.TasaInteres", b =>
                {
                    b.Property<int>("TasaInteresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoTasa")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("TasaInteresId");

                    b.ToTable("TasaInteres");
                });

            modelBuilder.Entity("BonosCalculadora.Models.Calculadora", b =>
                {
                    b.HasOne("BonosCalculadora.Models.Capitalizacion", "Capitalizacion")
                        .WithMany("Calculadora")
                        .HasForeignKey("CapitalizacionId")
                        .HasConstraintName("FK_Calculadora_Capitalizacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonosCalculadora.Models.Cliente", null)
                        .WithMany("Calculadora")
                        .HasForeignKey("ClienteId");

                    b.HasOne("BonosCalculadora.Models.FrecuenciaPago", "FrecuenciaPago")
                        .WithMany("Calculadora")
                        .HasForeignKey("FrecuenciaPagoId")
                        .HasConstraintName("FK_Calculadora_FrecuenciaPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonosCalculadora.Models.MetodoPago", "MetodoPago")
                        .WithMany("Calculadora")
                        .HasForeignKey("MetodoPagoId")
                        .HasConstraintName("FK_Calculadora_MetodoPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonosCalculadora.Models.TasaInteres", "TasaInteres")
                        .WithMany("Calculadora")
                        .HasForeignKey("TasaInteresId")
                        .HasConstraintName("FK_Calculadora_TasaInteres")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BonosCalculadora.Models.Historial", b =>
                {
                    b.HasOne("BonosCalculadora.Models.Cliente", "Cliente")
                        .WithMany("Historial")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_Historial_Ciente");
                });
#pragma warning restore 612, 618
        }
    }
}
