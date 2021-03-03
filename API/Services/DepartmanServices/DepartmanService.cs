using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.DTOs.Departman;
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

/*
        public async Task<DepartmanaGöreCalisanGetirDto> GetirDepartmanaGöreCalisan(int deptId)
        {
            var departman = await _context.Departmanlar.FirstOrDefaultAsync(d => d.Id == deptId);

            var calisanListesi = (from c in _context.Calisanlar 
                           join cd in _context.CalisanDepartmanlar
                           on c.Id equals cd.CalisanId
                           where cd.DepartmanId==deptId
                           select c.AdSoyad).ToList();

            var firma = _context.Calisanlar.Where(c => c.AdSoyad == calisanListesi.FirstOrDefault()).Select(c => c.Firma).FirstOrDefault();

           List<string> calisanlar = new List<string>();

           calisanListesi.ForEach(c => {
               calisanlar.Add(c);
           });

            DepartmanaGöreCalisanGetirDto departmanaGöreCalisan = new DepartmanaGöreCalisanGetirDto{
                DepartmanId = deptId,
                Calisanlar =calisanlar,
                Firma = firma.Ad
            };

            return departmanaGöreCalisan;
        }
*/
///////////////////////////////
        public async Task<List<DepartmanaGöreCalisanGetirDto>> GetirDepartmanaGöreCalisanlar()
        {
            List<Departman> departmanlar = await _context.Departmanlar.ToListAsync();

            List<DepartmanaGöreCalisanGetirDto> departmanaGöreCalisanlar = new List<DepartmanaGöreCalisanGetirDto>();

            departmanlar.ForEach(d => {
                var calisanListesi = (from c in _context.Calisanlar 
                           join cd in _context.CalisanDepartmanlar
                           on c.Id equals cd.CalisanId
                           where cd.DepartmanId==d.Id
                           select new {
                               Calisan = c.AdSoyad,
                               Firma = c.Firma.Ad
                            }).ToList();
/*
                var firmaListesi = _context.Calisanlar.Where(c => c.AdSoyad == calisanListesi.FirstOrDefault()).Select(c => c.Firma).ToList();
*/
                List<CalisanFirmaDto> calisanlar = new List<CalisanFirmaDto>();
                CalisanFirmaDto calisanFirmaDto = new CalisanFirmaDto();

                calisanListesi.ForEach(c => {
                    calisanlar.Add(new CalisanFirmaDto{Calisan = c.Calisan,Firma=c.Firma});
                });

                DepartmanaGöreCalisanGetirDto departmanaGöreCalisan = new DepartmanaGöreCalisanGetirDto{
                DepartmanId = d.Id,
                Calisanlar =calisanlar
                };

                departmanaGöreCalisanlar.Add(departmanaGöreCalisan);
            });

            return departmanaGöreCalisanlar;
        }
    }
}