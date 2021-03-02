using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Calisan;
using Core.Entities;

namespace API.Services.CalisanServices
{
    public interface ICalisanService
    {
         Task<List<CalisanGetirDto>> SilCalisan(int id);
         Task<CalisanGetirDto> EkleCalisan(CalisanEkleDto yeniCalisan);
         Task<CalisanGetirDto> GuncelleFirma(CalisanGuncelleDto calisan);
         Task<List<CalisanGetirDto>> GetirTümCalisanlar();
    }
}