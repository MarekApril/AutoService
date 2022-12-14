using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Entities;
using AutoServis.Models;

namespace AutoServis.Mappers
{
    public class AdresMappingProfile : Profile
    {
        public AdresMappingProfile()
        {
            CreateMap<Adres, AdresDto>();
            CreateMap<CreateAdresDto, Adres>();
        }
    }
}
