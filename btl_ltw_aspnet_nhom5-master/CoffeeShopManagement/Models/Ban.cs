using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class Ban
{
    public string IdBan { get; set; } = null!;

    public string? TenBan { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();
}
