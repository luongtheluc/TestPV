using System;
using System.Collections.Generic;

namespace QLHV.Models;

public partial class HocVien
{
    public int MaHv { get; set; }

    public string? TenHv { get; set; }

    public string? Lop { get; set; }

    public virtual ICollection<BangDiem> BangDiems { get; set; } = new List<BangDiem>();
}
