using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MendozaMejia_TallerBDExistente.Models;

public partial class TallerBdFacturacionContext : DbContext
{
    public TallerBdFacturacionContext()
    {
    }

    public TallerBdFacturacionContext(DbContextOptions<TallerBdFacturacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__cliente__47E34D64AD3B04C6");

            entity.ToTable("cliente");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("cliente_id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<FacturaCabecera>(entity =>
        {
            entity.HasKey(e => e.FacturaCabeceraId).HasName("PK__factura___951E0730A880DC55");

            entity.ToTable("factura_cabecera");

            entity.Property(e => e.FacturaCabeceraId)
                .ValueGeneratedNever()
                .HasColumnName("factura_cabecera_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.FacturaCabeceras)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__factura_c__clien__5070F446");
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.FacturaDetalleId).HasName("PK__factura___4BECE389BE83AB3A");

            entity.ToTable("factura_detalle");

            entity.Property(e => e.FacturaDetalleId)
                .ValueGeneratedNever()
                .HasColumnName("factura_detalle_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FacturaCabeceraId).HasColumnName("factura_cabecera_id");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.FacturaCabecera).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.FacturaCabeceraId)
                .HasConstraintName("FK__factura_d__factu__5441852A");

            entity.HasOne(d => d.Producto).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__factura_d__produ__534D60F1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__producto__FB5CEEECB4ECEFE6");

            entity.ToTable("producto");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("producto_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioCompra).HasColumnName("precioCompra");
            entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");
            entity.Property(e => e.TipoId).HasColumnName("tipo_id");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Productos)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__producto__tipo_i__4D94879B");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__tipo__6EA5A01B10EC0989");

            entity.ToTable("tipo");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("tipo_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
