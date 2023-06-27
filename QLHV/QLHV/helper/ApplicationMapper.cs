using AutoMapper;
using QLHV.DTOs;
using QLHV.Models;
using System.Data;
using System.Reflection.Metadata;

namespace QLHV.helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<HocVien, HocVienDTO>().ReverseMap();
            CreateMap<BangDiem, BangDiemDTO>().ReverseMap();
            CreateMap<MonHoc, MonHocDTO>().ReverseMap();
            

        }
    }
}
