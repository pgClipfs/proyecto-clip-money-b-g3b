using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BilleteraClipMoney;User=GastonFavre;Password=clip123;Trusted_Connection=True;");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
