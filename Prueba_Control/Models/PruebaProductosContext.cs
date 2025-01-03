using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Control.Models;

public partial class PruebaProductosContext : DbContext
{
    public PruebaProductosContext()
    {
    }

    public PruebaProductosContext(DbContextOptions<PruebaProductosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagenesproducto> Imagenesproductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("server=localhost; database=PruebaProductos; integrated security=true; TrustServerCertificate=Yes");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagenesproducto>(entity =>
        {
            entity.HasKey(e => e.IdImagenesProductos).HasName("PK__Imagenes__99684703A2996572");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.ImagenExt)
                .HasColumnType("image")
                .HasColumnName("ImagenEXT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Imagenesproductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Imagenesp__IdPro__46E78A0C");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__0988921048265E81");

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHACREACION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRECIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
