using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV.DTOs;
using QLHV.helper;
using QLHV.service;

namespace QLHV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly IHocVienService _hocVien;
        private const string NAMECONTROLLER = "Hoc vien";
        public HocVienController(IHocVienService hocVien)
        {
            _hocVien = hocVien;
        }

        [HttpPost]
        public async Task<IActionResult> AddHocVien(HocVienDTO model)
        {
            try
            {
                var newAirportId = await _hocVien.AddHocVienAsync(model);
                var Airport = await _hocVien.GetHocVienByIdAsync(newAirportId);
                if (Airport != null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Get " + NAMECONTROLLER + " success",
                        Data = Airport
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
