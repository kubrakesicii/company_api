using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services.DepartmanServices
{
    public class DepartmanService : IDepartmanService
    {
        private DatabaseContext _context { get; }
        public IMapper _mapper { get; }
        public DepartmanService(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<DepartmanGetirDto>> GetirTümDepartmanlar()
        {
            var departmanlar = await _context.Departmanlar.ToListAsync();

            return _mapper.Map<List<Departman>,List<DepartmanGetirDto>>(departmanlar);
        }


    }
}