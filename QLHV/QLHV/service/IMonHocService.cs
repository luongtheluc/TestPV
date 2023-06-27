using QLHV.DTOs;

namespace QLHV.service
{
    public interface IMonHocService
    {
        public Task<int> AddMonHocAsync(MonHocDTO model); 
        public Task<MonHocDTO> GetMonHocByIdAsync(int id);

    }
}
