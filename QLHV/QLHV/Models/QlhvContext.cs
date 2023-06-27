using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLHV.Models;

public partial class QlhvContext : DbContext
{
    public QlhvContext()
    {
    }

    public QlhvContext(DbContextOptions<QlhvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangDiem>? BangDiems { get; set; }

    public virtual DbSet<HocVien>? HocViens { get; set; }

    public virtual DbSet<MonHoc>? MonHocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=THELUC;Initial Catalog=QLHV;Integrated Security=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangDiem>(entity =>
        {
            entity.HasKey(e => e.MaHp);

            entity.ToTable("BangDiem");

            entity.Property(e => e.MaHp).HasColumnName("MaHP");
            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.MaMh).HasColumnName("MaMH");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.BangDiems)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK_BangDiem_HocVien");

            entity.HasOne(d => d.MaMhNavigation).WithMany(p => p.BangDiems)
                .HasForeignKey(d => d.MaMh)
                .HasConstraintName("FK_BangDiem_MonHoc");
        });

        modelBuilder.Entity<HocVien>(entity =>
        {
            entity.HasKey(e => e.MaHv);

            entity.ToTable("HocVien");

            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.Lop)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.TenHv)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TenHV");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMh);

            entity.ToTable("MonHoc");

            entity.Property(e => e.MaMh).HasColumnName("MaMH");
            entity.Property(e => e.TenMh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TenMH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
