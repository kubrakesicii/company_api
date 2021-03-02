using System.Threading.Tasks;
using API.DTOs;

namespace API.Services.CalisanDepartmanServices
{
    public interface ICalisanDepartmanService
    {
        Task<CalisanGetirDto> EkleCalisanDepartmanı(CalisanDepartmaniEkleDto yeniDepartman);

    }
}