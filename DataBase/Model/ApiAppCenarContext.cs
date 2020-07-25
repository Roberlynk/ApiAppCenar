using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase.Model
{
    public partial class ApiAppCenarContext : DbContext
    {
        public ApiAppCenarContext()
        {
        }

        public ApiAppCenarContext(DbContextOptions<ApiAppCenarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredientes> Ingredientes { get; set; }
        public virtual DbSet<Mesas> Mesas { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<OrdenesPlatos> OrdenesPlatos { get; set; }
        public virtual DbSet<Platos> Platos { get; set; }
        public virtual DbSet<PlatosIngredientes> PlatosIngredientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-N9TB03CS;Database=ApiAppCenar;persist security info=True;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredientes>(entity =>
            {
                entity.HasKey(e => e.IdIngredientes)
                    .HasName("PK__Ingredie__EB4634CCB2D327FB");

                entity.Property(e => e.IdIngredientes).HasColumnName("idIngredientes");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mesas>(entity =>
            {
                entity.HasKey(e => e.IdMesas)
                    .HasName("PK__Mesas__2543EA4DA9E8256A");

                entity.Property(e => e.IdMesas).HasColumnName("idMesas");

                entity.Property(e => e.CantidadP).HasColumnName("cantidadP");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.HasKey(e => e.IdOrdenes)
                    .HasName("PK__Ordenes__25A13BE549CF41F5");

                entity.Property(e => e.IdOrdenes).HasColumnName("idOrdenes");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdMesas).HasColumnName("idMesas");

                entity.Property(e => e.SubTotal)
                    .HasColumnName("subTotal")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdMesasNavigation)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdMesas)
                    .HasConstraintName("FK_Mesas_Ordenes");
            });

            modelBuilder.Entity<OrdenesPlatos>(entity =>
            {
                entity.HasKey(e => e.IdOrdenesPlatos)
                    .HasName("PK__OrdenesP__BC8AFEE55B3AEABB");

                entity.Property(e => e.IdOrdenes).HasColumnName("IdOrdenesPlatos");

                entity.Property(e => e.IdOrdenes).HasColumnName("idOrdenes");

                entity.Property(e => e.IdPlatos).HasColumnName("idPlatos");

                entity.HasOne(d => d.IdOrdenesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrdenes)
                    .HasConstraintName("FK_Ordenes_Platos");

                entity.HasOne(d => d.IdPlatosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPlatos)
                    .HasConstraintName("FK_Platos_Ordenes");
            });

            modelBuilder.Entity<Platos>(entity =>
            {
                entity.HasKey(e => e.IdPlatos)
                    .HasName("PK__Platos__35C519687BA2EECF");

                entity.Property(e => e.IdPlatos).HasColumnName("idPlatos");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Limite).HasColumnName("limite");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<PlatosIngredientes>(entity =>
            {
                entity.HasKey(e => e.IdPlatosIngredientes)
                    .HasName("PK__PlatosIn__0F2E53043B286E76");
                

                entity.Property(e => e.IdIngredientes).HasColumnName("idIngredientes");

                entity.Property(e => e.IdPlatos).HasColumnName("idPlatos");

                entity.HasOne(d => d.IdIngredientesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdIngredientes)
                    .HasConstraintName("FK_Ingredientes_Platos");

                entity.HasOne(d => d.IdPlatosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPlatos)
                    .HasConstraintName("FK_Platos_Ingredientes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
