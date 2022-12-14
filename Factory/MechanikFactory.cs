using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoServis.Factory
{
    public class MechanikFactory : IMechanikFactory
    {
        private IMapper _mapper;
        private AutoServiceDbContext _context;

        public MechanikFactory(AutoServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(MechanikDto dto)
        {
            var mechanik = _mapper.Map<Mechanik>(dto);
            _context.Mechanicy.Add(mechanik);
            _context.SaveChanges();

            return mechanik.Id;
        }

        public IEnumerable<MechanikDto> GetAll()
        {
            var mechanicy = _context
                .Mechanicy
                .Include(r => r.Adres)
                .ToList();

            var mechanikcyDto = _mapper.Map<List<MechanikDto>>(mechanicy);
            return mechanikcyDto;
        }

        public bool Delete(int id)
        {
            var mechanik = _context
                .Mechanicy
                .FirstOrDefault(r => r.Id == id);
            var adres = _context
                .Adresy
                .FirstOrDefault(r => r.Id == mechanik.AdresId);

            _context.Mechanicy.Remove(mechanik);
            _context.Adresy.Remove(adres);
            _context.SaveChanges();

            return true;
        }

        public MechanikDto GetById(int id)
        {
            var mechanik = _context.Mechanicy.Include(c => c.Adres).FirstOrDefault(c => c.Id == id);
            var mechanikDto = _mapper.Map<MechanikDto>(mechanik);
            return mechanikDto;
        }

        public MechanikDto Update(int id, MechanikDto dto)
        {
            var mechanik = _context
                .Mechanicy
                .Include(r => r.Adres)
                .FirstOrDefault(r => r.Id == id);

            mechanik.Imie = dto.Imie;
            mechanik.Nazwisko = dto.Nazwisko;
            mechanik.Adres.Ulica = dto.Ulica;
            mechanik.Adres.Miejscowosc = dto.Miejscowosc;
            mechanik.Adres.Poczta = dto.Poczta;
            mechanik.Adres.Numer = dto.Numer;

            _context.SaveChanges();

            return dto;
        }
    }
}
