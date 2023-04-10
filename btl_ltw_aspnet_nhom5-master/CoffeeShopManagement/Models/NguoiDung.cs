using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class NguoiDung
{
    public int IdNguoiDung { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? MatKhau { get; set; }

    public int IdQuyen { get; set; }

    public string? DiaChi { get; set; }

    public string? AnhDaiDien { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();

    public virtual PhanQuyen IdQuyenNavigation { get; set; } = null!;
}
