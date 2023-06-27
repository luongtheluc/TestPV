
SELECT TOP 1 HocVien.MaHV, HocVien.TenHV, 
    (SELECT SUM(Diem * HeSo) / SUM(HeSo) 
     FROM BangDiem 
     WHERE BangDiem.MaHV = HocVien.MaHV AND BangDiem.NamHoc = 2023) AS DiemTBNH
FROM HocVien
WHERE HocVien.Lop = '7A1'
ORDER BY DiemTBNH DESC
