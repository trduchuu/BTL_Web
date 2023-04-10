using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopManagement.Models;

public partial class CoffeeShopManagementContext : DbContext
{
    public CoffeeShopManagementContext()
    {
    }

    public CoffeeShopManagementContext(DbContextOptions<CoffeeShopManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<CaLamViec> CaLamViecs { get; set; }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Topping> Toppings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-L5L4T2C\\SQLEXPRESS01;Initial Catalog=CoffeeShopManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.IdBan);

            entity.ToTable("Ban");

            entity.Property(e => e.IdBan)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idBan");
            entity.Property(e => e.TenBan).HasMaxLength(25);
        });

        modelBuilder.Entity<CaLamViec>(entity =>
        {
            entity.HasKey(e => e.IdCaLamViec);

            entity.ToTable("CaLamViec");

            entity.Property(e => e.IdCaLamViec)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idCaLamViec");
            entity.Property(e => e.TenCaLamViec).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => new { e.IdSanPham, e.IdDon }).HasName("PK_ChiTietDonHang_1");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.IdSanPham)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idSanPham");
            entity.Property(e => e.IdDon).HasColumnName("idDon");
            entity.Property(e => e.DonGia)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SoLuong)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ThanhTien)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdDonNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.IdDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonHang_DonHang");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonHang_SanPham");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.IdChucVu);

            entity.ToTable("ChucVu");

            entity.Property(e => e.IdChucVu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idChucVu");
            entity.Property(e => e.TenChucVu).HasMaxLength(50);
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.IdDon);

            entity.ToTable("DonHang");

            entity.Property(e => e.IdDon)
                .ValueGeneratedNever()
                .HasColumnName("idDon");
            entity.Property(e => e.DiaChiNhanHang)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.IdBan)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idBan");
            entity.Property(e => e.IdNguoiDung).HasColumnName("idNguoiDung");
            entity.Property(e => e.IdNhanVien)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idNhanVien");
            entity.Property(e => e.NgayDat).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdBanNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.IdBan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonHang_Ban");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.IdNguoiDung)
                .HasConstraintName("FK_DonHang_NguoiDung");

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.IdNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonHang_NhanVien");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idMenu");
            entity.Property(e => e.TenMenu)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.IdNguoiDung);

            entity.ToTable("NguoiDung");

            entity.Property(e => e.IdNguoiDung)
                .ValueGeneratedNever()
                .HasColumnName("idNguoiDung");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.IdQuyen).HasColumnName("idQuyen");
            entity.Property(e => e.MatKhau).HasMaxLength(50);

            entity.HasOne(d => d.IdQuyenNavigation).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.IdQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiDung_PhanQuyen");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.IdNhanVien)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idNhanVien");
            entity.Property(e => e.DiaChi).HasMaxLength(1);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.IdCaLamViec)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idCaLamViec");
            entity.Property(e => e.IdChucVu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idChucVu");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdCaLamViecNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdCaLamViec)
                .HasConstraintName("FK_NhanVien_CaLamViec");

            entity.HasOne(d => d.IdChucVuNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdChucVu)
                .HasConstraintName("FK_NhanVien_ChucVu");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.IdQuyen);

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.IdQuyen)
                .ValueGeneratedNever()
                .HasColumnName("idQuyen");
            entity.Property(e => e.TenQuyen)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdSanPham);

            entity.ToTable("SanPham");

            entity.HasIndex(e => e.IdSanPham, "IX_SanPham");

            entity.Property(e => e.IdSanPham)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idSanPham");
            entity.Property(e => e.GiaTien).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IdMenu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idMenu");
            entity.Property(e => e.IdSize)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idSize");
            entity.Property(e => e.IdTopping)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idTopping");
            entity.Property(e => e.Images).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("ntext");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_Menu");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdSize)
                .HasConstraintName("FK_SanPham_Size");

            entity.HasOne(d => d.IdToppingNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdTopping)
                .HasConstraintName("FK_SanPham_Topping");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.IdSize);

            entity.ToTable("Size");

            entity.Property(e => e.IdSize)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idSize");
            entity.Property(e => e.GiaSize).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenSize).HasMaxLength(50);
        });

        modelBuilder.Entity<Topping>(entity =>
        {
            entity.HasKey(e => e.IdTopping);

            entity.ToTable("Topping");

            entity.Property(e => e.IdTopping)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("idTopping");
            entity.Property(e => e.GiaTopping).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TenTopping).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
