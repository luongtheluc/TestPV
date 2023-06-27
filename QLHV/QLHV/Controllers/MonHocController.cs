using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHV.DTOs;
using QLHV.helper;
using QLHV.Models;
using QLHV.service;

namespace QLHV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocService _monhoc;
        private const string NAMECONTROLLER = "bang diem";
        public MonHocController(IMonHocService monhoc)
        {
            _monhoc = monhoc;
        }

        [HttpPost]
        public async Task<IActionResult> AddMonHoc(MonHocDTO model)
        {
            try
            {
                var id = await _monhoc.AddMonHocAsync(model);
                var monhoc = await _monhoc.GetMonHocByIdAsync(id);
                if (monhoc != null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Get " + NAMECONTROLLER + " success",
                        Data = monhoc
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
