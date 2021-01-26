using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClipMoney.Persistence.EntityFramework.entities;

namespace ClipMoney.Persistence.EntityFramework.context
{
    public partial class BilleteraClipMoneyContext : DbContext
    {
        public BilleteraClipMoneyContext()
        {
        }

        public BilleteraClipMoneyContext(DbContextOptions<BilleteraClipMoneyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<giro_descubierto> giro_descubierto { get; set; }
        public virtual DbSet<transaction> transaction { get; set; }
        public virtual DbSet<transaction_type> transaction_type { get; set; }
        public virtual DbSet<wallet> wallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BilleteraClipMoney;User=GastonFavre;Password=jagger33;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.foto_dorso)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.foto_frente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.hashed_password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.nombre_usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.salt)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<giro_descubierto>(entity =>
            {
                entity.HasOne(d => d.id_userNavigation)
                    .WithMany(p => p.giro_descubierto)
                    .HasForeignKey(d => d.id_user)
                    .HasConstraintName("FK_giro_descubierto_Usuarios");
            });

            modelBuilder.Entity<transaction>(entity =>
            {
                entity.HasOne(d => d.id_userNavigation)
                    .WithMany(p => p.transaction)
                    .HasForeignKey(d => d.id_user)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_id_user");

                entity.HasOne(d => d.transaction_typeNavigation)
                    .WithMany(p => p.transaction)
                    .HasForeignKey(d => d.transaction_type)
                    .HasConstraintName("FK_transaction_transaction_type");
            });

            modelBuilder.Entity<transaction_type>(entity =>
            {
                entity.Property(e => e.description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<wallet>(entity =>
            {
                entity.HasOne(d => d.id_userNavigation)
                    .WithMany(p => p.wallet)
                    .HasForeignKey(d => d.id_user)
                    .HasConstraintName("FK_wallet_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
