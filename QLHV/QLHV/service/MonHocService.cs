using AutoMapper;
using QLHV.DTOs;
using QLHV.Models;

namespace QLHV.service
{
    public class MonHocService : IMonHocService
    {

        private readonly QlhvContext _context;
        private readonly IMapper _mapper;

        public MonHocService(QlhvContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<int> AddMonHocAsync(MonHocDTO model)
        {
            var addnew = _mapper.Map<MonHoc>(model);
            _context.MonHocs!.Add(addnew);
            await _context.SaveChangesAsync();
            return addnew.MaMh;
        }

        public async Task<MonHocDTO> GetMonHocByIdAsync(int id)
        {
            var getById = await _context.MonHocs!.FindAsync(id);
            return _mapper.Map<MonHocDTO>(getById);
        }
    }
}
