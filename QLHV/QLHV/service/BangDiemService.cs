using AutoMapper;
using QLHV.DTOs;
using QLHV.helper;
using QLHV.Models;

namespace QLHV.service
{
    public class BangDiemService : IBangDiemService
    {
        private readonly QlhvContext _context;
        private readonly IMapper _mapper;
        public BangDiemService(QlhvContext context, IMapper mapper)
        {

            this._mapper = mapper;
            this._context = context;
        }

        public async Task<int> AddBangDiemAsync(BangDiemDTO model)
        {
            BangDiem addnew = _mapper.Map<BangDiem>(model);
            _context.BangDiems!.Add(addnew);
            await _context.SaveChangesAsync();
            return addnew.MaHp;
        }

        public async Task<BangDiemDTO> GetBangDiemById(int newBangDiem)
        {
            var getById = await _context.BangDiems!.FindAsync(newBangDiem);
            return _mapper.Map<BangDiemDTO>(getById);
        }

        public List<DiemTrungBinhMon> LayDanhSachDiemTrungBinhMon(string lopHoc, int namHoc)
        {
            var danhSachDiemTrungBinhMon = (
                from hocVien in _context.HocViens
                where hocVien.Lop == lopHoc
                from bangDiem in _context.BangDiems!.Where(bd => bd.MaHv == hocVien.MaHv && bd.NamHoc == namHoc)
                from monHoc in _context.MonHocs!.Where(mh => mh.MaMh == bangDiem.MaMh)
                group new { hocVien, bangDiem, monHoc } by new { hocVien.MaHv, hocVien.TenHv, monHoc.TenMh } into g
                select new
                {
                    g.Key.MaHv,
                    g.Key.TenHv,
                    g.Key.TenMh,
                    DiemTBMon = g.Sum(x => x.bangDiem.Diem * x.bangDiem.HeSo) / g.Sum(x => x.bangDiem.HeSo)
                }
            ).ToList();
            var listDiemTrungBinhMonhoc = new List<DiemTrungBinhMon>();
            foreach (var diemTrungBinhMon in danhSachDiemTrungBinhMon)
            {
                var diemTrungBinhMonhoc = new DiemTrungBinhMon()
                {
                    MaHv = diemTrungBinhMon.MaHv,
                    TenMh = diemTrungBinhMon.TenMh,
                    TenHv = diemTrungBinhMon.TenHv,
                    DiemTBMon = diemTrungBinhMon.DiemTBMon

                };
                listDiemTrungBinhMonhoc.Add(diemTrungBinhMonhoc);
            }

            // Xử lý và trả về kết quả tùy theo yêu cầu của bạn
            return listDiemTrungBinhMonhoc;
        }

    }
}
