using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
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


        // Bir firmadaki calisanlarin sayisini veren yardimci metot.
        // Gerekli request metodunda kullanilacaktır.
        public int SayCalisanlar(int id)
        {
            int count = _context.Calisanlar.Where(c => c.FirmaId == id).Count();
        
            return count;
        }


        //Tüm Firma'lari calisan sayilariyla beraber listeler
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