using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Departman;
using Core.Entities;

namespace API.Services.DepartmanServices
{
    public interface IDepartmanService
    {
        Task<List<DepartmanGetirDto>> GetirTümDepartmanlar();
       // Task<DepartmanaGöreCalisanGetirDto> GetirDepartmanaGöreCalisan(int deptId);
        Task<List<DepartmanaGöreCalisanGetirDto>> GetirDepartmanaGöreCalisanlar();

    }
}