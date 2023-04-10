using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class Size
{
    public string IdSize { get; set; } = null!;

    public string? TenSize { get; set; }

    public decimal? GiaSize { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
