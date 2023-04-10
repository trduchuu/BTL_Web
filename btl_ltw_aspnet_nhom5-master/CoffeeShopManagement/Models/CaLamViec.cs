using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class CaLamViec
{
    public string IdCaLamViec { get; set; } = null!;

    public string? TenCaLamViec { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();
}
