using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Services.CalisanServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalisanController : ControllerBase
    {
        private ICalisanService _calisanService { get; }

        public CalisanController(ICalisanService calisanService)
        {
            _calisanService = calisanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CalisanGetirDto>>> GetirTümCalisanlar()
        {
            var calisanlar = await _calisanService.GetirTümCalisanlar();
            return Ok(calisanlar);
        }

        [HttpPost]
        public async Task<ActionResult<CalisanGetirDto>> EkleCalisan(CalisanEkleDto yeniCalisan)
        {
            return Ok(await _calisanService.EkleCalisan(yeniCalisan));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CalisanGetirDto>>> SilCalisan(int id)
        {
            return Ok(await _calisanService.SilCalisan(id));
        }

    }

}