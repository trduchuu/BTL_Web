using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class DonHang
{
    public int IdDon { get; set; }

    public DateTime? NgayDat { get; set; }

    public int? TinhTrang { get; set; }

    public int? IdNguoiDung { get; set; }

    public int ThanhToan { get; set; }

    public string DiaChiNhanHang { get; set; } = null!;

    public decimal TongTien { get; set; }

    public string IdNhanVien { get; set; } = null!;

    public string IdBan { get; set; } = null!;

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; } = new List<ChiTietDonHang>();

    public virtual Ban IdBanNavigation { get; set; } = null!;

    public virtual NguoiDung? IdNguoiDungNavigation { get; set; }

    public virtual NhanVien IdNhanVienNavigation { get; set; } = null!;
}
