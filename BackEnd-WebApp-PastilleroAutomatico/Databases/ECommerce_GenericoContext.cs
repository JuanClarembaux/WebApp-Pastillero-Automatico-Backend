using System;
using System.Collections.Generic;
using BackEnd_WebApp_PastilleroAutomatico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd_WebApp_PastilleroAutomatico.Databases
{
    public partial class ECommerce_GenericoContext : DbContext
    {
        public ECommerce_GenericoContext()
        {
        }

        public ECommerce_GenericoContext(DbContextOptions<ECommerce_GenericoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductoDescuento> ProductoDescuentos { get; set; } = null!;
        public virtual DbSet<ProductoImagen> ProductoImagens { get; set; } = null!;
        public virtual DbSet<ProductoInventario> ProductoInventarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioDetalle> UsuarioDetalles { get; set; } = null!;
        public virtual DbSet<UsuarioDireccion> UsuarioDireccions { get; set; } = null!;
        public virtual DbSet<UsuarioTelefono> UsuarioTelefonos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8OMNJR4\\MSSQLSERVEREXP;Database=E-Commerce_Generico;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("factura");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.ActivoFactura).HasColumnName("activo_factura");

                entity.Property(e => e.FechaCreacionFactura)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_factura");

                entity.Property(e => e.FechaEliminacionFactura)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_factura");

                entity.Property(e => e.FechaModificacionFactura)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_factura");

                entity.Property(e => e.NumeroFactura)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("numero_factura");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_usuario");
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalle);

                entity.ToTable("factura_detalle");

                entity.Property(e => e.IdFacturaDetalle).HasColumnName("id_factura_detalle");

                entity.Property(e => e.CantidadProducto).HasColumnName("cantidad_producto");

                entity.Property(e => e.FechaCreacionFacturaDetalle)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_factura_detalle");

                entity.Property(e => e.FechaEliminacionFacturaDetalle)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_factura_detalle");

                entity.Property(e => e.FechaModificacionFacturaDetalle)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_factura_detalle");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("money")
                    .HasColumnName("precio_total");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_factura_detalle_factura");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_detalle_producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.ActivoProducto).HasColumnName("activo_producto");

                entity.Property(e => e.CategoriaProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria_producto");

                entity.Property(e => e.DescripcionProducto)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_producto");

                entity.Property(e => e.FechaCreacionProducto)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_producto");

                entity.Property(e => e.FechaEliminacionProducto)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_producto");

                entity.Property(e => e.FechaModificacionProducto)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_producto");

                entity.Property(e => e.MarcaProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca_producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.PrecioProducto)
                    .HasColumnType("money")
                    .HasColumnName("precio_producto");

                entity.Property(e => e.SkuProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sku_producto");
            });

            modelBuilder.Entity<ProductoDescuento>(entity =>
            {
                entity.HasKey(e => e.IdProductoDescuento);

                entity.ToTable("producto_descuento");

                entity.Property(e => e.IdProductoDescuento).HasColumnName("id_producto_descuento");

                entity.Property(e => e.ActivoProductoDescuento).HasColumnName("activo_producto_descuento");

                entity.Property(e => e.FechaCreacionProductoDescuento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_producto_descuento");

                entity.Property(e => e.FechaEliminacionProductoDescuento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_producto_descuento");

                entity.Property(e => e.FechaModificacionProductoDescuento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_producto_descuento");

                entity.Property(e => e.NombreProductoDescuento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto_descuento");

                entity.Property(e => e.PorcentajeProductoDescuento)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("porcentaje_producto_descuento");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoDescuentos)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_producto_descuento_producto");
            });

            modelBuilder.Entity<ProductoImagen>(entity =>
            {
                entity.HasKey(e => e.IdProductoImagen);

                entity.ToTable("producto_imagen");

                entity.Property(e => e.IdProductoImagen).HasColumnName("id_producto_imagen");

                entity.Property(e => e.ArchivoProductoImagen)
                    .HasColumnType("image")
                    .HasColumnName("archivo_producto_imagen");

                entity.Property(e => e.NombreProductoImagen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto_imagen");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoImagens)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_producto_imagen_producto");
            });

            modelBuilder.Entity<ProductoInventario>(entity =>
            {
                entity.HasKey(e => e.IdProductoInventario);

                entity.ToTable("producto_inventario");

                entity.Property(e => e.IdProductoInventario).HasColumnName("id_producto_inventario");

                entity.Property(e => e.ActivoProductoInventario).HasColumnName("activo_producto_inventario");

                entity.Property(e => e.CantidadProductoInventario).HasColumnName("cantidad_producto_inventario");

                entity.Property(e => e.FechaCreacionProductoInventario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_producto_inventario");

                entity.Property(e => e.FechaEliminacionProductoInventario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_producto_inventario");

                entity.Property(e => e.FechaModificacionProductoInventario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_producto_inventario");

                entity.Property(e => e.NombreProductoInventario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto_inventario");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ProductoInventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_producto_inventario_producto");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.ActivoUsuario).HasColumnName("activo_usuario");

                entity.Property(e => e.FechaCreacionUsuario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_usuario");

                entity.Property(e => e.FechaEliminacionUsuario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_usuario");

                entity.Property(e => e.FechaModificacionUsuario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_usuario");

                entity.Property(e => e.MailUsuario)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("mail_usuario");

                entity.Property(e => e.PasswordUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_usuario");

                entity.Property(e => e.RolUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol_usuario");
            });

            modelBuilder.Entity<UsuarioDetalle>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioDetalle);

                entity.ToTable("usuario_detalle");

                entity.Property(e => e.IdUsuarioDetalle).HasColumnName("id_usuario_detalle");

                entity.Property(e => e.ApellidoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido_usuario");

                entity.Property(e => e.FechaCreacionUsuarioDetalle)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_usuario_detalle");

                entity.Property(e => e.FechaEliminacionUsuarioDetalle)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_usuario_detalle");

                entity.Property(e => e.FechaModificacionUsuarioDetalle)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_usuario_detalle");

                entity.Property(e => e.FechaNacimientoUsuario)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento_usuario");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioDetalles)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_usuario_detalle_usuario");
            });

            modelBuilder.Entity<UsuarioDireccion>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioDireccion);

                entity.ToTable("usuario_direccion");

                entity.Property(e => e.IdUsuarioDireccion).HasColumnName("id_usuario_direccion");

                entity.Property(e => e.ActivoUsuarioDireccion).HasColumnName("activo_usuario_direccion");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.DireccionUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion_usuario");

                entity.Property(e => e.FechaCreacionUsuarioDireccion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_usuario_direccion");

                entity.Property(e => e.FechaEliminacionUsuarioDireccion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_usuario_direccion");

                entity.Property(e => e.FechaModificacionUsuarioDireccion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_usuario_direccion");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioDireccions)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_usuario_direccion_usuario");
            });

            modelBuilder.Entity<UsuarioTelefono>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioTelefono);

                entity.ToTable("usuario_telefono");

                entity.Property(e => e.IdUsuarioTelefono).HasColumnName("id_usuario_telefono");

                entity.Property(e => e.ActivoUsuarioTelefono).HasColumnName("activo_usuario_telefono");

                entity.Property(e => e.FechaCreacionUsuarioTelefono)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_usuario_telefono");

                entity.Property(e => e.FechaEliminacionUsuarioTelefono)
                    .HasColumnType("date")
                    .HasColumnName("fecha_eliminacion_usuario_telefono");

                entity.Property(e => e.FechaModificacionUsuarioTelefono)
                    .HasColumnType("date")
                    .HasColumnName("fecha_modificacion_usuario_telefono");

                entity.Property(e => e.TelefonoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono_usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioTelefonos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_usuario_telefono_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
