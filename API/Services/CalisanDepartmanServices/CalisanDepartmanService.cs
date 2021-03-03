using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services.CalisanDepartmanServices
{
    public class CalisanDepartmanService : ICalisanDepartmanService
    {
        private DatabaseContext _context { get; }
        public IMapper _mapper { get; }

        public CalisanDepartmanService(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CalisanGetirDto> EkleCalisanDepartmanı(CalisanDepartmaniEkleDto yeniCalisanDept)
        {
            Calisan calisan = await _context.Calisanlar
                .Include(c => c.Firma)
                .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                .FirstOrDefaultAsync(c => c.Id == yeniCalisanDept.CalisanId);

            Departman departman = await _context.Departmanlar.FirstOrDefaultAsync(d => d.Id == yeniCalisanDept.DepartmanId);

            CalisanDepartman calisanDepartman = new CalisanDepartman
            {
                Calisan = calisan,
                Departman = departman
            };

            await _context.CalisanDepartmanlar.AddAsync(calisanDepartman);
            await _context.SaveChangesAsync();

            Calisan guncelCalisan = await _context.Calisanlar
                                     .Where(c => c.Id == calisan.Id)
                                     .Include(c => c.Firma)
                                     .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                                     .FirstOrDefaultAsync();

            return _mapper.Map<CalisanGetirDto>(guncelCalisan);
        }
    }
}