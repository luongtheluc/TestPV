using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLHV.DTOs;
using QLHV.helper;
using QLHV.Models;

namespace QLHV.service
{
    public class HocVienService : IHocVienService
    {
        private readonly QlhvContext _context;
        private readonly IMapper _mapper;
        
        public HocVienService(QlhvContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddHocVienAsync(HocVienDTO model)
        {
            var addnew = _mapper.Map<HocVien>(model);
            _context.HocViens!.Add(addnew);
            await _context.SaveChangesAsync();
            return addnew.MaHv;
        }

        public async Task<HocVienDTO> GetHocVienByIdAsync(int id)
        {
            var getById = await _context.HocViens!.FindAsync(id);
            return _mapper.Map<HocVienDTO>(getById);
        }

        
    }
}
