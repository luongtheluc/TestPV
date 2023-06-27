using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV.DTOs;
using QLHV.helper;
using QLHV.service;

namespace QLHV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangDiemController : ControllerBase
    {
        private readonly IBangDiemService _bangdiem;
        private const string NAMECONTROLLER = "bang diem";
        public BangDiemController(IBangDiemService bangdiem)
        {
            _bangdiem = bangdiem;
        }

        [HttpGet("DanhSachDiemTrungBinhMon")]
        public IActionResult GetDanhSachDiemTrungBinhMon(string lop, int year)
        {
            var bangdiem = _bangdiem.LayDanhSachDiemTrungBinhMon(lop, year);
            return Ok(bangdiem);
        }

        [HttpPost]
        public async Task<IActionResult> AddBangDiem(BangDiemDTO model)
        {
            try
            {
                var newBangDiem = await _bangdiem.AddBangDiemAsync(model);
                var bangdiem = await _bangdiem.GetBangDiemById(newBangDiem);
                if (bangdiem != null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Get " + NAMECONTROLLER + " success",
                        Data = bangdiem
                    });
                }
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Get " + NAMECONTROLLER + " fail",
                    Data = null
                });
            }
            catch (System.Exception e)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = e.Message,
                    Data = null
                });
            }
        }



    }
}
