using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponse;
using API.DTOs;
using API.DTOs.Calisan;
using Core.Entities;

namespace API.Services.CalisanServices
{
    public interface ICalisanService
    {
         Task<ServiceResponse<List<CalisanGetirDto>>> SilCalisan(int id);
         Task<ServiceResponse<CalisanGetirDto>> EkleCalisan(CalisanEkleDto yeniCalisan);
         Task<ServiceResponse<CalisanGetirDto>> GuncelleFirma(CalisanGuncelleDto calisan);
         Task<ServiceResponse<List<CalisanGetirDto>>> GetirTümCalisanlar();
    }
}