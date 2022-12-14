using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoServis.Contracts;
using AutoServis.Entities;
using AutoServis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoServis.Factory
{
    public class KontrahentFactory : IKontrahentFactory
    {
        private IMapper _mapper;
        private AutoServiceDbContext _context;

        public KontrahentFactory(AutoServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(CreateKontrahentDto dto)
        {
            var kontrahent = _mapper.Map<Kontrahent>(dto);
            _context.Kontrahenci.Add(kontrahent);
            _context.SaveChanges();

            return kontrahent.Id;
        }

        public KontrahentDto GetById(int id)
        {
            var kontrahent = _context.Kontrahenci.Include(c => c.Adres).FirstOrDefault(c => c.Id == id);
            var kontrahentDto = _mapper.Map<KontrahentDto>(kontrahent);
            return kontrahentDto;
        }

        public IEnumerable<KontrahentDto> GetAll()
        {
            var kontrahents = _context
                .Kontrahenci
                .Include(r => r.Adres)
                .ToList();

            var kontrahentsDto = _mapper.Map<List<KontrahentDto>>(kontrahents);
            return kontrahentsDto;
        }

        public bool Delete(int id)
        {
            var kontahent = _context
                .Kontrahenci
                .FirstOrDefault(r => r.Id == id);
            var adres = _context
                .Adresy
                .FirstOrDefault(r => r.Id == kontahent.AdresId);

            _context.Kontrahenci.Remove(kontahent);
            _context.Adresy.Remove(adres);
            _context.SaveChanges();

            return true;
        }

        public UpdateKontrahentDto Update(int id, UpdateKontrahentDto dto)
        {
            var kontrahent = _context
                .Kontrahenci
                .Include(r => r.Adres)
                .FirstOrDefault(r => r.Id == id);

            kontrahent.KontrahentNazwa = dto.KontrahentNazwa;
            kontrahent.Adres.Ulica = dto.Ulica;
            kontrahent.Adres.Miejscowosc = dto.Miejscowosc;
            kontrahent.Adres.Poczta = dto.Poczta;
            kontrahent.Adres.Numer = dto.Numer;

            _context.SaveChanges();

            return dto;
        }
    }
}
