using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace modelobd.models
{
    public partial class modelobdContext : DbContext
    {
        public modelobdContext()
        {
        }

        public modelobdContext(DbContextOptions<modelobdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__E005FBFF7F1E9D25");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Cliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PK__DetalleP__B3E0CED320D921A9");

                entity.ToTable("DetallePedido");

                entity.Property(e => e.IdDetalle)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Detalle");

                entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__DetallePe__ID_Pe__5070F446");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetallePe__ID_Pr__5165187F");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__E9D586A8B856997E");

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Factura");

                entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__Factura__ID_Pedi__5441852A");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__FD7680701EA5ED16");

                entity.ToTable("Pedido");

                entity.Property(e => e.IdPedido)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pedido");

                entity.Property(e => e.FechaPedido).HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Pedido__ID_Clien__4BAC3F29");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__9B4120E243E99908");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Producto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
