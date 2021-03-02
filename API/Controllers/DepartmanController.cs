using System.Threading.Tasks;
using API.DTOs;
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
    }
}