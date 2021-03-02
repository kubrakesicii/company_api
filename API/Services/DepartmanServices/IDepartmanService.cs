using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using Core.Entities;

namespace API.Services.DepartmanServices
{
    public interface IDepartmanService
    {
        Task<List<DepartmanGetirDto>> GetirTümDepartmanlar();
    }
}