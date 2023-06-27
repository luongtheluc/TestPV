using QLHV.DTOs;

namespace QLHV.service
{
    public interface IHocVienService
    {
        public Task<int> AddHocVienAsync(HocVienDTO model);
        public Task<HocVienDTO> GetHocVienByIdAsync(int id);
    }
}
