using System;
using System.Collections.Generic;

namespace QLHV.Models;

public partial class BangDiem
{
    public int MaHp { get; set; }

    public int? MaHv { get; set; }

    public int? MaMh { get; set; }

    public double? Diem { get; set; }

    public int? HeSo { get; set; }

    public int? NamHoc { get; set; }

    public virtual HocVien? MaHvNavigation { get; set; }

    public virtual MonHoc? MaMhNavigation { get; set; }
}
