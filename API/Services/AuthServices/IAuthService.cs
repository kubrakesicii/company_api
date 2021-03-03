using System.Threading.Tasks;
using API.ApiResponse;
using API.Entities;

namespace API.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> KayıtOl(Kullanici kullanici,string sifre);
        Task<ServiceResponse<string>> GirisYap(string kullaniciAdi,string sifre);
        Task<bool> KullaniciMevcut(string kullaniciAdi);
    }
}