using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Services.FirmaServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirmaController : ControllerBase
    {
        public IFirmaService _firmaService { get; }
        public FirmaController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<FirmaGetirDto>>> GetirTümFirmalar()
        {
            return Ok(await _firmaService.GetirTümFirmalar());
        }
    }
}