using System;
using System.Collections.Generic;

namespace CoffeeShopManagement.Models;

public partial class PhanQuyen
{
    public int IdQuyen { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<NguoiDung> NguoiDungs { get; } = new List<NguoiDung>();
}
