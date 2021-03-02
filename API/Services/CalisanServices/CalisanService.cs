using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.DTOs.Calisan;
using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services.CalisanServices
{
    public class CalisanService : ICalisanService
    {
        public DatabaseContext _context { get; }
        public IMapper _mapper { get; }
        public CalisanService(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CalisanGetirDto> EkleCalisan(CalisanEkleDto yeniCalisan)
        {
            Calisan calisan = _mapper.Map<Calisan>(yeniCalisan);

            await _context.Calisanlar.AddAsync(calisan);
            await _context.SaveChangesAsync();

            return _mapper.Map<CalisanGetirDto>(calisan);
        }

        public async Task<List<CalisanGetirDto>> GetirTümCalisanlar()
        {
            List<Calisan> calisanlar = await _context.Calisanlar
                                     .OrderByDescending(c => c.GirisTarihi)
                                     .Include(c => c.Firma)
                                     .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                                     .ToListAsync();

            return _mapper.Map<List<Calisan>,List<CalisanGetirDto>>(calisanlar);

        }

        public async Task<CalisanGetirDto> GuncelleFirma(CalisanGuncelleDto calisan)
        {
            Calisan guncelCalisan = await _context.Calisanlar.FirstOrDefaultAsync(c => c.Id == calisan.Id);

            guncelCalisan.FirmaId = calisan.FirmaId;

             _context.Calisanlar.Update(guncelCalisan); 
             await _context.SaveChangesAsync();

             return _mapper.Map<CalisanGetirDto>(guncelCalisan);

        }

        public async Task<List<CalisanGetirDto>> SilCalisan(int id)
        {
            Calisan calisan = await _context.Calisanlar.FirstOrDefaultAsync(c => c.Id == id);

             _context.Calisanlar.Remove(calisan);
            await _context.SaveChangesAsync();

            return _mapper.Map<List<Calisan>,List<CalisanGetirDto>>(await _context.Calisanlar.ToListAsync());
 
        }
    }

}