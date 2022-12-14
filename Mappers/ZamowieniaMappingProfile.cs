using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Entities;
using AutoServis.Models;

namespace AutoServis.Mappers
{
    public class ZamowieniaMappingProfile : Profile
    {
        public ZamowieniaMappingProfile()
        {
            CreateMap<CreateZamowieniaDto, Zamowienie>();
            CreateMap<Zamowienie, ZamowieniaDto>();
        }
    }
}
