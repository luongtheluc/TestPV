SELECT HocVien.MaHV, HocVien.TenHV, MonHoc.TenMH,
	(SUM(BangDiem.Diem * BangDiem.HeSo) / SUM(BangDiem.HeSo)) as DiemTBMon
FROM HocVien, BangDiem, MonHoc
WHERE HocVien.MaHV = BangDiem.MaHV
  AND BangDiem.MaMH = MonHoc.MaMH
  AND BangDiem.NamHoc = 2023
GROUP BY HocVien.MaHV, HocVien.TenHV, MonHoc.TenMH
Having (SUM(BangDiem.Diem * BangDiem.HeSo) / SUM(BangDiem.HeSo)) < 5.0