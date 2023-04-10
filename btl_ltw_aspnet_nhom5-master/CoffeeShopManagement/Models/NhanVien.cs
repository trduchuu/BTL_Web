using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class NhanVien
{
    public string IdNhanVien { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? IdCaLamViec { get; set; }

    public string? IdChucVu { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();

    public virtual CaLamViec? IdCaLamViecNavigation { get; set; }

    public virtual ChucVu? IdChucVuNavigation { get; set; }
}
