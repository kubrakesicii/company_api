using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services.FirmaServices
{
    public class FirmaService : IFirmaService
    {
        public DatabaseContext _context { get; }
        public FirmaService(DatabaseContext context)
        {
            _context = context;
        }

    
        public async Task<FirmaGetirDto> GetirFirma(int id)
        {
            Firma firma = await _context.Firmalar.FirstOrDefaultAsync(f => f.Id == id);

            int count = _context.Calisanlar.Where(c => c.FirmaId == id).Count();
        
            FirmaGetirDto firmaGetirDto = new FirmaGetirDto{
                Id = firma.Id,
                Ad = firma.Ad,
                CalisanSayisi = count
            };

            return firmaGetirDto;


        }

        public int SayCalisanlar(int id)
        {
            int count = _context.Calisanlar.Where(c => c.FirmaId == id).Count();
        
            return count;
        }

        public async Task<List<FirmaGetirDto>> GetirTümFirmalar()
        {
            List<Firma> firmalar = await _context.Firmalar.ToListAsync();
            List<FirmaGetirDto> firmaGetirDtos = new List<FirmaGetirDto>();

            firmalar.ForEach(f => {
                firmaGetirDtos.Add( new FirmaGetirDto{
                    Id = f.Id,
                    Ad = f.Ad,
                    CalisanSayisi = SayCalisanlar(f.Id)
                });
            });

            return firmaGetirDtos;
        }
    }
}