using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class Menu
{
    public string IdMenu { get; set; } = null!;

    public string? TenMenu { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
