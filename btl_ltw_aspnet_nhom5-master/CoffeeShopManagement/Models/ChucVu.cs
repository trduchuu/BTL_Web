using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class ChucVu
{
    public string IdChucVu { get; set; } = null!;

    public string? TenChucVu { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();
}
