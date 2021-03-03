using System.Threading.Tasks;
using API.DTOs;
using API.Services.CalisanDepartmanServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CalisanDepartmanController : ControllerBase
    {
        private ICalisanDepartmanService _calisanDeptService { get; }
        public CalisanDepartmanController(ICalisanDepartmanService calisanDepartmanService)
        {
            _calisanDeptService = calisanDepartmanService;
        }
        

        [HttpPost]
        public async Task<ActionResult<CalisanGetirDto>> EkleCalisanDepartman(CalisanDepartmaniEkleDto yeniDept)
        {
            return Ok(await _calisanDeptService.EkleCalisanDepartmanı(yeniDept));
        }
    }
}