using System.Linq;
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Departman,DepartmanGetirDto>().ReverseMap();
            CreateMap<Calisan,CalisanGetirDto>()
                    .ForMember(dto => dto.Departmanlar,
                               c => c.MapFrom(c => c.CalisanDepartmanlari.Select(cd => cd.Departman)));
           
            CreateMap<Firma,FirmaGetirDto>();

            CreateMap<Calisan,CalisanEkleDto>().ReverseMap();
        }
    }
}