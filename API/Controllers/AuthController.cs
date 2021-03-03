using System.Threading.Tasks;
using API.ApiResponse;
using API.DTOs.Kullanici;
using API.Entities;
using API.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService { get; }
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("kayitol")]
        public async Task<ActionResult> KayitOl(KayitOlDto kullanici){
            ServiceResponse<string> response = await _authService.KayıtOl(
                new Kullanici {KullaniciAdi = kullanici.KullaniciAdi},kullanici.Sifre
            );

            if(!response.Basari){
                return BadRequest(response);
            }
            else {
                return Ok(response);
            }
        }

        [HttpPost("girisyap")]
        public async Task<IActionResult> Login(GirisYapDto kullanici){
            ServiceResponse<string> response = await _authService.GirisYap(kullanici.KullaniciAdi,kullanici.Sifre);

            if(!response.Basari){
                return BadRequest(response);
            }
            else {
                return Ok(response);
            }
        }
    }
}