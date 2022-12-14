using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Entities;
using AutoServis.Models;

namespace AutoServis.Mappers
{
    public class SamochodMappingProfile : Profile
    {
        public SamochodMappingProfile()
        {
            CreateMap<Samochod, SamochodDto>()
                .ForMember(m => m.ImieMechanika, c => c.MapFrom(s => s.Mechanik.Imie))
                .ForMember(m => m.NazwiskoMechanika, c => c.MapFrom(s => s.Mechanik.Nazwisko));

            CreateMap<SamochodDto, Samochod>();

        }
    }
}
