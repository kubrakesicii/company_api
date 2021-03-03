using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Departman;
using API.Services.DepartmanServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmanController : ControllerBase
    {
        private IDepartmanService _deptService { get; }
        public DepartmanController(IDepartmanService deptService)
        {
            _deptService = deptService;
        }


        [HttpGet]
        public async Task<ActionResult<DepartmanGetirDto>> GetirTümDepartmanlar()
        {
            return Ok(await _deptService.GetirTümDepartmanlar());
        }


        [HttpGet("calisanlar")]
        public async Task<ActionResult<List<DepartmanaGöreCalisanGetirDto>>> GetirDepartmanaGöreCalisanlar()
        {
            return Ok(await _deptService.GetirDepartmanaGöreCalisanlar());
        }
    }
}