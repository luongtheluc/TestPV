using System;
using System.Collections.Generic;

namespace QLHV.Models;

public partial class MonHoc
{
    public int MaMh { get; set; }

    public string? TenMh { get; set; }

    public virtual ICollection<BangDiem> BangDiems { get; set; } = new List<BangDiem>();
}
