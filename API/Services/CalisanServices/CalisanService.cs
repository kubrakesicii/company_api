using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ApiResponse;
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

        public async Task<ServiceResponse<CalisanGetirDto>> EkleCalisan(CalisanEkleDto yeniCalisan)
        {
            ServiceResponse<CalisanGetirDto> response = new ServiceResponse<CalisanGetirDto>();

            Calisan calisan = _mapper.Map<Calisan>(yeniCalisan);

            await _context.Calisanlar.AddAsync(calisan);
            await _context.SaveChangesAsync();

            Calisan calisanEkle = await _context.Calisanlar
                                     .Where(c => c.Id == calisan.Id)
                                     .Include(c => c.Firma)
                                     .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                                     .FirstOrDefaultAsync();

            response.data = _mapper.Map<CalisanGetirDto>(calisanEkle);
            response.Message = "Kayit Basariyla Eklendi";
            return response;
        }

        public async Task<ServiceResponse<List<CalisanGetirDto>>> GetirTümCalisanlar()
        {
            ServiceResponse<List<CalisanGetirDto>> response = new ServiceResponse<List<CalisanGetirDto>>();

            List<Calisan> calisanlar = await _context.Calisanlar
                                     .OrderByDescending(c => c.Id)
                                     .Include(c => c.Firma)
                                     .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                                     .ToListAsync();

            response.data = _mapper.Map<List<Calisan>,List<CalisanGetirDto>>(calisanlar);
            response.Message = "Tüm Kayitlar Getirildi";

            return response;

        }

        public async Task<ServiceResponse<CalisanGetirDto>> GuncelleFirma(CalisanGuncelleDto calisan)
        {
            ServiceResponse<CalisanGetirDto> response = new ServiceResponse<CalisanGetirDto>();

            try{
                Calisan guncelCalisan = await _context.Calisanlar.FirstOrDefaultAsync(c => c.Id == calisan.CalisanId);

                if(guncelCalisan != null){
                    guncelCalisan.FirmaId = calisan.YeniFirmaId;

                    _context.Calisanlar.Update(guncelCalisan); 
                    await _context.SaveChangesAsync();

                     Calisan guncel = await _context.Calisanlar
                                        .Where(c => c.Id == guncelCalisan.Id)
                                        .Include(c => c.Firma)
                                        .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                                        .FirstOrDefaultAsync();
                    
                    response.Success = true;
                    response.Message = "Kayit Basariyla Guncellendi";
                    response.data =  _mapper.Map<CalisanGetirDto>(guncel);
                }
                else{
                    response.Message = "Gecersiz Id : Calisan bulunamadı.";
                    response.Success = false; 
                }
            }
             catch(Exception e){
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<CalisanGetirDto>>> SilCalisan(int id)
        {
            ServiceResponse<List<CalisanGetirDto>> response = new ServiceResponse<List<CalisanGetirDto>>();

            try{
                Calisan calisan = await _context.Calisanlar.FirstOrDefaultAsync(c => c.Id == id);

                if(calisan != null){
                    _context.Calisanlar.Remove(calisan);
                    await _context.SaveChangesAsync();

                    List<Calisan> calisanlar = await _context.Calisanlar
                                            .Include(c => c.Firma)
                                            .Include(c => c.CalisanDepartmanlari).ThenInclude(cd => cd.Departman)
                                            .ToListAsync();

                    response.Success = true;
                    response.Message = "Kayit Basariyla Silindi";
                    response.data = _mapper.Map<List<Calisan>,List<CalisanGetirDto>>(calisanlar); 
                }
                
                else{
                    response.Message = "Gecersiz Id : Calisan bulunamadı.";
                    response.Success = false; 
                }
            }
            catch(Exception e){
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }

}