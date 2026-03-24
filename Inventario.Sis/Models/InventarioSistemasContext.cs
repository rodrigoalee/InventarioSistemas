using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Inventario.Sis.Models
{
    public partial class InventarioSistemasContext : DbContext
    {
        public InventarioSistemasContext()
        {
        }

        public InventarioSistemasContext(DbContextOptions<InventarioSistemasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignacion> Asignacions { get; set; } = null!;
        public virtual DbSet<Computadora> Computadoras { get; set; } = null!;
        public virtual DbSet<Impresora> Impresoras { get; set; } = null!;
        public virtual DbSet<Insumo> Insumos { get; set; } = null!;
        public virtual DbSet<Monitore> Monitores { get; set; } = null!;
        public virtual DbSet<Periferico> Perifericos { get; set; } = null!;
        public virtual DbSet<Up> Ups { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NE3TJE2\\SQLEXPRESS;Database=InventarioSistemas;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(e => e.IdAsignacion)
                    .HasName("PK__asignaci__A7235DFF99DA490B");

                entity.ToTable("asignacion");

                entity.Property(e => e.IdUps).HasColumnName("IdUPS");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.HasOne(d => d.IdCompuNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdCompu)
                    .HasConstraintName("FK__asignacio__IdCom__59FA5E80");

                entity.HasOne(d => d.IdImpresoraNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdImpresora)
                    .HasConstraintName("FK__asignacio__IdImp__5BE2A6F2");

                entity.HasOne(d => d.IdMonitorNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdMonitor)
                    .HasConstraintName("FK__asignacio__IdMon__5AEE82B9");

                entity.HasOne(d => d.IdUpsNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdUps)
                    .HasConstraintName("FK__asignacio__IdUPS__5DCAEF64");

                entity.HasOne(d => d.IdperifericoNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.Idperiferico)
                    .HasConstraintName("FK__asignacio__Idper__5CD6CB2B");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asignacio__idusu__59063A47");
            });

            modelBuilder.Entity<Computadora>(entity =>
            {
                entity.HasKey(e => e.IdCompu)
                    .HasName("PK__Computad__D65B609C77D138B8");

                entity.Property(e => e.Almacenamiento).HasMaxLength(70);

                entity.Property(e => e.Grafica).HasMaxLength(70);

                entity.Property(e => e.NombreEquipo).HasMaxLength(70);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.Placa).HasMaxLength(70);

                entity.Property(e => e.Procesador).HasMaxLength(70);

                entity.Property(e => e.Ram)
                    .HasMaxLength(70)
                    .HasColumnName("RAM");
            });

            modelBuilder.Entity<Impresora>(entity =>
            {
                entity.HasKey(e => e.IdImpresora)
                    .HasName("PK__Impresor__627CBB0CBD25C677");

                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.Serie).HasMaxLength(100);

                entity.Property(e => e.Tipotinta).HasMaxLength(100);
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.HasKey(e => e.IdInsumo)
                    .HasName("PK__Insumos__F378A2AF3EECD1C7");

                entity.Property(e => e.NombreInsumo).HasMaxLength(100);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.StockMinimo).HasDefaultValueSql("((2))");

                entity.Property(e => e.Ultimacarga).HasColumnType("datetime");

                entity.Property(e => e.UnidadMedida).HasMaxLength(50);
            });

            modelBuilder.Entity<Monitore>(entity =>
            {
                entity.HasKey(e => e.IdMonitor)
                    .HasName("PK__Monitore__634F306C03574CB2");

                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Observacion).HasMaxLength(500);

                entity.Property(e => e.Serie).HasMaxLength(100);
            });

            modelBuilder.Entity<Periferico>(entity =>
            {
                entity.HasKey(e => e.Idperiferico)
                    .HasName("PK__Periferi__E8F728D7C74D05FE");

                entity.Property(e => e.Marca).HasMaxLength(70);

                entity.Property(e => e.Observacion).HasMaxLength(70);

                entity.Property(e => e.Serie).HasMaxLength(70);

                entity.Property(e => e.Tipo).HasMaxLength(70);
            });

            modelBuilder.Entity<Up>(entity =>
            {
                entity.HasKey(e => e.IdUps)
                    .HasName("PK__UPS__2C9E6B21CD86F03B");

                entity.ToTable("UPS");

                entity.Property(e => e.IdUps).HasColumnName("IdUPS");

                entity.Property(e => e.Marca).HasMaxLength(70);

                entity.Property(e => e.Observacion).HasMaxLength(70);

                entity.Property(e => e.Serie).HasMaxLength(70);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuarios__080A97431502879D");

                entity.ToTable("usuarios");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Area).HasMaxLength(70);

                entity.Property(e => e.Nombre).HasMaxLength(70);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
