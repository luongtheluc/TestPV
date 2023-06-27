using QLHV.DTOs;
using QLHV.helper;

namespace QLHV.service
{
    public interface IBangDiemService
    {
        public Task<int> AddBangDiemAsync(BangDiemDTO model);
        Task<BangDiemDTO> GetBangDiemById(int newBangDiem);
        public List<DiemTrungBinhMon> LayDanhSachDiemTrungBinhMon(string lopHoc, int namHoc);
        
        }
}
