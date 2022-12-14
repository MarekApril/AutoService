using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Entities;
using AutoServis.Models;

namespace AutoServis.Mappers
{
    public class MechanikMappingProgfile : Profile
    {
        public MechanikMappingProgfile()
        {
            CreateMap<Mechanik, MechanikDto>()
                .ForMember(m => m.Miejscowosc, c => c.MapFrom(s => s.Adres.Miejscowosc))
                .ForMember(m => m.Numer, s => s.MapFrom(f => f.Adres.Numer))
                .ForMember(m => m.Poczta, s => s.MapFrom(f => f.Adres.Poczta))
                .ForMember(m => m.Ulica, s => s.MapFrom(f => f.Adres.Ulica));

            CreateMap<MechanikDto, Mechanik>()
                .ForMember(r => r.Adres, c => c.MapFrom(dto => new Adres()
                {
                    Ulica = dto.Ulica,
                    Poczta = dto.Poczta,
                    Miejscowosc = dto.Miejscowosc,
                    Numer = dto.Numer
                }));
        }
    }
}
