using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class ChiTietDonHang
{
    public string IdSanPham { get; set; } = null!;

    public int IdDon { get; set; }

    public string? SoLuong { get; set; }

    public string? DonGia { get; set; }

    public string? ThanhTien { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public virtual DonHang IdDonNavigation { get; set; } = null!;

    public virtual SanPham IdSanPhamNavigation { get; set; } = null!;
}
