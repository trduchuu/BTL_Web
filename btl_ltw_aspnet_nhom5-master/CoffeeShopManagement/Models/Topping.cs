using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class Topping
{
    public string IdTopping { get; set; } = null!;

    public string? TenTopping { get; set; }

    public decimal? GiaTopping { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
