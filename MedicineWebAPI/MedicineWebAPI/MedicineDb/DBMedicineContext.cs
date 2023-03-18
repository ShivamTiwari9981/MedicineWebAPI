using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicineWebAPI.MedicineDb
{
    public partial class DBMedicineContext : DbContext
    {
        public DBMedicineContext()
        {
        }

        public DBMedicineContext(DbContextOptions<DBMedicineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCart> TblCarts { get; set; } = null!;
        public virtual DbSet<TblMedicine> TblMedicines { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblOrderItem> TblOrderItems { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-46NSJF0;Database=db_medicine;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__tbl_Cart__51BCD7B7DD85979D");

                entity.ToTable("tbl_Cart");

                entity.Property(e => e.CrtdOn).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdtOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMedicine>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("PK__tbl_medi__4F2128900924663E");

                entity.ToTable("tbl_medicines");

                entity.HasIndex(e => e.Manufecturer, "UQ__tbl_medi__5A221B6646059204")
                    .IsUnique();

                entity.Property(e => e.CrtdOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasColumnType("datetime");

                entity.Property(e => e.Manufecturer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdtOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tbl_Orde__C3905BCF3E2AE12C");

                entity.ToTable("tbl_Orders");

                entity.Property(e => e.CrtdOn).HasColumnType("datetime");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdtOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblOrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PK__tbl_Orde__57ED068155955FC2");

                entity.ToTable("tbl_Order_Item");

                entity.Property(e => e.CrtdOn).HasColumnType("datetime");

                entity.Property(e => e.Discunt).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdtOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_user__1788CC4C450E06CC");

                entity.ToTable("tbl_users");

                entity.HasIndex(e => e.LastName, "UQ__tbl_user__7449F3991AE1090E")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__tbl_user__A9D10534839D21AC")
                    .IsUnique();

                entity.Property(e => e.CrtdOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fund).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UpdtOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
