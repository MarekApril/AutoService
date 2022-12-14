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
    public class ZamowieniaFactory : IZamowieniaFactory
    {
        private AutoServiceDbContext _context;
        private IMapper _mapper;

        public ZamowieniaFactory(AutoServiceDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public int Create(CreateZamowieniaDto dto)
        {
            var zamowienie = _mapper.Map<Zamowienie>(dto);
            _context.Zamowienia.Add(zamowienie);
            _context.SaveChanges();

            return zamowienie.Id;
        }

        public ZamowieniaDto GetById(int id)
        {
            var zamowienie = _context.Zamowienia.FirstOrDefault(c => c.Id == id);
            var zamowienieDto = _mapper.Map<ZamowieniaDto>(zamowienie);

            return zamowienieDto;
        }

        public bool Delete(int id)
        {
            var zamowienia = _context
                .Zamowienia
                .FirstOrDefault(r => r.Id == id);

            _context.Remove(zamowienia);
            _context.SaveChanges();

            return true;
        }

        public ZamowieniaDto Update(int id, ZamowieniaDto dto)
        {
            var zamowienie = _context.Zamowienia.FirstOrDefault(r => r.Id == id);

            zamowienie.Cena = dto.Cena;
            zamowienie.Ilosc = dto.Ilosc;
            zamowienie.NazwaTowaru = dto.NazwaTowaru;
            _context.SaveChanges();

            return dto;
        }

        public IEnumerable<ZamowieniaDto> GetAll()
        {
            var zamowienia = _context
                .Zamowienia
                .ToList();

            var zamowieniaDto = _mapper.Map<List<ZamowieniaDto>>(zamowienia);
            return zamowieniaDto;
        }
    }
}
