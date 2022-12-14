using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Models;

namespace AutoServis.Factory
{
    public class AdresFactory : IAdresFactory
    {
        private AutoServiceDbContext _context;
        private IMapper _mapper;

        public AdresFactory(AutoServiceDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public int Create(CreateAdresDto dto)
        {
            var adres = _mapper.Map<Adres>(dto);
            _context.Adresy.Add(adres);
            _context.SaveChanges();

            return adres.Id;
        }

        public AdresDto GetById(int id)
        {
            var adres = _context.Adresy.FirstOrDefault(c => c.Id == id);
            var adresDto = _mapper.Map<AdresDto>(adres);

            return adresDto;
        }
        public IEnumerable<AdresDto> GetAll()
        {
            var adresy = _context
                .Adresy
                .ToList();

            var adresyDto = _mapper.Map<List<AdresDto>>(adresy);
            return adresyDto;
        }

        public bool Delete(int id)
        {
            var adres = _context
                .Adresy
                .FirstOrDefault(r => r.Id == id);

            _context.Adresy.Remove(adres);
            _context.SaveChanges();

            return true;
        }
    }
}
