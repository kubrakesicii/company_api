using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Services.FirmaServices
{
    public interface IFirmaService
    {
        Task<List<FirmaGetirDto>> GetirTümFirmalar();
        Task<FirmaGetirDto> GetirFirma(int id);

    }
}