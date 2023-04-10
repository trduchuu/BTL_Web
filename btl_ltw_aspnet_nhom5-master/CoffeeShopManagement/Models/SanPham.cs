using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class SanPham
{
    public string IdSanPham { get; set; } = null!;

    public string? TenSanPham { get; set; }

    public decimal? GiaTien { get; set; }

    public string IdMenu { get; set; } = null!;

    public string? Images { get; set; }

    public string? IdTopping { get; set; }

    public string? IdSize { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; } = new List<ChiTietDonHang>();

    public virtual Menu IdMenuNavigation { get; set; } = null!;

    public virtual Size? IdSizeNavigation { get; set; }

    public virtual Topping? IdToppingNavigation { get; set; }
}
